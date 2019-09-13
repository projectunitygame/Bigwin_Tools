using CMS_Tools.Server.Packet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace CMS_Tools.Lib
{
    public abstract class BaseWebSocket
    {
        public Users userData;
        private const int maxMessageSize = 1024;
        private object _lock = new object();
        private byte[] receiveBuffer = new byte[maxMessageSize];
        public abstract void WriteLog(string msg, Exception ex = null, bool sendMail = false);
        public abstract void ProcessByDataPacket(string data);
        public abstract void init();
        private List<string> ListDataSend = new List<string>();
        private List<string> ListBroadcast = new List<string>();
        public string key;
        private AspNetWebSocket socket;
        public static Dictionary<string, AspNetWebSocketContext> LIST_CLIENT = new Dictionary<string, AspNetWebSocketContext>();
        public static Dictionary<string, string> LIST_MAP_TOKEN = new Dictionary<string, string>();

        public void SynSendData(object data)
        {
            lock (_lock)
            {
                ListDataSend.Add(JsonConvert.SerializeObject(data));
            }
        }

        public void SynSendData(string data) {
            lock (_lock)
            {
                ListDataSend.Add(data);
            }
        }

        public void SynSendData(List<string> data)
        {
            lock (_lock)
            {
                ListDataSend.AddRange(data);
            }
        }

        public void SynSendBroadcast(List<string> data)
        {
            lock (_lock)
            {
                ListBroadcast.AddRange(data);
            }
        }

        public void SynSendBroadcast(string data)
        {
            lock (_lock)
            {
                ListBroadcast.Add(data);
            }
        }

        public void SynSendBroadcast(object data)
        {
            lock (_lock)
            {
                ListBroadcast.Add(JsonConvert.SerializeObject(data));
            }
        }

        public async Task Receiver(AspNetWebSocketContext context)
        {
            try
            {
                socket = context.WebSocket as AspNetWebSocket;
                key = context.SecWebSocketKey;
                #region ADD CLIENT
                if (LIST_CLIENT == null)
                {
                    LIST_CLIENT = new Dictionary<string, AspNetWebSocketContext>();
                    LIST_MAP_TOKEN = new Dictionary<string, string>();
                }
                LIST_CLIENT.Add(key, context);
                LIST_MAP_TOKEN.Add(key, userData.token);

                //if (!LIST_CLIENT.ContainsKey(userData.token))
                //{
                //    LIST_CLIENT.Add(key, context);
                //    LIST_MAP_TOKEN.Add(key, userData.token);                    
                //}
                //else
                //{
                //    //var client = LIST_CLIENT[userData.token];                 
                //    //client = context;
                //    //var clientKey = LIST_MAP_TOKEN.SingleOrDefault(x => x.Value == userData.token).Key;
                //    //if(clientKey != null)
                //    //    LIST_MAP_TOKEN.Remove(clientKey);
                //    //LIST_MAP_TOKEN.Add(key, userData.token);
                //}
                if (!string.IsNullOrEmpty(userData.tokenOld))
                {
                    var listTokenOld = LIST_MAP_TOKEN.Where(x => x.Value == userData.tokenOld);
                    foreach (var item in listTokenOld)
                    {
                        await KickUser(item.Key, Constants.WEBSOCKET_STATUS.KICK_USER);
                    } 
                }
                #endregion
                init();
                while (socket.State == WebSocketState.Open)
                {
                    await ProcessSendDataPacket();
                    await ProcessSendBroadCast();

                    while (ListDataSend.Count > 0)
                    {
                        await SendMessage(ListDataSend[0]);
                        ListDataSend.RemoveAt(0);
                    }
                    WebSocketReceiveResult receiveResult = await socket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                    //disconnect client
                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        LIST_MAP_TOKEN.Remove(key);
                        await Disconnect(Constants.WEBSOCKET_STATUS.DISCONNECT_CLIENT);
                        //await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    }
                    else if (receiveResult.MessageType == WebSocketMessageType.Binary)
                    {
                        await socket.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "Cannot accept binary frame", CancellationToken.None);
                    }
                    else
                    {
                        int count = receiveResult.Count;

                        while (receiveResult.EndOfMessage == false)
                        {
                            if (count >= maxMessageSize)
                            {
                                await Disconnect(Constants.WEBSOCKET_STATUS.DISCONNECT_SERVER);
                                return;
                            }
                            receiveResult = await socket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer, count, maxMessageSize - count), CancellationToken.None);
                            count += receiveResult.Count;
                        }                       
                        var receivedString = Encoding.UTF8.GetString(receiveBuffer, 0, count);
                        ProcessByDataPacket(receivedString);
                    }                   
                }

            }
            catch (Exception ex)
            {
                WriteLog("ERROR WEBSOCKET", ex);
                await Disconnect(Constants.WEBSOCKET_STATUS.DISCONNECT_SERVER);
                return;
            }
        }

        /// <summary>
        /// Send data to client
        /// </summary>
        /// <returns></returns>
        private async Task ProcessSendDataPacket()
        {
            while (ListDataSend.Count > 0)
            {
                await SendMessage(ListDataSend[0]);
                ListDataSend.RemoveAt(0);
            }
        }

        /// <summary>
        /// send data all client
        /// </summary>
        /// <returns></returns>
        private async Task ProcessSendBroadCast()
        {
            while (ListBroadcast.Count > 0)
            {
                var outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(ListBroadcast[0]));
                ListBroadcast.RemoveAt(0);
                foreach (var item in LIST_CLIENT)
                {
                    // serialize and send            
                    if (item.Value.WebSocket.State == WebSocketState.Open && item.Key != key)
                    {
                        await item.Value.WebSocket.SendAsync(outputBuffer, WebSocketMessageType.Text,
                            true, CancellationToken.None);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private async Task KickUser(string key, Constants.WEBSOCKET_STATUS status)
        {
            if (LIST_CLIENT.ContainsKey(key))
            {
                var client = LIST_CLIENT[key].WebSocket as AspNetWebSocket;
                if (client.State == WebSocketState.Open)
                {
                    LIST_CLIENT.Remove(key);
                    await client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, status.ToString(), CancellationToken.None);                   
                }
            }
        }

        private async Task ProcessSendBroadCast(string data)
        {
            var outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(data));
            foreach (var item in LIST_CLIENT)
            {
                // serialize and send            
                if (item.Value.WebSocket.State == WebSocketState.Open && item.Key != userData.token)
                {
                    await item.Value.WebSocket.SendAsync(outputBuffer, WebSocketMessageType.Text,
                        true, CancellationToken.None);
                }
            }
        }

        private async Task SendMessage(string messageString)
        {
            if (socket.State == WebSocketState.Open)
            {
                var outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(messageString));
                await socket.SendAsync(outputBuffer, WebSocketMessageType.Text,
                            true, CancellationToken.None);
            }
            else
                return;
        }
        
        /// <summary>
        /// Close client websocket
        /// </summary>
        /// <param name="context"></param>
        /// <param name="msg"></param>
        private async Task Disconnect(Constants.WEBSOCKET_STATUS status)
        {
            if (socket.State == WebSocketState.CloseReceived)
            {
                //await ProcessSendBroadCast(userData.token + " disconnect");
                //context.WebSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure,
                //    msg, CancellationToken.None).Wait();
                LIST_CLIENT.Remove(key);
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, status.ToString(), CancellationToken.None);
            }
        }
    }
}
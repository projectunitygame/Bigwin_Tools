using CMS_Tools.Lib;
using CMS_Tools.Server.Packet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.WebSockets;

namespace CMS_Tools.Server
{
    public class ServerSocket : BaseWebSocket
    {
        private object _sync = new object();

        /// <summary>
        /// Save log file
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <param name="sendMail"></param>
        public override void WriteLog(string msg, Exception ex = null, bool sendMail = false)
        {
            Logs.SaveError(msg, ex);
        }

        public override void ProcessByDataPacket(string data)
        {
            //SynSendData("["+userData.userName+"] send " + data);
            //SynSendBroadcast("[" + userData.userName + "] broadcast " + data);
            dynamic dataPacket = JObject.Parse(data);
            switch ((Constants.PACKET_TYPE)dataPacket.type)
            {
                case Constants.PACKET_TYPE.USER_PACKET:
                    {
                        switch ((Constants.USER_PACKET_SUB)dataPacket.sub)
                        {
                            case Constants.USER_PACKET_SUB.USER_JOIN:
                                break;
                            case Constants.USER_PACKET_SUB.USER_LOCK:
                                break;
                            case Constants.USER_PACKET_SUB.CHANGE_AVATAR:
                                break;
                            case Constants.USER_PACKET_SUB.CHANGE_USERNAME:
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case Constants.PACKET_TYPE.CHAT_PACKET:
                    {
                        switch ((Constants.CHAT_PACKET_SUB)dataPacket.sub)
                        {
                            case Constants.CHAT_PACKET_SUB.SEND_MESSAGE:
                                break;
                            case Constants.CHAT_PACKET_SUB.CREATE_GROUP:
                                break;
                            case Constants.CHAT_PACKET_SUB.JOIN_GROUP:
                                break;
                            case Constants.CHAT_PACKET_SUB.LEAVE_GROUP:
                                break;
                            case Constants.CHAT_PACKET_SUB.SEARCH_CHAT:
                                break;
                            case Constants.CHAT_PACKET_SUB.LOAD_CHAT_MESSAGE:
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// client connected
        /// </summary>
        public override void init()
        {
            SynSendData(new UserLogin()
            {
                status = (int)Constants.USER_STATUS.LOGIN_SUCCESS,
                key = key
            });

            SynSendBroadcast(new UserJoin()
            {
                avatar = userData.avatar,
                key = key,
                userName = userData.userName
            });
        }
    }
}
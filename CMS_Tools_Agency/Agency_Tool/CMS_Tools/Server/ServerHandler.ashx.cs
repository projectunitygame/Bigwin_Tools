using CMS_Tools.Apis;
using CMS_Tools.Model;
using CMS_Tools.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CMS_Tools
{
    /// <summary>
    /// Summary description for ServerHandler
    /// </summary>
    public class ServerHandler : IHttpHandler, IRequiresSessionState
    {   
        UserInfo accountInfo;
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (context.IsWebSocketRequest || context.IsWebSocketRequestUpgrading)
            {
                #region CHECK ACCOUNT LOGIN
                accountInfo = Account.GetAccountInfo(context);
                if (accountInfo == null)
                    return;
                #endregion
                ServerSocket dataServer = new ServerSocket();
                dataServer.userData = new Server.Packet.Users() {
                    userId = accountInfo.AccountId.ToString(),
                    email = accountInfo.Email,
                    userName = accountInfo.UserName,
                    avatar = accountInfo.Avatar,
                    token = accountInfo.Token,
                    tokenOld = ""
                };
                context.AcceptWebSocketRequest(dataServer.Receiver);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
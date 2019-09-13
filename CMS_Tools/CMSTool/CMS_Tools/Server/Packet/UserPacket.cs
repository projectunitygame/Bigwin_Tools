using CMS_Tools.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Tools.Server.Packet
{
    public class UserPacket
    {
        
    }

    public class Users
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string token { get; set; }
        public string avatar { get; set; }
        public string email { get; set; }
        public string tokenOld { get; set; }
    }

    public class UserLogin: PacketBase
    {
        public UserLogin() {

        }
        public int status { get; set; }
        public string key { get; set; }
    }

    public class UserJoin: PacketBase
    {
        public UserJoin() {
            type = (int)Constants.PACKET_TYPE.USER_PACKET;
            sub = (int)Constants.USER_PACKET_SUB.USER_JOIN;
        }
        public string userName { get; set; }
        public string key { get; set; }
        public string avatar { get; set; }
    }
}
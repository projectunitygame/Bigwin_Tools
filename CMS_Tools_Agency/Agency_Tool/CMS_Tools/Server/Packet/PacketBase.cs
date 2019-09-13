using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Tools.Server.Packet
{
    public abstract class PacketBase
    {
        public int type { get; set; }
        public int sub { get; set; }
    }
}
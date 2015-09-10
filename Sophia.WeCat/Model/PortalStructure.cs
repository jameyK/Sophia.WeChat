using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophia.Wechat.Model
{
    public class PortalStructure
    {
        public string Signature { get; set; }
        public string Timestamp { get; set; }
        public string Nonce { get; set; }
        public string Echostr { get; set; }
    }
}

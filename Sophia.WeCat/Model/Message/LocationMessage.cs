using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Core;

namespace Sophia.Wechat.Model.Message
{
    public partial class Message
    {
        /*定位信息文本类消息封装*/
        public class LocationMessage : MessageBase
        {
            public LocationMessage()
                : base(SysMsgType.Location, typeof(LocationMessage))
            {}
 
            public long MsgId { get; set; }
            public decimal Location_X { get; set; }
            public decimal Location_Y { get; set; }
            public int Scale { get; set; }
            public string Label { get; set; }
        }
    }
}

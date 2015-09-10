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
        /*链接消息封装*/
        public class LinkMessage : MessageBase
        {
            public LinkMessage()
                : base(SysMsgType.Link, typeof(LinkMessage))
            {}
 
            public long MsgId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
        }
    }
}

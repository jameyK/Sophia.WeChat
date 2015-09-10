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
        /*文本类消息封装*/
        public class TextMessage : MessageBase
        {
            public TextMessage()
                : base(SysMsgType.Text, typeof(TextMessage))
            { }
 
            public string MsgId { get; set; }
            public string Content { get; set; }
        }
    }
}

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
        /*语音类消息封装*/
        public class VoiceMessage : MessageBase
        {
            public VoiceMessage()
                : base(SysMsgType.Voice, typeof(VoiceMessage))
            { }
 
            public long MsgId { get; set; }
            public string MediaId { get; set; }
            public string Format { get; set; }
            public string Recognition { get; set; }
        }
    }
}

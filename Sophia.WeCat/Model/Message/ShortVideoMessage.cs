using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophia.Wechat.Model.Message
{
    public partial class Message
    {
        /*短视频类消息封装*/
        public class ShortVideoMessage : MessageBase
        {
            public ShortVideoMessage()
                : base(SysMsgType.Shortvideo, typeof(ShortVideoMessage))
            { }

            public long MsgId { get; set; }
            public string MediaId { get; set; }
            public string ThumbMediaId { get; set; }
        }
    }
}

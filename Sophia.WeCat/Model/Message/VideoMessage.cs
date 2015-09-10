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
        /*视频类消息封装*/
        public class VideoMessage : MessageBase
        {
            public VideoMessage()
                : base(SysMsgType.Video, typeof(VideoMessage))
            {}
 
            public long MsgId { get; set; }
            public string MediaId { get; set; }
            public string ThumbMediaId { get; set; }
        }
    }
}

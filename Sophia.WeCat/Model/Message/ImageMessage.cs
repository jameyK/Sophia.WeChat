using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Model.Base;

namespace Sophia.Wechat.Model.Message
{
    public partial class Message
    {        
        /*图片消息封装*/
        public class ImageMessage : MessageBase
        {
            public ImageMessage()
                : base(SysMsgType.Image, typeof(ImageMessage))
            {}

            public long MsgId { get; set; }
            public string PicUrl { get; set; }
            public string MediaId { get; set; }
        }
    }
}

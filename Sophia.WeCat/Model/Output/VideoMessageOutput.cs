using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Action;
using Sophia.Wechat.Model.Base;

namespace Sophia.Wechat.Model.Message
{
    /*文本类消息封装*/
    public class VideoMessageOutput : OutputMetaBase
    {
        public VideoMessageOutput()
        {
            MsgType = MessageOutputType.Video.ToString().ToLower();
            //_messageOutputTyes.Add(MsgType, typeof(VideoMessageOutput));
        }

        [NecessaryItem(true)]
        public Video Video { get; set; }
    }

    public abstract class Video : MediaBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

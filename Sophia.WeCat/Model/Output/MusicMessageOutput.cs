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
    public class MusicMessageOutput : OutputMetaBase
    {
        public MusicMessageOutput()
        {
            MsgType = MessageOutputType.Music.ToString().ToLower();
            //_messageOutputTyes.Add(MsgType, typeof(MusicMessageOutput));
        }

        [NecessaryItem(true)]
        public string Music { get; set; }
    }

    public abstract class Music : MediaBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MusicUrl { get; set; }
        public string HQMusicUrl { get; set; }
        [NecessaryItem(true)]
        public string ThumbMediaId { get; set; }
    }
}

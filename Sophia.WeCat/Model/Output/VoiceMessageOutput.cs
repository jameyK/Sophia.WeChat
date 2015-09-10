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
    public class VoiceMessageOutput : OutputMetaBase
    {
        public VoiceMessageOutput()
        {
            MsgType = MessageOutputType.Voice.ToString().ToLower();
            //_messageOutputTyes.Add(MsgType, typeof(VoiceMessageOutput));
        }

        [NecessaryItem(true)]
        public Voice Voice { get; set; }
    }

    public abstract class Voice : MediaBase
    {
    }
}

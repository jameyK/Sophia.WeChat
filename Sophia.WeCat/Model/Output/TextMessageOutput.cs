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
    public class TextMessageOutput : OutputMetaBase
    {
        public TextMessageOutput()
        {
            MsgType = MessageOutputType.Text.ToString().ToLower();
            //_messageOutputTyes.Add(MsgType, typeof(TextMessageOutput));
        }

        [NecessaryItem(true)]
        public string Content { get; set; }
    }
}

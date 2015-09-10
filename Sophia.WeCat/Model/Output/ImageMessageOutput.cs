using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Action;
using Sophia.Wechat.Model.Base;

namespace Sophia.Wechat.Model.Message
{
    public class ImageMessageOutput : OutputMetaBase
   {
        public ImageMessageOutput()
        {
            MsgType = MessageOutputType.Image.ToString().ToLower();
            ////_messageOutputTyes.Add(MsgType, typeof(ImageMessageOutput));
        }

        [NecessaryItem(true)]
        public Image Image { get; set; }
   }

    public abstract class Image : MediaBase
    {
    }
}

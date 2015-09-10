using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Action;

namespace Sophia.Wechat.Model.Message
{
    /*媒体基类*/
    public abstract class MediaBase
    {
        [NecessaryItem(true)]
        public string MediaId { get; set; }
    }

}

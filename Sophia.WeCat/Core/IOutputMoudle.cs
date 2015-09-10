using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Action;

namespace Sophia.Wechat.Model.Message
{
    public interface IOutputMoudle
    {
        [NecessaryItem(true)]
        string ToUserName { get; set; }
        [NecessaryItem(true)]
        string FromUserName { get; set; }
        [NecessaryItem(true)]
        string CreateTime { get; set; }
        [NecessaryItem(true)]
        string MsgType { get;} 

        string ToXml();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Model.Base;
using Sophia.Wechat.Model.Message;

namespace Sophia.Wechat.Model
{
    public delegate IOutputMoudle MetaBaseExcuteEventHandler(WechatMetaBase message);
    public class HandlerInfo
    {
        public MetaBaseExcuteEventHandler Handler { get; set; }
        //public MetaBaseExcuteEventHandler EventHandler { get; set; }
        public Type MetaType { get; set; }

    }
}

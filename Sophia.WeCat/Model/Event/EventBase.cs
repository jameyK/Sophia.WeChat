using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Core;
using Sophia.Wechat.Model.Base;
using Sophia.Wechat.Model.Message;
using Sophia.Wechat.Unility;
using Tuna.Utility.Format;

namespace Sophia.Wechat.Model.Event
{
    public abstract class EventBase : WechatMetaBase
    {
        //public event MetaBaseExcuteEventHandler onExcuteEvent;
        public EventBase(SysMsgType msgType, SysEventType eventType, Type type)
        {
            MsgType = msgType.ToString().ToLower();
            Event = eventType.ToString().ToLower();
            ExcuterKey = MD5Encrypt.MD5Bytes(MsgType + Event).ToHexString();
            if (!_metaExcutorDictionary.ContainsKey(ExcuterKey))
            {
                _metaExcutorDictionary.Add(ExcuterKey, new HandlerInfo() { MetaType = type });
            }
        }

        public string Event { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Core;
using Sophia.Wechat.Model.Base;
using Sophia.Wechat.Unility;
using Tuna.Utility.Format;

namespace Sophia.Wechat.Model.Message
{
    public abstract class MessageBase: WechatMetaBase, IExcuteable
    {
        //public event MetaBaseExcuteEventHandler onExcuteMessage;
        public MessageBase(SysMsgType msgType, Type type)
        {
            MsgType = msgType.ToString().ToLower();
            ExcuterKey = MD5Encrypt.MD5Bytes(MsgType).ToHexString();
            if (!_metaExcutorDictionary.ContainsKey(ExcuterKey))
            {
                _metaExcutorDictionary.Add(ExcuterKey, new HandlerInfo() { MetaType = type });
            }
        }
    }
}

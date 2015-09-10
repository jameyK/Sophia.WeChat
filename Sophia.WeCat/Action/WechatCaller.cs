using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Model;
using Sophia.Wechat.Model.Base;
using Sophia.Wechat.Model.Event;
using Sophia.Wechat.Model.Message;

namespace Sophia.Wechat.Action
{
    public class WechatExcuteFactory
    {
        private WechatMetaBase _meta = null;
        public WechatExcuteFactory(WechatMetaBase meta)
        {
            _meta = meta;
        }

        public string Excute()
        {
            if (_meta != null)
            {
                //取出执行顺序，依次执行
                if (WechatMetaBase.MetaExcutorDictionary.ContainsKey(_meta.ExcuterKey))
                {
                    HandlerInfo handlerInfo = WechatMetaBase.MetaExcutorDictionary[_meta.ExcuterKey];
                    if (handlerInfo.Handler != null)
                    {
                        IOutputMoudle messageOut = handlerInfo.Handler.Invoke(_meta);
                        return messageOut.ToXml();
                    }
                }
            }
            return "";
        }
    }
}

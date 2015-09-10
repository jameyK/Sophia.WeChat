using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sophia.Wechat.Model;
using Sophia.Wechat.Model.Base;
using Sophia.Wechat.Model.Event;
using Sophia.Wechat.Model.Message;

namespace Sophia.WeChat.Webapi
{
    public class Service
    {
        public static IOutputMoudle Subscribe(WechatMetaBase meta)
        {
            TextMessageOutput returnValue = meta.ConstructOutput<TextMessageOutput>();


            return returnValue;
        }
        public static IOutputMoudle Subscribe2(WechatMetaBase meta)
        {
            return default(IOutputMoudle);
        }

        public static IOutputMoudle Click(WechatMetaBase meta)
        {
            return default(IOutputMoudle);
        }
        public static IOutputMoudle TextMessageInput(WechatMetaBase meta)
        {
            return default(IOutputMoudle);
        }
    }
}
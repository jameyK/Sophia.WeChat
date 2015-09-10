using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Sophia.Wechat.Action;
using Sophia.Wechat.Core;
using Sophia.Wechat.Model;
using Sophia.Wechat.Model.Base;
using Sophia.Wechat.Model.Message;

namespace Sophia.Wechat
{
    public class SophiaChat
    {
        #region 单例构造，构建唯一入口
        private static SophiaChat _instance = null;
        private static Object _objLock = new object();
        public static SophiaChat Init(string wxAppId, string wxAppSecret, string token)
        {
            if (_instance == null)
            {
                lock (_objLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SophiaChat(wxAppId, wxAppSecret, token);
                    }
                }
            }
            return _instance;
        } 
        #endregion

        #region 提供外部调用入口
        /// <summary>
        /// 做静态方法注册，用于绑定当前入口项处理
        /// </summary>
        /// <param name="cType"></param>
        /// <param name="callHandler"></param>
        public static void Register<T>(MetaBaseExcuteEventHandler callHandler) where T : IExcuteable//ExcuteHandlerType cType,
        {
            IExcuteable obj = Activator.CreateInstance<T>();
            if (WechatMetaBase.MetaExcutorDictionary.ContainsKey(obj.ExcuterKey))
            {
                if (WechatMetaBase.MetaExcutorDictionary[obj.ExcuterKey] == null)
                    WechatMetaBase.MetaExcutorDictionary[obj.ExcuterKey] = new HandlerInfo();

                WechatMetaBase.MetaExcutorDictionary[obj.ExcuterKey].Handler = callHandler;
            }
        }

        /// <summary>
        /// 提供安全接入，每次检验入是否为合法调用
        /// 目前只支持POST方式调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">入口检查对象实体，对应POST和GET的四个字段，POST方式Echostr无数据</param>
        /// <param name="xmlStream">Request.InputStream数据流，POST方式才有</param>
        /// <param name="caller">具体业务回调器</param>
        /// <returns></returns>
        public static string BindChatServer(PortalStructure input, Stream xmlStream)
        {
            if (_instance == null)
            {
                throw new Exception("Sophia未进行初始化，请调用SophiaChat.Init初始化系统！");
            }

            if (input == null)
            {
                throw new Exception("入口校验参数为Null，无法处理，请检查设置！");
            }

            MetaBase meta = null;
            if (valadateSign(input) == false || !string.IsNullOrEmpty(input.Echostr))
            {
                meta = null;
            }

            meta = MetaBase.ToMessage(xmlStream);
            WechatExcuteFactory caller = new WechatExcuteFactory((WechatMetaBase)meta);
            return caller.Excute();
        } 
        #endregion

        #region 私有方法
        private static bool valadateSign(PortalStructure input)
        {
            string[] ArrTmp = { _token, input.Timestamp, input.Nonce };
            Array.Sort(ArrTmp);
            var tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            if (tmpStr == null || tmpStr.ToLower() == input.Signature)
            {
                return false;
            }
            return true;
        }
        private static string _wxAppId = null;
        private static string _wxAppSecret = null;
        private static string _token = null;
        private SophiaChat(string wxAppId, string wxAppSecret, string token)
        {
            if (!string.IsNullOrEmpty(wxAppId)) _wxAppId = wxAppId;
            if (!string.IsNullOrEmpty(wxAppSecret)) _wxAppSecret = wxAppSecret;
            if (!string.IsNullOrEmpty(token)) _token = token;
            
            //装载部件

        } 
        #endregion
    }
}

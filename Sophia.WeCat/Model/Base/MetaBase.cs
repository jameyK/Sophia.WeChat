using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Sophia.Wechat.Action;
using Sophia.Wechat.Model.Event;
using Sophia.Wechat.Model.Message;
using Sophia.Wechat.Unility;
using Tuna.Utility.Format;

namespace Sophia.Wechat.Model.Base
{
    public class MetaBase
    {
        public string ExcuterKey { get; protected set; }
        public static Dictionary<string, HandlerInfo> MetaExcutorDictionary { get { return _metaExcutorDictionary; } }
        protected static Dictionary<string, HandlerInfo> _metaExcutorDictionary = new Dictionary<string, HandlerInfo>();

        public T ConstructOutput<T>() where T : IOutputMoudle
        {
            IOutputMoudle outputMoudle = (IOutputMoudle)Activator.CreateInstance<T>();
            outputMoudle.ToUserName = this.FromUserName;
            outputMoudle.FromUserName = this.ToUserName;
            outputMoudle.CreateTime = DateTime.Now.ToTimeStamp(TimeStampAccuracy.Secound)+"";
            return (T)outputMoudle;
        }

        #region 基础数据结构
        [NecessaryItem(true)]
        public string ToUserName { get; set; }
        [NecessaryItem(true)]
        public string FromUserName { get; set; }
        [NecessaryItem(true)]
        public string CreateTime { get; set; }
        [NecessaryItem(true)]
        public string MsgType { get; protected set; } 
        #endregion
 
        #region ToXml
        /*构建发布信息结构，支持多种消息结构拼装*/
        public string ToXml()
        {
            return string.Join("", makeXmlTagBuilder(this, "<xml>"));
        }
        private List<string> makeXmlTagBuilder(object obj, string tagName)
        {
            List<string> strbValues = new List<string>();
            strbValues.Add(tagName);
            foreach (PropertyInfo p in this.GetType().GetProperties())
            {
                string value = "<{0}>{1}</{0}>";
                if (p.PropertyType == typeof(string))
                {
                    value = "<{0}><![CDATA[{1}]]></{0}>";
                }

                object objValue = p.GetValue(this, null);
                if (objValue is IOutputMoudle)
                {
                    strbValues.AddRange(makeXmlTagBuilder(obj, string.Format("<{0}>", obj.GetType().Name)));
                }
                else
                {
                    strbValues.Add(string.Format(value, p.Name, objValue));
                }

            }
            strbValues.Add(tagName);
            return strbValues;
        }
        #endregion

        #region ToMessage
        /*构建消息转换机制，只需支持客户端法向服务器端的消息处理*/
        public static MetaBase ToMessage(Stream inputStream)
        {
            MetaBase obj = null;
            if (inputStream == null || !inputStream.CanRead) return obj;
            try
            {
                XmlReader xr = XmlReader.Create(inputStream);
                XElement xml = XDocument.Load(xr).Root;
                if (xml != null)
                {
                    var pMsgType = xml.Element("MsgType");
                    if (pMsgType == null || string.IsNullOrEmpty(pMsgType.Value))
                    {
                        throw new Exception("MetaBase转换失败，数据源未定义MsgType");
                        return obj;
                    }

                    string keyOfMsgType = pMsgType.Value;
                    if (string.Equals("event", pMsgType.Value))
                    {
                        var pEvent = xml.Element("Event");
                        if (pEvent == null || string.IsNullOrEmpty(pEvent.Value))
                        {
                            throw new Exception("MetaBase转换失败，事件数据未定义Event参数");
                            return obj;
                        }

                        keyOfMsgType = pMsgType.Value + pEvent.Value;
                    }
                    keyOfMsgType = MD5Encrypt.MD5Bytes(keyOfMsgType).ToHexString();

                    Type type = _metaExcutorDictionary[keyOfMsgType].MetaType;
                    obj = (EventBase)Activator.CreateInstance(type);
                    foreach (PropertyInfo p in type.GetProperties())
                    {
                        var pValueElement = xml.Element(p.Name);
                        if (pValueElement != null)
                        {
                            p.SetValue(obj, pValueElement.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }
        #endregion
    }
}

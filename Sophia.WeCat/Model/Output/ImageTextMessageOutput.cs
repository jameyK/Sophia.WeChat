using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Action;
using Sophia.Wechat.Model.Base;

namespace Sophia.Wechat.Model.Message
{
    public class ImageTextMessageOutput : OutputMetaBase
    {
        public ImageTextMessageOutput()
        {
            MsgType = MessageOutputType.News.ToString().ToLower();
            ////_messageOutputTyes.Add(MsgType, typeof(ImageTextMessageOutput));
        }

        [NecessaryItem(true)]
        public int ArticleCount { get; set; }
        [NecessaryItem(true)]
        public List<item> Articles { get; set; }

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
                if (objValue is List<item>)
                {
                    strbValues.Add(string.Format("<{0}>", p.Name));
                    List<item> list = (List<item>)objValue;
                    foreach (item item in list)
                    {
                        strbValues.AddRange(makeXmlTagBuilder(item, string.Format("<{0}>", item.GetType().Name)));
                    }
                    strbValues.Add(string.Format("<{0}>", p.Name));
                }
                else if (objValue is IOutputMoudle)
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
    }

    public abstract class item : MediaBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }
    }
}

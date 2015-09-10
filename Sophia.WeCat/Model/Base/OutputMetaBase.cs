using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Model.Message;
using Sophia.Wechat.Unility;

namespace Sophia.Wechat.Model.Base
{
    public abstract class OutputMetaBase : MetaBase, IOutputMoudle
    {
        public T InitOuput<T>() where T : OutputMetaBase
        {
            T obj = Activator.CreateInstance<T>();
            obj.FromUserName = this.ToUserName;
            obj.ToUserName = this.FromUserName;
            obj.CreateTime = DateTime.Now.ToTimeStamp(TimeStampAccuracy.Secound) + "";
            return obj;
        }
    }
}

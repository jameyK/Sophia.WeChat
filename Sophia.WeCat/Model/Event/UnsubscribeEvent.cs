using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Model.Message;

namespace Sophia.Wechat.Model.Event
{
    public partial class Event
    {
        /*event = subscribe*/
        public class Unsubscribe : EventBase
        {
            public Unsubscribe()
                : base(SysMsgType.Event, SysEventType.Unsubscribe, typeof(Unsubscribe))
            {}
        }
    }
}

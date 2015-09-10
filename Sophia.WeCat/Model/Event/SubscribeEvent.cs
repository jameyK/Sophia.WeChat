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
        public class Subscribe : EventBase
        {
            public Subscribe()
                : base(SysMsgType.Event, SysEventType.Subscribe, typeof(Subscribe))
            {}
        }
    }
}

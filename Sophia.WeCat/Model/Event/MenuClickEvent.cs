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
        /*event = CLICK*/
        public class MenuClick : EventBase
        {
            public MenuClick()
                : base(SysMsgType.Event, SysEventType.Click, typeof(MenuClick))
            {}

            public string EventKey { get; set; }
        }
    }
}

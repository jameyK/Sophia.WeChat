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
        /*event = 未关注：subscribe  已关注：SCAN*/
        public class QRCodeScan : EventBase
        {
            public QRCodeScan()
                : base(SysMsgType.Event, SysEventType.Scan, typeof(QRCodeScan))
            {}

            public string EventKey { get; set; }
            public string Ticket { get; set; }
        }
    }
}

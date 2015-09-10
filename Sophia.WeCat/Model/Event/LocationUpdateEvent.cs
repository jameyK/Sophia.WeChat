using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Core;
using Sophia.Wechat.Model.Message;

namespace Sophia.Wechat.Model.Event
{
    public partial class Event
    {
        /*event = LOCATION*/
        public class LocationUpdate : EventBase
        {
            public LocationUpdate()
                : base(SysMsgType.Event, SysEventType.Location, typeof(LocationUpdate))
            {}

            /*纬度*/
            public decimal Latitude { get; set; }
            /*经度*/
            public decimal Longitude { get; set; }
            /*精确值*/
            public string Precision { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophia.Wechat.Model
{
    /*媒体类型*/
    public enum SysMsgType
    {
        Text, Image, Voice, Video, Shortvideo, Location, Link, Event
    }
    public enum SysEventType
    {
        Location, Click, Scan, Subscribe, Unsubscribe
    }

    /*媒体类型*/
    public enum MessageOutputType
    {
        Text, Image, Voice, Video, Music, News
    }

}

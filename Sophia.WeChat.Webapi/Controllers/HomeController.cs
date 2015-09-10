using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sophia.Wechat;
using Sophia.Wechat.Model;

namespace Sophia.WeChat.Webapi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult OpenWechat()
        {
            string sResult = SophiaChat.BindChatServer(new PortalStructure()
            {
                Nonce = "213",
                Signature = "123",
                Timestamp = "123213213"
            }, Request.InputStream);
            return Content(sResult);
        }

    }
}

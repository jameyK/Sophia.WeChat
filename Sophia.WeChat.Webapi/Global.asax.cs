using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Sophia.Wechat;
using Sophia.Wechat.Model;
using Sophia.Wechat.Model.Event;
using Sophia.Wechat.Model.Message;

namespace Sophia.WeChat.Webapi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //启动Sophia微信环境
            SophiaChat.Init("wxAppid", "wxAppScrect", "axToken");

            //向系统注册微信入口解决方案
            SophiaChat.Register<Event.Subscribe>(Service.Subscribe);
            SophiaChat.Register<Event.Subscribe>(Service.Subscribe2);
            SophiaChat.Register<Event.MenuClick>(Service.Click);
            SophiaChat.Register<Message.TextMessage>(Service.TextMessageInput);
        }
    }
}
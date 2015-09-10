using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophia.Wechat.Model;
using Sophia.Wechat.Model.Message;

namespace Sophia.Wechat.Core
{
    public interface IExcuteable
    {
        string ExcuterKey { get;}
    }
}

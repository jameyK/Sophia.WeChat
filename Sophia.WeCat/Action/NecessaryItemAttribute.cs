using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophia.Wechat.Action
{
    public class NecessaryItemAttribute : Attribute
    {
        public NecessaryItemAttribute(bool isNecessary)
        {
            IsNecessary = isNecessary;
        }
        public bool IsNecessary { get; set; }
    }
}

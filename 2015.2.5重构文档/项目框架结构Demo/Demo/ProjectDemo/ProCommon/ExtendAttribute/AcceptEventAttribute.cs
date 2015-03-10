
using ProCommon.ProEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCommon.ExtendAttribute
{
  public    class AcceptEventAttribute:Attribute
    {
      public AcceptEventAttribute(string name, ERouteEvent value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; private set; }

        public ERouteEvent Value { get; private set; }
    }
}

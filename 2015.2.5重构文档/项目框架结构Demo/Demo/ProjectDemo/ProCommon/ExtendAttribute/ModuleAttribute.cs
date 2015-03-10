using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCommon.ExtendAttribute
{
  public  class ModuleAttribute:Attribute
    {

      public ModuleAttribute(string dllName)
        {
            this.DllName = dllName;
        }
      public string DllName { get; private set; }
    }
}

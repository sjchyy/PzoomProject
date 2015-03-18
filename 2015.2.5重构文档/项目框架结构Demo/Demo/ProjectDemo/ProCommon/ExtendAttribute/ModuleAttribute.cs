using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCommon.ExtendAttribute
{
    public class ModuleAttribute : Attribute
    {

        public ModuleAttribute(string dllName, string name, string parentName)
        {
            this.DllName = dllName;
            this.Name = name;
            this.ParentName = parentName;
        }

        public string DllName { get; private set; }

        public string ParentName { get; private set; }

        public string Name { get; private set; }

    }
}

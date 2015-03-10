using ProInterface.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ProInterface.ExtendAttribute
{
  public    class AcceptEventAttribute:Attribute
    {
      public AcceptEventAttribute(string name, ERoutedEvent value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }

        public ERoutedEvent Value { get; private set; }
    }
}

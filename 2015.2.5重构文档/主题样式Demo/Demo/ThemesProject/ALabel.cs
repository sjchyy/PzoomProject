using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ThemesProject
{
  public   class ALabel:Label
    {
      static ALabel()
      {
          DefaultStyleKeyProperty.OverrideMetadata(typeof(ALabel), new System.Windows.FrameworkPropertyMetadata(new ThemeResourceKey(typeof(Theme_Blue),typeof(ALabel))));
      }
    }
}

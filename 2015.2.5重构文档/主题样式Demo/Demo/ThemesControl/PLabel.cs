using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ThemeBase;

namespace ThemesControl
{
  public class PLabel:Label
    {
      static PLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PLabel), new System.Windows.FrameworkPropertyMetadata(new ThemeResourceKey(typeof(Theme_Default),typeof(PLabel))));
        }
    }
}

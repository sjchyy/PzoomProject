using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProInterface.Delegate;

namespace ProInterface
{
    public interface IModuleRoute
    {

        event ModuleRoutedEventHandler ModuleRoutedEvent;
    }
}

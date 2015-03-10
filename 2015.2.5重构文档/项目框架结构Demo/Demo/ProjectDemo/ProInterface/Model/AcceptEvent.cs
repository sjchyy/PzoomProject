using ProCommon.ProEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProInterface.Model
{
    public  class AcceptEvent
    {

        public ERouteEvent EventType { get; set; }

        public object EventArgs { get; set; }
    }
}

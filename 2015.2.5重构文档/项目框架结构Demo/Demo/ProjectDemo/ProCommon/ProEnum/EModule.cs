
using ProCommon.ExtendAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCommon.ProEnum
{
   public enum EModule
    {
        [ModuleAttribute("ProView.dll")]
         AccountView,
         [ModuleAttribute("ProBaidu.dll")]
         BaiduEdit,
         [ModuleAttribute("ProSogou.dll")]
         SogouEdit,
        [ModuleAttribute("ProBiddingSogou.dll")]
         BaiduBidding,
          [ModuleAttribute("ProBiddingSogou.dll")]
         SogouBidding,
    }
}


using ProCommon.ExtendAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCommon.ProEnum
{
   public enum EModule
    {
         [ModuleAttribute("ProView.dll","概览",null)]
         AccountView,
         [ModuleAttribute("ProBaidu.dll","物料管理","百度管理")]
         BaiduEdit,
         [ModuleAttribute("ProSogou.dll","物料管理","搜狗管理")]
         SogouEdit,
         [ModuleAttribute("ProBiddingBaidu.dll","百度调价","百度管理")]
         BaiduBidding,
         [ModuleAttribute("ProBiddingSogou.dll", "搜狗调价", "搜狗管理")]
         SogouBidding,
    }
    public enum EModuleLevel
    {
        Once=1,
        Double,
    }
}

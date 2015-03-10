using ProCommon.ExtendAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProCommon.ProEnum;

namespace ProCommon.Extensions
{
    public static class EnumExtensions
    {
        public static bool Contains(this Enum parent, Enum ele)
        {
            return ((int)(object)parent | (int)(object)ele) == (int)(object)parent;
        }

        public static IEnumerable<object> GetValues(this Enum data)
        {
            foreach (object item in Enum.GetValues(data.GetType()))
                yield return item;
        }

        public static string GetModuleDllName(this Enum data)
        {
            var dataType = data.GetType();
            var fileInfo = dataType.GetField(data.ToString());
            if (null == fileInfo)
                return data.ToString();
            var customAttributes = fileInfo.GetCustomAttributes(typeof(ModuleAttribute), false);
            var attribute = (ModuleAttribute)customAttributes.OfType<ModuleAttribute>().FirstOrDefault();
            return attribute != null ? attribute.DllName : data.ToString();
        }

      

      
       
    }
}

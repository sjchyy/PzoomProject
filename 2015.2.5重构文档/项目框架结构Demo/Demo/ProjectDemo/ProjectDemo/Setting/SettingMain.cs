using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProInterface;

namespace ProjectDemo.Setting
{
    public  class SettingMain : ISetting
    {
        public List<ProInterface.Model.User> UserList { get; set; }

        public List<ProInterface.Model.Permission> Permissons { get; set; }

    }
}

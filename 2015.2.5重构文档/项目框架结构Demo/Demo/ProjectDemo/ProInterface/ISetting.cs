using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProInterface.Model;

namespace ProInterface
{
   public  interface ISetting
    {
       List<User> UserList { get; set; }

       List<Permission> Permissons { get; set; }

    }
}

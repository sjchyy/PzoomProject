using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProInterface
{
    public interface ILoginMain
    {
        string Token { get; set; }

        bool Login();

    }
}

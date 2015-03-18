using ProInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ProjectDemo.Login
{
    /// <summary>
    /// 登 录
    /// </summary>
    public class LoginMain :ILoginMain
    {
        public LoginMain()
        {

        }
        private string _token;
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public bool Login()
        {
            MessageBox.Show("Token");
            return true;
        }
    }
}

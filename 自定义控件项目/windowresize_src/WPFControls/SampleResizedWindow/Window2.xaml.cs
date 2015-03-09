using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserWindow;

namespace SampleResizedWindow
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2:UWindow
    {
        public Window2()
        {
            InitializeComponent();
            Wr.addWindowHeader(this.User_Header);
            Wr.addWindowMinButton(this.User_MinButton);
            Wr.addWindowMaxButton(this.User_MaxButton);
            Wr.addWindowCloseButton(this.User_CloButton);
        }
    }
}

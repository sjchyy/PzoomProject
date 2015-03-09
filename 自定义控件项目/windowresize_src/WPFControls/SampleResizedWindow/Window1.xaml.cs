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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserWindow;

namespace SampleResizedWindow
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

           Resizer wr = new Resizer(this);
            wr.addResizerRight(rightSizeGrip);
            wr.addResizerLeft(leftSizeGrip);
            wr.addResizerUp(topSizeGrip);
            wr.addResizerDown(bottomSizeGrip);
            wr.addResizerLeftUp(topLeftSizeGrip);
            wr.addResizerRightUp(topRightSizeGrip);
            wr.addResizerLeftDown(bottomLeftSizeGrip);
            wr.addResizerRightDown(bottomRightSizeGrip);
            wr.addWindowHeader(windowHeader);
            wr.addWindowMinButton(windowMin);
            wr.addWindowMaxButton(windowMax);
            wr.addWindowCloseButton(windowClose);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗", "tip", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}

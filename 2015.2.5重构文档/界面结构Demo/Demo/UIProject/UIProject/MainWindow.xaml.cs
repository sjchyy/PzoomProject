using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIProject.Command;
using UIProject.Model;
using WindowControl;
using WindowControl.AddWindow;

namespace UIProject
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        MAddPlan plan;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            plan = new MAddPlan() { PlanName = "我的计划1" };
            plan.GroupSource = InitGroupSource();
            plan.AddGroupCommand = new AddGroupCommand(AddGroup);
            AddPlan window = WindowManager.CreateAddPlanWindow();
            window.Owner = this;
            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            window.DataContext = plan;
            window.ShowDialog();
        }

        private ObservableCollection<MGroup>  InitGroupSource()
        {
            ObservableCollection<MGroup> source = new ObservableCollection<MGroup>();

            for (int i = 0; i < 10;i++ )
            {
                source.Add(new MGroup() { GroupName = "组名称" + i, State = "正常" });
       
            }
                return source;
        }
        private void AddGroup(object param)
        {

            plan.GroupSource.Add(new MGroup() { GroupName = "组名称new", State = "正常" });
        }
    }
}

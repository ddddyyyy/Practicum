using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdressBook
{
    
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User user;

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Login login = new Login();
            Hide();
            login.ShowDialog();
            if (login.DialogResult == true)
            {
                user = login.user;
                Logining.Text = "当前的用户是:" + user.Name;
                Show();
            }
            else
            {
                Environment.Exit(Environment.ExitCode);
            }
        }
        private void Add(object sender, RoutedEventArgs e)
        {

            if (user.Role == Roles.全权用户)
            {
                MainContent.Content = new Frame()
                {
                    Content = UserAdd.UserAddFactory()
                };
            }
            else
            {
                MessageBox.Show("无权限");
            }
            
        }

        private void List(object sender, RoutedEventArgs e)
        {
            if (MainWindow.user.Role != Roles.非法用户)
            {
                MainContent.Content = new Frame()
                {
                    Content = UserList.UserListFactory()
                };
            }
            else
            {
                MessageBox.Show("无法查看");
            }
        }

    }
}

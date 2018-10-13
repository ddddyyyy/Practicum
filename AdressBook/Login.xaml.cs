using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {

        public User user;
        public Login()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.Width = 300;
            this.Height = 150;
        }

        private void Commit(object sender, RoutedEventArgs e)
        {
            user = null;
            try
            {
                user = Mapper.GetInstance().Select(Int32.Parse(id.Text));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (null == user)
            {
                MessageBox.Show("用户不存在");
            }
            else
            {
                DialogResult = true;
                Close();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

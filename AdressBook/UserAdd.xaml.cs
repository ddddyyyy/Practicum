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
    /// UserAdd.xaml 的交互逻辑
    /// </summary>
    public partial class UserAdd : UserControl
    {
        static UserAdd userAdd;
        User user;
        public static UserAdd UserAddFactory()
        {
            if (null == userAdd)
            {
                userAdd = new UserAdd();
            }
            return userAdd;
        }

        public UserAdd()
        {
            InitializeComponent();
            user = new User();
            panel.DataContext = user;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Mapper.GetInstance().Insert(user);
        }
    }
}

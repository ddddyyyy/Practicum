using SqlSugar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// UserControl.xaml 的交互逻辑
    /// </summary>
    public partial class UserList : UserControl
    {
        public User user;
        static UserList userList;
        static ObservableCollection<User> list;
        public UserList()
        {
            InitializeComponent();
            list = new ObservableCollection<User>(Mapper.GetInstance().Select());
            foreach (User u in list)
            {
                u.Change += change;
            }
            data.DataContext = list;
            data.CanUserAddRows = false;
        }

        public static UserList UserListFactory()
        {
            userList = new UserList();
            return userList;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Mapper.GetInstance().Delete(((User)data.SelectedItem).id);
            list.Remove((User)data.SelectedItem);
        }

        private void ViewComment(object sender, RoutedEventArgs e)
        {
            new CommentList(((User)data.SelectedItem).id).ShowDialog();
        }

        private void CommentAction(object sender, RoutedEventArgs e)
        {
            if (MainWindow.user.Role == Roles.全权用户 || MainWindow.user.Role == Roles.可写用户)
            {
                new CommentView(MainWindow.user.id, ((User)data.SelectedItem).id).ShowDialog();
            }
            else
            {
                MessageBox.Show("无权限");
            }
        }


        private void data_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (MainWindow.user.Role == Roles.全权用户)
            {
                Mapper.GetInstance().Update((User)data.SelectedItem);
                MessageBox.Show("更新成功");
            }
            else
            {
                MessageBox.Show("无权限");
            }
        }

        void change(User user)
        {
            if (MainWindow.user.Role == Roles.全权用户)
            {
                Mapper.GetInstance().Update((User)data.SelectedItem);
                MessageBox.Show("更新成功");
            }
            else
            {
                MessageBox.Show("无权限");
            }
        }

        private void data_CellEditEnding(object sender, EventArgs e)
        {
            if (MainWindow.user.Role == Roles.全权用户)
            {
                Mapper.GetInstance().Update((User)data.SelectedItem);
                MessageBox.Show("更新成功");
            }
            else
            {
                MessageBox.Show("无权限");
            }
        }

    }

}

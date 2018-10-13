using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// CommentList.xaml 的交互逻辑
    /// </summary>
    public partial class CommentList : Window
    {
        ObservableCollection<Comment> list;

        public CommentList(Int32 id)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            list = new ObservableCollection<Comment>(Mapper.GetInstance().SelectC(id));
            data.DataContext = list;
            data.CanUserAddRows = false;
        }
    }
}

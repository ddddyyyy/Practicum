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
using System.Windows.Shapes;

namespace AdressBook
{
    public delegate void UserTrans(User user);

    /// <summary>
    /// Comment.xaml 的交互逻辑
    /// </summary>
    public partial class CommentView : Window
    {
        Comment comment;
        

        public CommentView(Int32 uid,Int32 cuid)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            comment = new Comment()
            {
                Uid = uid,
                Cuid = cuid
            };
            
        }

        

        private void Commit(object sender, RoutedEventArgs e)
        {
            comment.Content = Input.Text;
            if (Mapper.GetInstance().Insert(comment))
            {
                MessageBox.Show("评价成功");
            }
            else
            {
                MessageBox.Show("请一小时之后再评价");
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }


}

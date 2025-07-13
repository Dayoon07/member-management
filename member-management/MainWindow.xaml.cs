using member_management.view;
using member_management.Views;
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

namespace member_management
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string id = IdTextBox.Text;
            string password = PasswordTextBox.Text;

            if (id == "admin" && password == "1234")
            {
                MessageBox.Show("로그인 성공!", "메세지", MessageBoxButton.OK, MessageBoxImage.Information);

                MemberList memberList = new MemberList();
                memberList.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다.", "경고", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

}

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
using Microsoft.EntityFrameworkCore;
using Prac.Models;

namespace Prac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            int password = Convert.ToInt32(PasswordTextBox.Password);

            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

                if (user != null)
                {
                    var role = context.Roles.Where(r => r.RoleId == user.RoleId).FirstOrDefault();


                    if (role != null)
                    {
                        if (role.Name == "Администратор")
                        {
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            this.Close();
                        }
                        else if (role.Name == "Клиент")
                        {
                            ClientWindow clientWindow = new ClientWindow();
                            clientWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неизвестная роль пользователя.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Роль пользователя не найдена.");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
            
        }
    }
}
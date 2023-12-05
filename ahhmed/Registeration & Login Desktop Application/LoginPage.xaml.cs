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

namespace Registeration___Login_Desktop_Application
{
 
    public partial class LoginPage : Page
    {
        Registeration_Entities db = new Registeration_Entities();
        user user1 = new user();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignupPage signup = new SignupPage();
            NavigationService.Navigate(signup);
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            var login = db.users.FirstOrDefault(x => x.username == username_txtbox.Text && x.password_ == password_box.Password);
            if (login != null)
            {
                MessageBox.Show("Login completed successfully");

                ProfilePage profile = new ProfilePage(username_txtbox.Text);
                NavigationService.Navigate(profile);
            }



            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void forget_label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ForgetPage forget = new ForgetPage();
            NavigationService.Navigate(forget);
        }
    }
}

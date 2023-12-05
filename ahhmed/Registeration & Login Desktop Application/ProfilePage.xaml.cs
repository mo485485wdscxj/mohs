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
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        Registeration_Entities db = new Registeration_Entities();
        user user1 = new user();

        public ProfilePage()
        {
        }

        public ProfilePage(string name)
        {
            
            InitializeComponent();
            profile_DG.ItemsSource = db.users.Where(x => x.username == name).ToList();
            profile.Content = name + " Profile";
            

        }

        private void logout_button_Click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            NavigationService.Navigate(login);
        }
    }
}

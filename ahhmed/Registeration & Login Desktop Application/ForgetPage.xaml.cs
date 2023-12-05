using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for ForgetPage.xaml
    /// </summary>
    public partial class ForgetPage : Page
    {
        Registeration_Entities db = new Registeration_Entities();
        user user1 = new user();
        
        public ForgetPage()
        {
            InitializeComponent();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {   
            user1 = db.users.FirstOrDefault(x => x.phone_number == phone_number_txtbox.Text);
            if (newPassword_txtbox.Text == confirmPassword_txtbox.Text)
            {
                user1.password_ = newPassword_txtbox.Text;
                db.users.AddOrUpdate(user1);
                db.SaveChanges();

                MessageBox.Show("Password changed successfully!");
            }
            else
            {
                MessageBox.Show("Both fields must be the same");
            }
        }
    }
}

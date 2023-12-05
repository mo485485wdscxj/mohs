using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for SignupPage.xaml
    /// </summary>
    public partial class SignupPage : Page
    {
        Registeration_Entities db = new Registeration_Entities();
        user user1 = new user();
        string gender;
        
        public SignupPage()
        {
            InitializeComponent();

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginPage login = new LoginPage();
            NavigationService.Navigate(login);
        }

        private void male_radio_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Male";
        }

        private void female_radio_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Female";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            city_combox.ItemsSource = user1.city;
        }
        private void Signup_button_Click(object sender, RoutedEventArgs e)
        {
            int city = city_combox.SelectedIndex;
            int age_ = int.Parse(age_txtbox.Text);
            user1.username = username_txtbox.Text;
            user1.gender = gender;
            user1.city = city_combox.Text;

            string[] arr = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", ">", "<", "?" };
            string[] chara = { "a", "b", "c", "d", "e", "f", "g", "h", "l", "i", "j", "k", "l", "m", "n", "q", "r", "s", "t", "u", "v", "x","y","z","s"};
            string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool password_char = false;
            bool password_num = false;
            bool charac = false;

            if (age_ >= 18 && age_ <= 60)
            {
                user1.age = age_;
            }
            else
            {
                age_label.Content = ("age must be between 18 and 60");
            }
            int phone_length = PhoneNumber_txtbox.Text.Length;
            if (phone_length == 11)
            {
                user1.phone_number = PhoneNumber_txtbox.Text;
            }
            else
            {
                phone_label.Content = ("Phone number must be 11 numbers");
            }

            for (int i = 0; i < password_txtbox.Text.Length; i++)
            {
                if (string.IsNullOrEmpty(password_txtbox.Text))
                {
                    MessageBox.Show("Password cannot be empty");
                }
                if (password_txtbox.Text.Contains(arr[i]))
                {
                    password_char = true;
                }


                if (password_txtbox.Text.Contains(num[i]))
                {
                    password_num = true;
                }
                else if (password_txtbox.Text.Contains(chara[i]))
                {
                    charac = true;
                }


            }
            if (password_char == true && password_num == true && charac == true )
            {
                user1.password_ = password_txtbox.Text;

                db.users.Add(user1);
                db.SaveChanges();

                MessageBox.Show("1 user has added successfully");

            }
            else
            {
                MessageBox.Show("Password must containt char and nums and speacial chars and length of password must be > 8");
            }


            ProfilePage pro = new ProfilePage();
            pro.NavigationService.Navigate(pro);



        }



    }
}
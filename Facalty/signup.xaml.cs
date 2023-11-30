using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Facalty
{
    /// <summary>
    /// Interaction logic for signup.xaml
    /// </summary>
    public partial class signup : Page
    {
        FacultyEntities db = new FacultyEntities();
        public signup()
        {
            
        }
        bool isvalid(string pass)
        {
            bool upper, lower, num, sympole;
            upper = lower = num = sympole = false;
            foreach (char c in pass)
            {
                if (!Regex.IsMatch(pass, "[A-Z]"))
                {
                    upper = true;
                }
                else if (!Regex.IsMatch(pass, "[a-z]"))
                {
                    lower = true;
                }
                else if (!Regex.IsMatch(pass, "[1-9]"))
                {
                    num = true;
                }
                else if (!Regex.IsMatch(pass, "[!@#$%^&*_~]"))
                {
                    sympole = true;
                }

            }
            return false;
        }
        bool isvalidMR(string pass)
        {
            bool upper, lower, num, sympole;
            upper = lower = num = sympole = false;
            var sp = "!@#$%^&*_";
            foreach (char c in pass)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    upper = true;
                }
                if (c >= 'a' && c <= 'z')
                {
                    lower = true;
                }
                if (c >= '1' && c <= '9')
                {
                    num = true;
                }
                if (sp.Contains(c))
                {
                    sympole = true;
                }
                else
                {
                    MessageBox.Show("Passsword Is Incorrect");
                }

            }
            return upper && lower && num && sympole;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userapp userapp1 = new userapp();
            userapp1 = db.userapps.FirstOrDefault(x => x.userapp_username == usernameboxsign.Text);
            if (isvalidMR(passwordsign.Text))
            {
                if (userapp1 != null)
                {
                    userapp1.userapp_password = passwordsign.Text;
                    db.userapps.AddOrUpdate(userapp1);
                    db.SaveChanges();
                    login page = new login();
                    this.NavigationService.Navigate(page);
                }
            }
            
        }
    }
}

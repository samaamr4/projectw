using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        FacultyEntities db = new FacultyEntities();
        public login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Forget page=new Forget();
            this.NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            signup page1= new signup();
            this.NavigationService.Navigate(page1);
        }
        bool isvalid(string pass)
        {
            bool upper, lower, num, sympole;
            upper=lower= num=sympole=false;
            foreach(char c in pass)
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
                if (c>='A'&&c<='Z')
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
            return upper&&lower&&num&&sympole;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (comdo.Text == "Admin")
            {
                adminss adm = new adminss();
                adm = db.adminsses.FirstOrDefault(x => x.admin_password == passwordbox.Text && x.admin_username==usernamebox.Text);
                if(adm!=null )
                {
                    admin page=new admin();
                    this.NavigationService.Navigate(page); 
                }
                else
                {
                    MessageBox.Show("Admin Not Found");
                }
            }
            else if(comdo.Text == "User")
            {
                userapp userapp = new userapp();
                userapp = db.userapps.FirstOrDefault(x => x.userapp_password == passwordbox.Text&& x.userapp_username == usernamebox.Text);
                if (userapp!=null )
                {
                    user page=new user();
                    this.NavigationService.Navigate(page);
                }
                else
                {
                    MessageBox.Show("User Not Found");
                }
            }
            else
            {
                MessageBox.Show("Choode Type");
            }
        }
    }
}

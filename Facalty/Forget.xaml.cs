using System;
using System.Collections.Generic;
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

namespace Facalty
{
    /// <summary>
    /// Interaction logic for Forget.xaml
    /// </summary>
    public partial class Forget : Page
    {
        FacultyEntities db = new FacultyEntities();
        public Forget()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sign = db.userapps.Where(x => x.userapp_username == usernameboxsign.Text);
            if(sign!=null)
            {
                userapp tablee = new userapp();
                tablee.userapp_password = confirmpasswordsign.Text;
                db.userapps.AddOrUpdate(tablee);
                db.SaveChanges();
                signup page = new signup();
                this.NavigationService.Navigate(page);
            }
            else
            {
                MessageBox.Show("Errorr Login");
            }
        }
    }
}

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

namespace Facalty
{
    /// <summary>
    /// Interaction logic for user.xaml
    /// </summary>
    public partial class user : Page
    {
        FacultyEntities db =new FacultyEntities();
        public user()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user tablee = new user();
            tablee.user_names = usernamebox.Text;
            tablee.user_age = int.Parse(age.Text);
            tablee.user_add=adderss.Text;
            tablee.date_description=depcompo.Text;
            db.users.Add(tablee);
            db.SaveChanges();
            MessageBox.Show("Data Saved Sucessfully");
        }
    }
}

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
    /// Interaction logic for admin.xaml
    /// </summary>
    public partial class admin : Page
    {
        FacultyEntities db = new FacultyEntities();
        public admin()
        {
            InitializeComponent();
            dgrid.ItemsSource = db.users.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dgrid.ItemsSource=db.users.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            user nes = new user();
            var ids= int.Parse(idtextbox.Text);
            nes = db.users.First(x => x.user_ids == ids);
            if (nes != null)
            {
                nes.date_description = department.Text;
                db.users.AddOrUpdate(nes);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("User Not Found");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var ids = int.Parse(idtextbox.Text);
            var updt = db.users.First(x => x.user_ids == ids);
            db.users.Remove(updt);
            db.SaveChanges();
            MessageBox.Show("User Deleted Sucessfully");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(com.Text== "Department")
            {
                dgrid.ItemsSource=db.users.Where(x=>x.date_description==search.Text).ToList();
                db.SaveChanges();
            }
            else if (com.Text == "id")
            {
                dgrid.ItemsSource = db.users.Where(x => x.user_ids ==int.Parse( search.Text)).ToList();
                db.SaveChanges();
            }
            else if(com.Text == "Name")
            {
                dgrid.ItemsSource = db.users.Where(x => x.user_names == search.Text).ToList();
                db.SaveChanges();
            }
            else if (com.Text == "Age")
            {
                dgrid.ItemsSource = db.users.Where(x => x.user_age ==int.Parse( search.Text)).ToList();
                db.SaveChanges();

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
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
using System.Xml.Linq;
using pr_3.pages;
using pr_3.models;
using System.Net.Mail;
namespace pr_3.pages
{
    /// <summary>
    /// Логика взаимодействия для NewPass.xaml
    /// </summary>
    public partial class NewPass : Page
    {
        private User currentUser;
        public NewPass(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }
      
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string pass = HashPasswords.HashPasswords.Hash(tbxPass.Text.Replace("\"", ""));
            if (!String.IsNullOrEmpty(pass))
                SaveUser(pass);
            else
                MessageBox.Show("Введите данные");
        }
        private void SaveUser(string pass)
        {
            var dbContext = new PhotooStudiiioooEntities2();
            currentUser.user_password = pass;

            dbContext.User.AddOrUpdate(currentUser);
            dbContext.SaveChanges();
            MessageBox.Show("Обновлено");
            NavigationService.Navigate(new Autho());
        }

       
    }
}

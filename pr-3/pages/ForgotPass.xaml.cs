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
using pr_3.pages;
using pr_3.models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Net.Mail;


namespace pr_3.pages
{
    /// <summary>
    /// Логика взаимодействия для ForgotPass.xaml
    /// </summary>
    public partial class ForgotPass : Page
    {
        PhotooStudiiioooEntities2 dbContext = new PhotooStudiiioooEntities2();
        User user = new User();
        private string code;
        public ForgotPass()
        {
            InitializeComponent();

        }

        private void btncheck_Click(object sender, RoutedEventArgs e) //проверка почты существет ли она
        {
            

        }

        private void btncheck1_Click(object sender, RoutedEventArgs e) //проверка введенного кода с генерированным 
        {
            if (code == tbxCode.Text.Trim())
                NavigationService.Navigate(new NewPass(user));
            else
                MessageBox.Show("неверный код");
        }

       
       
    }
}


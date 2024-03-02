using pr_3.models;
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

namespace pr_3.pages
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        private User currentUser;
        public Client(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            LabelText();
        }

        private void LabelText()
        {
            fio.Content = $"{TimeOfDay()}! \n{Gender()} {currentUser.surname} {currentUser.name} {currentUser?.otchestvo}";
        }

        private string Gender()
        {
            int? gender = currentUser.GenderId;
            if (gender == 1)
                return "Mr";
            if (gender == 2)
                return "Mrs";  
            return " ";
        }
        private string TimeOfDay()
        {
            var currentTime = DateTime.Now;
            if (currentTime.Hour >= 10 && currentTime.Hour <= 12) return "Доброе утро";
            if (currentTime.Hour >= 12 && currentTime.Hour <= 17) return "Добрый день";
            if (currentTime.Hour >= 17 && currentTime.Hour <= 19) return "Добрый вечер";
            return "Добро пожаловать";
        }
    }
}

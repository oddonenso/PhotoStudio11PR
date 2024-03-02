using pr_3.models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace pr_3.pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxLogin.Text;
            string password = HashPasswords.HashPasswords.Hash(tbxPassword.Text.Replace("\"", ""));
            string name = tbxName.Text;
            string surname = tbxSurname.Text;
            string phone = tbxPhone.Text;
            string otchestvo = tbxOtchestvo.Text;
            int role = Convert.ToInt32(tbxRole.Text); // Преобразование строки в число
            string email = tbxEmail.Text;

            if (!String.IsNullOrEmpty(phone) && !String.IsNullOrEmpty(surname) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                if (tbxPassword.Text.Length >= 6)
                {
                    if (phone.Length == 18)
                    {
                        if (!CheckUserLoginExists(login))
                        {
                            SaveUser(login, password, name, surname, phone, otchestvo, role, email);
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Номер телефона должен иметь формат +9 (999) 999-99-99");
                    }
                }
                else
                {
                    MessageBox.Show("Пароль должен иметь длину не менее 6 символов");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите данные");
            }
        }

        private void SaveUser(string login, string password, string name, string surname, string phone, string otchestvo, int role, string email)
        {
            using (var dbContext = new PhotooStudiiioooEntities2())
            {
                var user = new User();
                user.userlogin = login;
                user.user_password = password;
                user.name = name;
                user.surname = surname;
                user.phone_number = phone;
                user.otchestvo = otchestvo;
                user.role_id = role;
                user.email = email;

                dbContext.User.Add(user);
                dbContext.SaveChanges();
                MessageBox.Show("Пользователь успешно зарегистрирован");
            }
        }

        private bool CheckUserLoginExists(string login)
        {
            /// <summary>
            /// Метод для проверки пользователя
            /// </summary>
            using (var dbContext = new PhotooStudiiioooEntities2())
            {
                //Через Linq запрос проверяется уникален ли Login или нет
                return dbContext.User.Any(p => p.userlogin == login);
            }
        }
    }
}
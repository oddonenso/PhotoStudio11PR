using pr_3.models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace pr_3.pages
{
    public partial class Verification : Page
    {
        PhotooStudiiioooEntities2 dbContext = new PhotooStudiiioooEntities2();
        User user = new User();
        private string code;
        private string userEmail;

        public Verification(string userEmail)
        {
            InitializeComponent();
            this.userEmail = userEmail;
            SendVerificationCode(userEmail);
        }

        private void SendVerificationCode(string userEmail)
        {
            try
            {
                user = dbContext.User.Where(p => p.email == userEmail).FirstOrDefault();
                if (user != null)
                {
                    code = GenerateCode();
                    EmailSend(userEmail, code);
                   // codeemail.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отправке кода подтверждения: " + ex.Message);
            }
        }

        private void EmailSend(string email, string code)
        {
            MailMessage message = new MailMessage("oddoneoddonov@gmail.com", email, "Код подтверждения", "Ваш код подтверждения: " + code);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("oddoneoddonov@gmail.com", "siuj xxkp hquy uhcp");
            client.EnableSsl = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отправке почты: " + ex.Message);
            }
        }

        private string GenerateCode()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btncheck1_Click(object sender, RoutedEventArgs e)
        {
            string enteredCode = tbxAunt.Text.Trim();

            if (enteredCode == code)
            {
                LoadForm(user.role_id.ToString());
            }
            else
            {
                MessageBox.Show("Неверный код подтверждения", "Ошибка");
            }
        }

        private void LoadForm(string _role)
        {
            switch (_role)
            {
                case "1":
                    NavigationService.Navigate(new Client(user));
                    break;
                case "2":
                    NavigationService.Navigate(new Admin(user));
                    break;
                case "3":
                    if (TimeWork())
                    {
                        NavigationService.Navigate(new Employee(user));
                    }
                    else
                    {
                        MessageBox.Show("Рабочий день закончен или еще не начался", "Предупреждение");
                    }
                    break;
            }
        }

        private bool TimeWork()
        {
            var currentTime = DateTime.Now;
            if (currentTime.Hour < 10 || currentTime.Hour > 19)
                return false;
            return true;
        }

        private void btncheck_Click(object sender, RoutedEventArgs e)
        {
            string enteredCode = tbxAunt.Text.Trim();

            if (enteredCode == code)
            {
                LoadForm(user.role_id.ToString());
            }
            else
            {
                MessageBox.Show("Неверный код подтверждения", "Ошибка");
            }
        }
    }
}

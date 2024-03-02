using pr_3.models;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private User currentUser;
        private PhotooStudiiioooEntities2 context = new PhotooStudiiioooEntities2();

        public Admin(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            var ppl = context.User.ToList();
            LViewPpl.ItemsSource = ppl;

            //ImageUsers = LoadImageFromBytes(currentUser.Image);

        }
        private BitmapImage LoadImageFromBytes(byte[] imageData)
        {
            BitmapImage image = new BitmapImage();

            try
            {
                using (MemoryStream stream = new MemoryStream(imageData))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                    image.Freeze(); // Freeze the image to prevent memory leaks
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }

            return image;
        }

        private void Selector_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedUser = (User)LViewPpl.SelectedItem;

            // Check if a user is selected:
            if (selectedUser != null)
            {
                // Navigate to the Redact page with the selected user:
                NavigationService.Navigate(new Redact(selectedUser));
            }
            else
            {
                // Handle the case where no user is selected:
                MessageBox.Show("Please select a user to edit.");
            }
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            /// <summary>
            /// В данном куске кода реализован обработчик 
            /// события изменения текста в текстовом поле txtSearch.
            /// </summary>
            string searchText = txtSearch.Text;
           // 1.Получается текст из текстового поля txtSearch.
            if (searchText.Length == 0)
            {
                var ppl = context.User.ToList();
                LViewPpl.ItemsSource = ppl;
            }
            // 2. Если длина текста равна 0, то загружается
            // список всех пользователей из базы данных и отображается в элементе управления LViewPpl.
            else
            {
                if (cmbSorting.SelectedIndex == 0)//по возр
                {
                    // 3. Если длина текста больше 0,
                    // то в зависимости от выбранного фильтра
                    // (cmbFilter) и сортировки (cmbSorting) выполняются следующие действия:
                    switch (cmbFilter.SelectedIndex)
                    {
                        // Должность
                        case 0:
                            var filteredAndSortedPpl = context.User
                                .Where(u => u.Role.name_role.Contains(searchText)) 
                                .OrderBy(u => u.Role.name_role)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl;
                            break;

                        // Фамилия
                        case 1:
                            var filteredAndSortedPpl1 = context.User.Where(u => u.surname.Contains(searchText))
                                .OrderBy(u => u.surname)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl1;
                            break;
                        // Имя
                        case 2:
                            var filteredAndSortedPpl2 = context.User.Where(u => u.name.Contains(searchText))
                                .OrderBy(u => u.name)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl2;
                            break;
                        // Отчество
                        case 3:
                            var filteredAndSortedPpl3 = context.User.Where(u => u.otchestvo.Contains(searchText))
                                .OrderBy(u => u.otchestvo)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl3;
                            break;
                            // Код выполняет фильтрацию
                            // и сортировку списка пользователей
                            // в зависимости от введенного текста и выбранных параметров.
                    }
                }
                if (cmbSorting.SelectedIndex == 1)//по убыв
                {
                    switch (cmbFilter.SelectedIndex)
                    {
                        // Должность
                        case 0:
                            var filteredAndSortedPpl = context.User
                                .Where(u => u.Role.name_role.Contains(searchText)) // Assuming RoleName is the property for role names
                                .OrderByDescending(u => u.Role.name_role)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl;
                            break;

                        // Фамилия
                        case 1:
                            var filteredAndSortedPpl1 = context.User.Where(u => u.surname.Contains(searchText))
                                .OrderByDescending(u => u.surname)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl1;
                            break;
                        // Имя
                        case 2:
                            var filteredAndSortedPpl2 = context.User.Where(u => u.name.Contains(searchText))
                                .OrderByDescending(u => u.name)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl2;
                            break;
                        // Отчество
                        case 3:
                            var filteredAndSortedPpl3 = context.User.Where(u => u.otchestvo.Contains(searchText))
                                .OrderByDescending(u => u.otchestvo)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl3;
                            break;
                    }
                }
            }
        }

        private void LViewPpl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Invite invite = new Invite();

            // Navigate to the Redact page
            NavigationService.Navigate(invite);
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

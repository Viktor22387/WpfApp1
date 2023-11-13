using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace UserInformationApp
{
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text
            };

            users.Add(newUser);
            UpdateUserListBox();
            ClearInputFields();
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (userListBox.SelectedIndex != -1)
            {
                User selectedUser = users[userListBox.SelectedIndex];
                tbFirstName.Text = selectedUser.FirstName;
                tbLastName.Text = selectedUser.LastName;
                tbEmail.Text = selectedUser.Email;
                tbPhone.Text = selectedUser.Phone;
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (userListBox.SelectedIndex != -1)
            {
                users.RemoveAt(userListBox.SelectedIndex);
                UpdateUserListBox();
                ClearInputFields();
            }
        }

        private void ExportTextButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines("users.txt", users.ConvertAll(user => user.ToString()));
            MessageBox.Show("Информация о пользователях экспортирована в текстовый файл.", "Экспорт", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ImportTextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines("users.txt");
                users.Clear();

                foreach (string line in lines)
                {
                    string[] userInfo = line.Split('|');
                    if (userInfo.Length == 4)
                    {
                        User importedUser = new User
                        {
                            FirstName = userInfo[0].Trim(),
                            LastName = userInfo[1].Trim(),
                            Email = userInfo[2].Trim(),
                            Phone = userInfo[3].Trim()
                        };

                        users.Add(importedUser);
                    }
                }

                UpdateUserListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при импорте: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportXmlButton_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            using (TextWriter writer = new StreamWriter("users.xml"))
            {
                xmlSerializer.Serialize(writer, users);
            }

            MessageBox.Show("Информация о пользователях экспортирована в XML файл.", "Экспорт", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ImportXmlButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
                using (TextReader reader = new StreamReader("users.xml"))
                {
                    users = (List<User>)xmlSerializer.Deserialize(reader);
                }

                UpdateUserListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при импорте: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateUserListBox()
        {
            userListBox.Items.Clear();
            userListBox.Items.AddRange(users.ToArray());
        }

        private void ClearInputFields()
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            tbEmail.Clear();
            tbPhone.Clear();
        }
    }
}

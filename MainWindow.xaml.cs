using System;
using System.IO;
using System.Windows;

namespace PersonalInfoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем введенные данные
            string lastName = LastNameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string patronymic = PatronymicTextBox.Text;
            string gender = GenderComboBox.Text;
            DateTime birthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue;
            string maritalStatus = MaritalStatusComboBox.Text;

            // Создаем строку для записи в файл
            string dataToSave = $"Фамилия: {lastName}\nИмя: {firstName}\nОтчество: {patronymic}\nПол: {gender}\nДата рождения: {birthDate}\nСемейный статус: {maritalStatus}";

            // Сохраняем в файл
            SaveToFile(dataToSave);
        }

        private void SaveToFile(string data)
        {
            try
            {
                string filePath = "PersonalInfo.txt";

                // Записываем данные в файл или создаем новый файл
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.Write(data);
                }

                MessageBox.Show("Информация успешно сохранена в файл.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

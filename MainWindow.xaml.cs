using System;
using System.Windows;

namespace BirthdayCalendarApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(BirthdayTextBox.Text, out DateTime birthday))
            {
                BirthdayCalendar.SelectedDate = birthday;
            }
            else
            {
                MessageBox.Show("Некорректный формат даты. Используйте формат дд.мм.гггг.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

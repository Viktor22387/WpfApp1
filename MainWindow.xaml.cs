using System;
using System.Windows;

namespace DateDifferenceApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = EndDatePicker.SelectedDate ?? DateTime.MinValue;

            if (startDate != DateTime.MinValue && endDate != DateTime.MinValue)
            {
                TimeSpan difference = endDate - startDate;
                int daysDifference = (int)difference.TotalDays;

                ResultLabel.Content = $"Разница в днях: {daysDifference}";
            }
            else
            {
                ResultLabel.Content = "Выберите обе даты для подсчета разницы.";
            }
        }
    }
}

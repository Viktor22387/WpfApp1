using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TextReaderApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReadTextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = "sample.txt";
                string text = File.ReadAllText(filePath);

                progressBar.Value = 1;

                MessageBox.Show("Текст успешно прочитан из файла!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

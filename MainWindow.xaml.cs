using System;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(Rectangle);

            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                MessageBox.Show("Application is closing because Ctrl key was pressed.", "Closing", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else if (point.X >= 0 && point.X <= Rectangle.ActualWidth && point.Y >= 0 && point.Y <= Rectangle.ActualHeight)
            {
                MessageBox.Show($"The point is inside the rectangle at coordinates ({point.X}, {point.Y}).", "Inside Rectangle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (point.X < 0 || point.X > Rectangle.ActualWidth || point.Y < 0 || point.Y > Rectangle.ActualHeight)
            {
                MessageBox.Show($"The point is outside the rectangle at coordinates ({point.X}, {point.Y}).", "Outside Rectangle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("The point is on the border of the rectangle.", "On Border", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Rectangle_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Width = {Width}, Height = {Height}", "Client Area Size", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(this);
            Title = $"Mouse Coordinates: X = {point.X}, Y = {point.Y}";
        }
    }
}

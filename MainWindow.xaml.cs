using System;
using System.Windows;

namespace SimpleWpfResume
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowResumeButton_Click(object sender, RoutedEventArgs e)
        {
            ShowResume();
        }

        private void ShowResume()
        {
            string resume = "My name is Viktor. I am a student. ";
            resume += "I have experience with programming languages such as C# and C++. ";
            resume += "I can develop applications using WPF technology.";

            MessageBox.Show(resume, "Resume - Part 1", MessageBoxButton.OK);

            resume += " I also have skills in working with databases, particularly SQL Server and MySQL. ";
            resume += "I understand the basics of algorithms and data structures. ";
            resume += "I am ready to learn new technologies and continuously grow professionally.";

            MessageBox.Show(resume, "Resume - Part 2", MessageBoxButton.OK);

            resume += " I have teamwork skills, as well as experience in problem-solving and finding effective solutions. ";
            resume += "I am ready to work in a dynamic environment and tackle challenging tasks.";

            MessageBox.Show(resume, "Resume - Part 3", MessageBoxButton.OK);

            int averageCharacters = resume.Length / 3;

            MessageBox.Show($"Average number of characters per page: {averageCharacters}", "Statistics", MessageBoxButton.OK);
        }
    }
}

using System;
using System.Windows;

namespace NumberGuessingGame
{
    public partial class MainWindow : Window
    {
        private int targetNumber;
        private int attempts;

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            Random random = new Random();
            targetNumber = random.Next(1, 2001);
            attempts = 0;
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            GuessNumber();
        }

        private void GuessNumber()
        {
            int userGuess;
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your guess (a number from 1 to 2000):", "Guess the Number");

            if (int.TryParse(input, out userGuess))
            {
                attempts++;

                if (userGuess == targetNumber)
                {
                    MessageBox.Show($"Congratulations! You guessed the number {targetNumber} in {attempts} attempts.", "Victory!", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (MessageBox.Show("Want to play again?", "New Game", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        StartNewGame();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    string message = userGuess < targetNumber ? "Higher!" : "Lower!";
                    MessageBox.Show(message, "Try again", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            { 
                MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PassGenVer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }
        private bool ValidatePasswordUpperLetter(string password, out string ErrorMessage)
        {

            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }


            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");


            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidatePasswordNumber(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasLowerChar = new Regex(@"[a-z]+");


            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool ValidatePasswordSymbols(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                display.Content = "Password should not be empty";
            }
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void verify_Click(object sender, RoutedEventArgs e)
        {
            string error;
            switch (returnSituation())
            {
                case 1:
                    if (ValidatePasswordUpperLetter(pwdBox.Text, out error))
                    {
                        display.Content = "Valid Password";
                    }
                    else
                    {
                        display.Content = error;

                    }
                    break;
                case 2:
                    if (ValidatePasswordSymbols(pwdBox.Text, out error))
                    {
                        display.Content = "Valid Password";
                    }
                    else
                    {
                        display.Content = error;
                    }
                    break;
                case 3:
                    if (ValidatePasswordNumber(pwdBox.Text, out error))
                    {
                        display.Content = "Valid Password";
                    }
                    else
                    {
                        display.Content = error;
                    }
                    break;
                case 4:
                    if (ValidatePasswordNumber(pwdBox.Text, out error) && ValidatePasswordUpperLetter(pwdBox.Text, out error))
                    {
                        display.Content = "Valid Password";
                    }
                    else
                    {
                        display.Content = error;
                    }
                    break;
                case 5:
                    if (ValidatePasswordNumber(pwdBox.Text, out error) && ValidatePasswordSymbols(pwdBox.Text, out error))
                    {
                        display.Content = "Valid Password";
                    }
                    else
                    {
                        display.Content = error;
                    }
                    break;
                case 6:
                    if (ValidatePasswordUpperLetter(pwdBox.Text, out error) && ValidatePasswordSymbols(pwdBox.Text, out error))
                    {
                        display.Content = "Valid Password";
                    }
                    else
                    {
                        display.Content = error;
                    }
                    break;
                case 7:
                    if (ValidatePasswordUpperLetter(pwdBox.Text, out error) && ValidatePasswordSymbols(pwdBox.Text, out error) && ValidatePasswordNumber(pwdBox.Text, out error))
                    {
                        display.Content = "Valid Password";
                    }
                    else
                    {
                        display.Content = error;
                    }
                    break;
                default:
                    display.Content = "Choose Something";
                    break;
            }
        }
        public int returnSituation() {
            if ((bool)lettersCheck.IsChecked && !(bool)specialCheck.IsChecked && !(bool)numbersCheck.IsChecked)
            {
                return 1;
            }
            else if (!(bool)lettersCheck.IsChecked && (bool)specialCheck.IsChecked && !(bool)numbersCheck.IsChecked)
            {
                return 2;
            }
            else if (!(bool)lettersCheck.IsChecked && !(bool)specialCheck.IsChecked && (bool)numbersCheck.IsChecked)
            {
                return 3;
            }
            else if ((bool)lettersCheck.IsChecked && !(bool)specialCheck.IsChecked && (bool)numbersCheck.IsChecked)
            {
                return 4;
            }
            else if (!(bool)lettersCheck.IsChecked && (bool)specialCheck.IsChecked && (bool)numbersCheck.IsChecked)
            {
                return 5;
            }
            else if ((bool)lettersCheck.IsChecked && (bool)specialCheck.IsChecked && !(bool)numbersCheck.IsChecked)
            {
                return 6;
            }
            else if ((bool)lettersCheck.IsChecked && (bool)specialCheck.IsChecked && (bool)numbersCheck.IsChecked)
            {
                return 7;
            }

            return 0;
        }

        private string getFile(int variable)
        {
            switch (variable)
            {
                case 1:
                    string upper = "upper.txt";
                    return upper;
                case 2:
                    string symbols = "symbols.txt";
                    return symbols;
                case 3:
                    string numbers = "numbers.txt";
                    return numbers;
                case 4:
                    string numbersUpper = "numbersUpper.txt";
                    return numbersUpper;
                case 5:
                    string numbersSymbols = "numbersSymbols.txt";
                    return numbersSymbols;
                case 6:
                    string upperSymbols = "upperSymbols.txt";
                    return upperSymbols;
                case 7:
                    string all = "all.txt";
                    return all;
                default:
                    return null;
            }
        }

        private void generate_Click(object sender, RoutedEventArgs e)
        {
            if (returnSituation() == 0)
            {
                pwdGen.Content = "You must choose an Option to Generate Password!!!";
            }
            else
            {
                string filename = getFile(returnSituation());
                var file = File.ReadLines(filename).ToList();
                int count = file.Count();
                Random rnd = new Random();
                int skip = rnd.Next(0, count);
                string line = file.Skip(skip).First();
                pwdGen.Content = line;
            }
        }
    }
}

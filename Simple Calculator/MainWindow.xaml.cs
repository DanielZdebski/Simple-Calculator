using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simple_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;
            
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber)) 
            {
                switch (selectedOperator)
                { 
                    case SelectedOperator.Addition:
                        result = SupportClasses.SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substruction:
                        result = SupportClasses.SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SupportClasses.SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        if (SupportClasses.SimpleMath.Divide(lastNumber, newNumber, out result) == 999)
                        {
                            MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);    
                        }
                        break;
                    default:
                        break;
                }

                resultLabel.Content = $"{result}";
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse( ((Button)sender).Content.ToString() );       // alternative to (Button)sender is (sender as Button)

/*         ((Button)sender).Content
            if (sender == zeroButton)
                selectedValue = 0;
            else if (sender == oneButton)
                selectedValue = 1;
            else if (sender == twoButton)
                selectedValue = 2;
            else if (sender == threeButton)
                selectedValue = 3;
            else if (sender == fourButton)
                selectedValue = 4;
            else if (sender == fiveButton)
                selectedValue = 5;
            else if (sender == sixButton)
                selectedValue = 6;
            else if (sender == sevenButton)
                selectedValue = 7;
            else if (sender == eightButton)
                selectedValue = 8;
            else if (sender == nineButton)
                selectedValue = 9;
*/

            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = $"{selectedValue}";
            else
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";      
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
                resultLabel.Content = 0;

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            else if (sender == divideButton)
                selectedOperator = SelectedOperator.Division;
            else if (sender == minusButton)
                selectedOperator = SelectedOperator.Substruction;
            else if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;

        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                // Do nothing
            }

            resultLabel.Content = $"{resultLabel.Content}.";
        }

        public enum SelectedOperator 
        {
            Addition,
            Substruction,
            Multiplication,
            Division
        }
    }
}
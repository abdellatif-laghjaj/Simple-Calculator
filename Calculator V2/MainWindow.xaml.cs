using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Data;

namespace Calculator_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1 = 0;
        double num2 = 0;
        string operation = "";

        public MainWindow()
        {
            InitializeComponent();
            displayTextBox.Text = "";
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

            string text = (sender as Button).Content.ToString();
            if(operation != "")
            {
                //num1 = (num1 * 10) + text;
                displayTextBox.Text += (sender as Button).Content.ToString();
            }
            else
            {
                //num2 = (num2 * 10) + text;
                displayTextBox.Text += (sender as Button).Content.ToString();
            }
        }

        private void operationBtn_Click(object sender, RoutedEventArgs e)
        {
            operation = (sender as Button).Content.ToString();

            switch (operation)
            {
                case "×":
                    displayTextBox.Text += "*";
                    break;

                case "÷":
                    displayTextBox.Text += "/";
                    break;
                default:
                    displayTextBox.Text += operation;
                    break;
            }
        }

        private void equalBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = displayTextBox.Text;
                displayTextBox.Text = Evaluate(result).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }



        static double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            displayTextBox.Text = "";
        }

        private void backSpaceBtn_Click(object sender, RoutedEventArgs e)
        {
            string input = displayTextBox.Text.ToString();
            string newValue = input.Substring(0, input.Length - 1);
            displayTextBox.Text = newValue;
        }
    }
}

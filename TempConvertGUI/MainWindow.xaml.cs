using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace TempConvertGUI
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

        string getText()
        {
            return lbl1.Content.ToString();
        }

        double convertToCelsius(double temp)
        {
            double celsius = (temp - 32) * 5 / 9;
            return celsius;
        }

        double convertToFahrenheit(double temp)
        {
            double fahrenheit = (temp * 1.8) + 32;
            return fahrenheit;
        }

        void Reset()
        {
            txtbox1.Text = "";
            txtbox2.Text = "";
        }

        void doSwap()
        {
            if(getText() == "Celsius")
            {
                lbl1.Content = "Fahrenheit";
                lblIcon1.Content = "°F";
                lbl2.Content = "Celsius";
                lblIcon2.Content = "°C";

                if (txtbox1.Text != null)
                {
                    string tempString = txtbox1.Text;
                    txtbox1.Text = txtbox2.Text;
                    txtbox2.Text = tempString;
                }
            }
            else
            {
                lbl1.Content = "Celsius";
                lblIcon1.Content = "°C";
                lbl2.Content = "Fahrenheit";
                lblIcon2.Content = "°F";

                if (txtbox1.Text != null)
                {
                    string tempString = txtbox1.Text;
                    txtbox1.Text = txtbox2.Text;
                    txtbox2.Text = tempString;
                }
            }


        }

        private void btnSwap_Click(object sender, RoutedEventArgs e)
        {
            doSwap();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox1.Text == "")
            {
                MessageBox.Show("Entrez une valeur valide et Réessayer!");
            }
            else
            {
                double inputTemp = double.Parse(txtbox1.Text);

                switch (getText())
                {
                    case "Celsius":
                        double convertedTemp = Math.Round(convertToFahrenheit(inputTemp), 2);
                        txtbox2.Text = convertedTemp.ToString();
                        break;
                    case "Fahrenheit":
                        convertedTemp = Math.Round(convertToCelsius(inputTemp), 2);
                        txtbox2.Text = convertedTemp.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void IsInputNumeric(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}

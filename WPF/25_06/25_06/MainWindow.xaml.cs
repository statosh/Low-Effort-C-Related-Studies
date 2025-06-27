using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _25_06 {
    public partial class MainWindow : Window {
        private string digitA;
        private string digitB;
        private string simbol;
        private bool isResultShown = false;

        public MainWindow() {
            InitializeComponent();
            digitA = null;
            digitB = null;
            simbol = null;
        }

        private void Button_click(object sender, RoutedEventArgs e) {
            Button click = (Button)sender;
            string content = (string)click.Content;

            if (click.Background != Brushes.LightGray) { 
                if (isResultShown) {
                    digitA = null;
                    digitB = null;
                    simbol = null;
                    isResultShown = false;
                    Digits.Text = "";
                }

                if (content == "+/-") { 
                    if (simbol == null) {
                        if (!string.IsNullOrEmpty(digitA)) {
                            if (digitA.StartsWith("-")) digitA = digitA.Substring(1);
                            else digitA = "-" + digitA;
                            Digits.Text = digitA;
                        }
                    } else {
                        if (!string.IsNullOrEmpty(digitB)) {
                            if (digitB.StartsWith("-")) digitB = digitB.Substring(1);
                            else digitB = "-" + digitB;
                            Digits.Text = digitB;
                        }
                    }
                } else if (content == ",") { 
                    if (simbol == null) {
                        if (string.IsNullOrEmpty(digitA)) digitA = "0,";
                        else if (!digitA.Contains(",")) digitA += ",";
                        Digits.Text = digitA;
                    } else {
                        if (string.IsNullOrEmpty(digitB)) digitB = "0,";
                        else if (!digitB.Contains(",")) digitB += ",";
                        Digits.Text = digitB;
                    }
                } else {
                    if (simbol == null) {
                        digitA += content;
                        Digits.Text = digitA;
                    } else {
                        digitB += content;
                        Digits.Text = digitB;
                    }
                }

            } else {
                switch (content) {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "%":
                        simbol = content;
                        break;

                    case "=":
                        if (digitA != null && digitB != null && simbol != null) {
                            Calculate();
                        }
                        break;

                    case "CE":
                        digitA = null;
                        digitB = null;
                        simbol = null;
                        Digits.Text = "";
                        break;

                    case "C":
                        if (simbol == null) {
                            digitA = null;
                            Digits.Text = "";
                        } else {
                            digitB = null;
                            Digits.Text = "";
                        }
                        break;

                    case "1/X":
                        if (simbol == null && !string.IsNullOrEmpty(digitA)) {
                            double num = Convert.ToDouble(digitA);
                            if (num == 0) {
                                MessageBox.Show("Деление на ноль");
                            } else {
                                digitA = (1 / num).ToString();
                                Digits.Text = digitA;
                                isResultShown = true;
                            }
                        }
                        break;

                    case "X^2":
                        if (simbol == null && !string.IsNullOrEmpty(digitA)) {
                            double num = Convert.ToDouble(digitA);
                            digitA = Math.Pow(num, 2).ToString();
                            Digits.Text = digitA;
                            isResultShown = true;
                        }
                        break;

                    case "x^(1/2)":
                        if (simbol == null && !string.IsNullOrEmpty(digitA)) {
                            double num = Convert.ToDouble(digitA);
                            if (num < 0) {
                                MessageBox.Show("Корень из отрицательного числа");
                            } else {
                                digitA = Math.Sqrt(num).ToString();
                                Digits.Text = digitA;
                                isResultShown = true;
                            }
                        }
                        break;
                }
            }
        }

        private void Calculate() {
            try {
                double a = Convert.ToDouble(digitA);
                double b = Convert.ToDouble(digitB);
                double result = 0;

                switch (simbol) {
                    case "+":
                        result = a + b;
                        break;
                    case "-":
                        result = a - b;
                        break;
                    case "*":
                        result = a * b;
                        break;
                    case "/":
                        if (b == 0) {
                            MessageBox.Show("Деление на ноль");
                            return;
                        }
                        result = a / b;
                        break;
                    case "%":
                        result = a % b;
                        break;
                }

                digitA = result.ToString();
                Digits.Text = digitA;
                digitB = null;
                simbol = null;
                isResultShown = true;
            } catch (Exception ex) {
                MessageBox.Show("Ошибка вычисления: " + ex.Message);
            }
        }
    }
}

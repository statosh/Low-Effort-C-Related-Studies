using System.Windows;
using System.Windows.Controls;

namespace WpfControlsDemo {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            if (sender is RadioButton rb) {
                ResultLabel.Content = $"Вы выбрали: {rb.Content}";
            }
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e) {
            string options = "Выбраны опции: ";

            if (OptionACheckBox.IsChecked == true) options += "A ";
            if (OptionBCheckBox.IsChecked == true) options += "B ";
            if (OptionCCheckBox.IsChecked == true) options += "C ";

            if (options == "Выбраны опции: ") options = "Опции не выбраны";

            ResultLabel.Content = options;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e) {
            Variant1RadioButton.IsChecked = false;
            Variant2RadioButton.IsChecked = false;
            Variant3RadioButton.IsChecked = false;

            OptionACheckBox.IsChecked = false;
            OptionBCheckBox.IsChecked = false;
            OptionCCheckBox.IsChecked = false;

            ResultLabel.Content = "Сброс выполнен";
        }
    }
}

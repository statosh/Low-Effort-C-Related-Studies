using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDataBindingDemo {
    public partial class MainWindow : Window {
        public string FirstName { get; set; } = "Иван";
        public string LastName { get; set; } = "Петров";

        public MainWindow() {
            InitializeComponent();
            DataContext = this;
        }

        private void BackgroundColorCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (BackgroundColorCombo.SelectedItem is ComboBoxItem item) {
                string color = item.Content.ToString();
                this.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
            }
        }

        private void ThemeToggle_Checked(object sender, RoutedEventArgs e) {
            this.Background = Brushes.DarkGray;
        }

        private void ThemeToggle_Unchecked(object sender, RoutedEventArgs e) {
            this.Background = Brushes.LightGray;
        }
    }
}

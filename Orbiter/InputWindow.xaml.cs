using System.Windows;

namespace Orbiter
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            InitializeComponent();
            planetComboBox.SelectedIndex = 2;
        }

        private void Button_RunClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Calculator
{
    public class MainWindow : Window
    {
        private Button CalculateButton;
        private TextBox InputField;
        private TextBlock OutputField;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            CalculateButton = this.FindControl<Button>("CalculateButton");
            InputField = this.FindControl<TextBox>("InputField");
            OutputField = this.FindControl<TextBlock>("OutputField");


            CalculateButton.Click += (sender, args) =>
            {
                OutputField.Text += "test\n_____\ntest" + InputField.Text;
                OnEnterPressOrCalculateButtonClick();
            };

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnEnterPressOrCalculateButtonClick();
            }

            base.OnKeyDown(e);
        }

        private void OnEnterPressOrCalculateButtonClick()
        {

        }
    }
}
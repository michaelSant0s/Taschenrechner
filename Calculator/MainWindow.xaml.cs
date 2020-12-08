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
        private TextBox OutputField;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            CalculateButton = this.FindControl<Button>("CalculateButton");
            InputField = this.FindControl<TextBox>("InputField");
            OutputField = this.FindControl<TextBox>("OutputField");


            CalculateButton.Click += (sender, args) =>
            {
                // OutputField.Text += "test\n_____\ntest" + InputField.Text;
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
            var outputFormater = new OutputFormater();
            Parser parser = new Parser();
            var result = parser.ParseInput(InputField.Text);
            // InputField.Text = "";
        }
    }
}
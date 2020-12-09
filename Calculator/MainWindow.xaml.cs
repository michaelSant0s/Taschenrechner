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
            Parser parser = new Parser();
            MathOperation tree = parser.ParseInput(InputField.Text);

            double result = tree.Balance().GetValue();
            OutputField.Text = OutputFormater.GetOutput(InputField.Text, (decimal)result + "") + OutputField.Text;
        }
    }
}
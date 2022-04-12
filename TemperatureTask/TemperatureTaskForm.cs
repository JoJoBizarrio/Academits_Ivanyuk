namespace TemperatureTask
{
    public partial class TemperatureTaskForm : Form
    {
        public const double Epsilon = 1.0e-10;
        public const double FarengeitConversionFactor = 32;
        public const double ConversionMultiplier = 5.0 / 9;

        public TemperatureTaskForm()
        {
            InitializeComponent();

            ConvertButton.Click += ConvertButton_Click;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {

            if (FromComboBox.Text.Contains('.'))
            {
                FromComboBox.Text = FromComboBox.Text.Replace('.', ',');
            }

            if (!double.TryParse(InitialValueBox.Text, out double enteredTemperature))
            {
                GetErrorMessageAboutInvalidValue();
            }
            else
            {
                if (FromComboBox.Text == "Celsius")
                {
                    if (ToComboBox.Text == "Kelvin")
                    {
                        double convertedTemperature = TemperatureTaskMain.GetConvertedCelsiusToKelvin(enteredTemperature);

                        if  (convertedTemperature < 0)
                        {
                            GetErrorMessageAboutKelvinScale();
                        }

                        ConvertedValueBox.Text = convertedTemperature.ToString();
                        return;
                    }

                    if (ToComboBox.Text == "Fahrenheit")
                    {
                        ConvertedValueBox.Text = TemperatureTaskMain.GetConvertedCelsiusToFahrenheit(enteredTemperature).ToString();
                        return;
                    }

                    ConvertedValueBox.Text = InitialValueBox.Text;
                    return;
                }

                if (FromComboBox.Text == "Kelvin")
                {
                    if (enteredTemperature < 0)
                    {
                        GetErrorMessageAboutKelvinScale();
                        return;
                    }

                    if (ToComboBox.Text == "Celsius")
                    {
                        ConvertedValueBox.Text = TemperatureTaskMain.GetConvertedKelvinToCelsius(enteredTemperature).ToString();
                        return;
                    }

                    if (ToComboBox.Text == "Fahrenheit")
                    {
                        ConvertedValueBox.Text = TemperatureTaskMain.GetConvertedKelvinToFahrenheit(enteredTemperature).ToString();
                        return;
                    }

                    ConvertedValueBox.Text = InitialValueBox.Text;
                    return;
                }

                if (FromComboBox.Text == "Fahrenheit")
                {
                    if (ToComboBox.Text == "Celsius")
                    {
                        ConvertedValueBox.Text = TemperatureTaskMain.GetConvertedFahrenheitToCelsius(enteredTemperature).ToString();
                        return;
                    }

                    if (ToComboBox.Text == "Kelvin")
                    {
                        double convertedTemperature = TemperatureTaskMain.GetConvertedFahrenheitToKelvin(enteredTemperature);

                        if (convertedTemperature < 0)
                        {
                            GetErrorMessageAboutKelvinScale();
                            return;
                        }

                        ConvertedValueBox.Text = convertedTemperature.ToString();
                        return;
                    }

                    ConvertedValueBox.Text = InitialValueBox.Text;
                    return;
                }

            }
        }

        public static void GetErrorMessageAboutInvalidValue()
        {
            MessageBox.Show($"You entered an invalid value.", "Error");
        }

        public static void GetErrorMessageAboutKelvinScale()
        {
            MessageBox.Show($"The Kelvin scale is absolute and cannot go below zero.", "Error");
        }
    }
}
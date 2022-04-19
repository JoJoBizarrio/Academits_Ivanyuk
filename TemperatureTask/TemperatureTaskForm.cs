namespace TemperatureTask
{
    public partial class TemperatureTaskForm : Form
    {
        public TemperatureTaskForm()
        {
            InitializeComponent();

            ConvertFromComboBox.Text = "Celsius";
            ConvertToComboBox.Text = "Celsius";
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputBox.Text))
            {
                GetErrorMessageBox(2);
                return;
            }

            if (InputBox.Text.Contains('.'))
            {
                InputBox.Text = InputBox.Text.Replace('.', ',');
            }

            if (!double.TryParse(InputBox.Text, out double enteredTemperature))
            {
                GetErrorMessageBox(0);
            }
            else
            {
                // Возможно стоит разбить эти ифы на методы. не знаю
                if (ConvertFromComboBox.Text == "Celsius")
                {
                    if (ConvertToComboBox.Text == "Kelvin")
                    {
                        double convertedTemperature = TemperatureTaskMain.GetConvertedCelsiusToKelvin(enteredTemperature);

                        if  (convertedTemperature < 0)
                        {
                            GetErrorMessageBox(1);
                        }

                        OutputBox.Text = convertedTemperature.ToString();
                        return;
                    }

                    if (ConvertToComboBox.Text == "Fahrenheit")
                    {
                        OutputBox.Text = TemperatureTaskMain.GetConvertedCelsiusToFahrenheit(enteredTemperature).ToString();
                        return;
                    }

                    OutputBox.Text = InputBox.Text;
                    return;
                }

                if (ConvertFromComboBox.Text == "Kelvin")
                {
                    if (enteredTemperature < 0)
                    {
                        GetErrorMessageBox(1);
                        return;
                    }

                    if (ConvertToComboBox.Text == "Celsius")
                    {
                        OutputBox.Text = TemperatureTaskMain.GetConvertedKelvinToCelsius(enteredTemperature).ToString();
                        return;
                    }

                    if (ConvertToComboBox.Text == "Fahrenheit")
                    {
                        OutputBox.Text = TemperatureTaskMain.GetConvertedKelvinToFahrenheit(enteredTemperature).ToString();
                        return;
                    }

                    OutputBox.Text = InputBox.Text;
                    return;
                }

                if (ConvertFromComboBox.Text == "Fahrenheit")
                {
                    if (ConvertToComboBox.Text == "Celsius")
                    {
                        OutputBox.Text = TemperatureTaskMain.GetConvertedFahrenheitToCelsius(enteredTemperature).ToString();
                        return;
                    }

                    if (ConvertToComboBox.Text == "Kelvin")
                    {
                        double convertedTemperature = TemperatureTaskMain.GetConvertedFahrenheitToKelvin(enteredTemperature);

                        if (convertedTemperature < 0)
                        {
                            GetErrorMessageBox(1);
                            return;
                        }

                        OutputBox.Text = convertedTemperature.ToString();
                        return;
                    }

                    OutputBox.Text = InputBox.Text;
                    return;
                }
            }
        }

        public static void GetErrorMessageBox(int errorCode)
        {
            if (errorCode == 0)
            {
                MessageBox.Show("You entered an invalid value.", "Error");
            }
            else if (errorCode == 1)
            {
                MessageBox.Show("The Kelvin scale is absolute and cannot go below zero.", "Error");
            }
            else if (errorCode == 2)
            {
                MessageBox.Show("Input field is empty.", "Error");
            }
        }
    }
}
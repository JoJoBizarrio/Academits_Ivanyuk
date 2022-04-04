using System.Globalization;

namespace TemperatureTask
{
    public partial class TemperatureTaskForm : Form
    {
        public const double KelvinConversionFactor = 273.15;
        public const double FarengeitConversionFactor = 32;
        public const double ConversionMultiplier = 5.0 / 9;

        public TemperatureTaskForm()
        {
            InitializeComponent();

            ConvertButton.Click += ConvertButton_Click;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            // из цельсий 
            if (!string.IsNullOrEmpty(CelciusBox.Text))
            {
                if (CelciusBox.Text.Contains('.'))
                {
                    CelciusBox.Text = CelciusBox.Text.Replace('.', ',');
                }

                if (Double.TryParse(CelciusBox.Text, out double celsius))
                {
                    if (toKelvinaRadioButton.Checked)
                    {
                        double converted = celsius + KelvinConversionFactor;

                        if (converted < 0)
                        {
                            ErrorMessageAboutKelvinScale();
                        }
                        else
                        {
                            ConvertedCelciusBox.Text = Convert.ToString(converted);
                        }
                    }
                    else if (toFarengeitRadioButton.Checked)
                    {
                        ConvertedCelciusBox.Text = Convert.ToString(celsius + FarengeitConversionFactor);
                    }
                    else
                    {
                        ConvertedCelciusBox.Text = CelciusBox.Text;
                    }
                }
                else
                {
                    ErrorMessageAboutInvalidValue();
                }
            }

            // из кельвин
            if (!string.IsNullOrEmpty(KelvinBox.Text))
            {
                if (KelvinBox.Text.Contains('.'))
                {
                    KelvinBox.Text = KelvinBox.Text.Replace('.', ',');
                }

                if (Double.TryParse(KelvinBox.Text, out double kelvins))
                {
                    if (kelvins < 0)
                    {
                        ErrorMessageAboutKelvinScale();
                    }
                    else
                    {
                        if (toCelciusRadioButton.Checked)
                        {
                            ConvertedKelvinBox.Text = Convert.ToString(kelvins - KelvinConversionFactor);
                        }
                        else if (toFarengeitRadioButton.Checked)
                        {
                            double converted = (kelvins - KelvinConversionFactor) * Math.Pow(ConversionMultiplier, -1) + FarengeitConversionFactor;
                            // Math.Pow(ConversionMultiplier, -1) - тут так сделал по сложному дабы было умножение.
                            // можно убрать Pow и сделать деление но тогда надо переименовать ConversionMultiplier,
                            // а переименовывать его в FarengeitConversionFactor2 не хочу поскольку тогда он сильно сливается с первым.
                            converted = Math.Round(converted, 2, MidpointRounding.AwayFromZero);

                            ConvertedKelvinBox.Text = Convert.ToString(converted);
                            // вообще вместо создания переменной все можно запихать в Convert.ToString(). Как лучше сделать?
                            // Когда есть перенная смотриться и читается лучше но переменная по факту нигде не используется.
                        }
                        else
                        {
                            ConvertedKelvinBox.Text = KelvinBox.Text;
                        }
                    }
                }
                else
                {
                    ErrorMessageAboutInvalidValue();
                }
            }

            // из фаренгейт
            if (!string.IsNullOrEmpty(FarengeitBox.Text))
            {
                if (FarengeitBox.Text.Contains('.'))
                {
                    FarengeitBox.Text = FarengeitBox.Text.Replace('.', ',');
                }

                if (Double.TryParse(FarengeitBox.Text, out double farengeits))
                {
                    if (toCelciusRadioButton.Checked)
                    {
                        double converted = (farengeits - FarengeitConversionFactor) * ConversionMultiplier;
                        converted = Math.Round(converted, 2, MidpointRounding.AwayFromZero);

                        ConvertedFarengeitBox.Text = Convert.ToString(converted);
                    }
                    else if (toKelvinaRadioButton.Checked)
                    {
                        double converted = (farengeits - FarengeitConversionFactor) * ConversionMultiplier + KelvinConversionFactor;
                        converted = Math.Round(converted, 2, MidpointRounding.AwayFromZero);
                        // а можно называть переменные прилагательными? или лучше всегда приводить к существительным? converted => convetedValue

                        if (converted < 0)
                        {
                            ErrorMessageAboutKelvinScale();
                        }
                        else
                        {
                            ConvertedFarengeitBox.Text = Convert.ToString(converted);
                        }
                    }
                    else
                    {
                        ConvertedFarengeitBox.Text = FarengeitBox.Text;
                    }
                }
                else
                {
                    ErrorMessageAboutInvalidValue();
                }
            }
        }

        public static void ErrorMessageAboutInvalidValue()
        {
            MessageBox.Show($"You entered an invalid value.");
        }
        public static void ErrorMessageAboutKelvinScale()
        {
            MessageBox.Show($"The Kelvin scale is absolute and cannot go below zero.");
        }
    }
}
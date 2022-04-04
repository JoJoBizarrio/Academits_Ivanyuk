using System.Globalization;

namespace TemperatureTask
{
    public partial class TemperatureTaskForm : Form
    {
        public const double KelvinConversionFactor = 273.15;
        public const double FarengeitConversionFactor = 32;
        public const double ConversionMultiplier = 5 / 9;

        public TemperatureTaskForm()
        {
            InitializeComponent();

            ConvertButton.Click += ConvertButton_Click;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void toKelvin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toCelcius_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toFarengeit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CelciusBox.Text) && CelciusBox.Text != ConvertedCelciusBox.Text)
            {
                if (CelciusBox.Text.Contains('.'))
                {
                    CelciusBox.Text = CelciusBox.Text.Replace('.', ',');
                }

                if (Double.TryParse(CelciusBox.Text, out double celsius))
                {
                    if (toKelvin.Checked)
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
                    else if (toFarengeit.Checked)
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

            if (!string.IsNullOrEmpty(KelvinBox.Text) && KelvinBox.Text != ConvertedKelvinBox.Text)
            {
                if (KelvinBox.Text.Contains('.'))
                {
                    KelvinBox.Text = KelvinBox.Text.Replace('.', ',');
                }

                if (Double.TryParse(KelvinBox.Text, out double kelvins))
                {
                    if (toCelcius.Checked)
                    {
                        if (kelvins < 0)
                        {
                            ErrorMessageAboutKelvinScale();
                        }
                        else
                        {
                            ConvertedKelvinBox.Text = Convert.ToString(kelvins - KelvinConversionFactor);
                        }
                    }
                    else if (toFarengeit.Checked)
                    {
                        ConvertedKelvinBox.Text = Convert.ToString((kelvins - KelvinConversionFactor) * Math.Pow(ConversionMultiplier, -1) + FarengeitConversionFactor);
                        // Math.Pow(ConversionMultiplier, -1) - тут так сделал по сложному дабы было умножение.
                        // можно убрать Pow и сделать деление но тогда надо переименовать ConversionMultiplier,
                        // а переименовывать его в FarengeitConversionFactor2 не хочу поскольку тогда он сильно сливается с первым.
                    }
                    else
                    {
                        ConvertedKelvinBox.Text = KelvinBox.Text;
                    }
                }
                else
                {
                    ErrorMessageAboutInvalidValue();
                }
            }

            if (!string.IsNullOrEmpty(FarengeitBox.Text) && FarengeitBox.Text != ConvertedFarengeitBox.Text)
            {
                if (FarengeitBox.Text.Contains('.'))
                {
                    FarengeitBox.Text = FarengeitBox.Text.Replace('.', ',');
                }

                if (Double.TryParse(FarengeitBox.Text, out double farengeits))
                {
                    if (toCelcius.Checked)
                    {
                        ConvertedFarengeitBox.Text = Convert.ToString((farengeits - FarengeitConversionFactor) * ConversionMultiplier);
                    }
                    else if (toKelvin.Checked)
                    {
                        double converted = (farengeits - FarengeitConversionFactor) * ConversionMultiplier + KelvinConversionFactor; 
                        // а можно называть переменные прилагатлеьными? или лучше всегда привдоить к сущесвтителньому? converted => convetedValue

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
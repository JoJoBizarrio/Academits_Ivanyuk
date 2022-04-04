using System.Globalization;

namespace TemperatureTask
{
    public partial class TemperatureTaskForm : Form
    {
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
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (textBox1.Text.IndexOf('.') >= 0)
                {
                    textBox1.Text = textBox1.Text.Replace('.', ',');
                }

                if (toKelvin.Checked)
                {
                    if (Double.TryParse(textBox1.Text, out double celsius))
                    {
                        textBox4.Text = Convert.ToString(celsius + 273.15);
                    }
                    else
                    {
                        ErrorMessageAboutInvalidValue();
                    }
                }
                else if (toFarengeit.Checked)
                {
                    if (Double.TryParse(textBox1.Text, out double celsius))
                    {
                        textBox4.Text = Convert.ToString(celsius + 32);
                    }
                    else
                    {
                        ErrorMessageAboutInvalidValue();
                    }
                }
                else
                {
                    textBox4.Text = textBox1.Text;
                }
            }

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                if (textBox2.Text.IndexOf('.') >= 0)
                {
                    textBox2.Text = textBox2.Text.Replace('.', ',');
                }

                if (toKelvin.Checked)
                {
                    if (Double.TryParse(textBox1.Text, out double celsius))
                    {
                        textBox4.Text = Convert.ToString(celsius + 273.15);
                    }
                    else
                    {
                        ErrorMessageAboutInvalidValue();
                    }
                }
                else if (toFarengeit.Checked)
                {
                    if (Double.TryParse(textBox1.Text, out double celsius))
                    {
                        textBox4.Text = Convert.ToString(celsius + 32);
                    }
                    else
                    {
                        ErrorMessageAboutInvalidValue();
                    }
                }
                else
                {
                    textBox4.Text = textBox1.Text;
                }
            }
        }

        public static void ErrorMessageAboutInvalidValue()
        {
            MessageBox.Show($"You entered an invalid value.");
        }
    }
}
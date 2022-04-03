namespace TemperatureTask
{
    public partial class TemperatureTaskForm : Form
    {
        public TemperatureTaskForm()
        {
            InitializeComponent();
        }

        private void TemperatureTaskForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ConvertButton.Enabled)
            {
                textBox4_TextChanged(sender, e);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            bool click = false;
            ConvertButton.Enabled = false;

            if (textBox1.Text == "-")
            {
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = Convert.ToString(0);
                textBox1.SelectionStart = 1;
            }

            //int index = textBox1.Text.LastIndexOf('.');

            //if (index >= 0)
            //{
            //    textBox1.Text = textBox1.Text.Remove(index);
            //    textBox1.SelectionStart = textBox1.TextLength;
            //}

            if (toKelvin.Enabled)
            {
                try // а тут надо это использовать? одну ошибку с нулем я обработал. но тут еще проблемы: с точкой/запятой, с несколькими запятыми. Все вручную обрабатывать чтоли? 
                {
                    double celsius = Convert.ToDouble(textBox1.Text);
                    textBox4.Text = Convert.ToString(celsius + 273.15);
                }
                catch { MessageBox.Show("Something wrong..."); }
            }

            //if (toFarengeit.Enabled)
            //{
            //    try // а тут надо это использовать? одну ошибку с нулем я обработал. но тут еще проблемы: с точкой/запятой, с несколькими запятыми. Все вручную обрабатывать чтоли? 
            //    {
            //        double celsius = Convert.ToDouble(textBox1.Text);
            //        textBox4.Text = Convert.ToString(celsius + 32.0);
            //    }
            //    catch { MessageBox.Show("Something wrong..."); }
            //}

            // textBox4.Text = textBox1.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TemperatureTaskForm_Click(object sender, EventArgs e)
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

        }
    }
}
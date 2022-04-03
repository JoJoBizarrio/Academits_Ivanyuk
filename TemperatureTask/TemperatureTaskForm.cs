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
            if (textBox1.Enabled)
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

            try
            {
                double celsius = Convert.ToDouble(textBox1.Text);
                textBox4.Text = Convert.ToString(celsius + 273.15);
            }
            catch { MessageBox.Show("Something wrong..."); }
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
    }
}
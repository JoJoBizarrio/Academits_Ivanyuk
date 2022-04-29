namespace TemperatureTask
{
    public partial class TemperatureTaskForm : Form
    {
        private TempretureTaskLogic _tempratureTaskLogic = new TempretureTaskLogic();

        public TemperatureTaskForm()
        {
            InitializeComponent();

            foreach (string e in _tempratureTaskLogic.Scales)
            {
                ConvertFromComboBox.Items.Add(e);
                ConvertToComboBox.Items.Add(e);
            }

            ConvertFromComboBox.SelectedIndex = 0;
            ConvertToComboBox.SelectedIndex = 0;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputBox.Text))
            {
                GetErrorMessageBox("Input field is empty.");
                return;
            }

            if (InputBox.Text.Contains('.'))
            {
                InputBox.Text = InputBox.Text.Replace('.', ',');
            }

            if (!double.TryParse(InputBox.Text, out double enteredTemperature))
            {
                GetErrorMessageBox("You entered an invalid value.");
            }
            else
            {
                OutputBox.Text = _tempratureTaskLogic.GetConvetedTemperature(ConvertFromComboBox.Text, ConvertToComboBox.Text, enteredTemperature).ToString();
            }
        }

        private void GetErrorMessageBox(string errorMessage)
        {
            MessageBox.Show(this, errorMessage, "Error");
        }
    }
}
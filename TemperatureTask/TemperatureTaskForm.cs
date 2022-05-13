using TemperatureTask.Scales;

namespace TemperatureTask
{
    internal partial class TemperatureTaskForm : Form
    {
        public TemperatureTaskForm(ITemperatureScale[] scales)
        {
            InitializeComponent();

            foreach (ITemperatureScale e in scales)
            {
                inputComboBox.Items.Add(e);
                outputComboBox.Items.Add(e);
            }

            inputComboBox.SelectedIndex = 0;
            outputComboBox.SelectedIndex = 0;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputBox.Text))
            {
                GetErrorMessageBox("Input field is empty.");
                return;
            }

            if (inputBox.Text.Contains('.'))
            {
                inputBox.Text = inputBox.Text.Replace('.', ',');
            }

            if (!double.TryParse(inputBox.Text, out double enteredTemperature))
            {
                GetErrorMessageBox("You entered an invalid value.");
            }
            else
            {
                outputBox.Text = Convert.ToString(TemperatureConverter.Convert
                                 (enteredTemperature, (ITemperatureScale)inputComboBox.SelectedItem, (ITemperatureScale)outputComboBox.SelectedItem));
            }
        }

        private void GetErrorMessageBox(string errorMessage)
        {
            MessageBox.Show(this, errorMessage, "Error");
        }
    }
}
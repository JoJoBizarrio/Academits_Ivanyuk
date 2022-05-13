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
                OutputBox.Text = Convert.ToString(TemperatureConverter.Convert
                                 (enteredTemperature, (ITemperatureScale)ConvertFromComboBox.SelectedItem, (ITemperatureScale)ConvertToComboBox.SelectedItem));
            }
        }

        private void GetErrorMessageBox(string errorMessage)
        {
            MessageBox.Show(this, errorMessage, "Error");
        }
    }
}
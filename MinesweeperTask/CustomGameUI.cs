namespace MinesweeperTask
{
    public partial class CustomGameUI : Form
    {
        public CustomGameUI()
        {
            InitializeComponent();

            CurrentWidthLabel.Text = "9";

        }

        private void WidthTrackBar_Scroll(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                TrackBar trackBar = sender as TrackBar;

                if (trackBar != null)
                {
                    CurrentWidthLabel.Text = trackBar.Value.ToString();
                }
            }
        }

        private void HeightTrackBar_Scroll(object sender, EventArgs e)
        {
            if (sender != null)
            {
                TrackBar trackBar = sender as TrackBar;

                if (trackBar != null)
                {
                    CurrentHeightLabel.Text = trackBar.Value.ToString();
                }
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace MinesweeperTask
{
    public partial class CustomGameUI : Form
    {
        public CustomGameUI()
        {
            InitializeComponent();

            CurrentWidthLabel.Text = WidthTrackBar.Minimum.ToString();
            CurrentHeightLabel.Text = HeightTrackBar.Minimum .ToString();
            CurrentMinesLabel.Text = MinesCountTrackBar.Minimum .ToString();
            CurrentMinutesLabel.Text = MinutesCountTrackBar.Minimum .ToString();

            WidthRangeLabel.Text = "[9 - 30]";
            HeightRangeLabel.Text = "[9 - 24]";
            MinesRangeLabel.Text = "[9 - 28]";
            MinutesRangeLabel.Text = "[10 - 200]";

            WidthTrackBar.ValueChanged += WidthTrackBar_ValueChanged;
            HeightTrackBar.ValueChanged += HeightTrackBar_ValueChanged;
        }

        private void HeightTrackBar_ValueChanged(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                TrackBar trackBar = sender as TrackBar;

                int minesMaxCount = CustomGameLogic.GetMinesMaxCount(trackBar.Value, WidthTrackBar.Value);

                MinesCountTrackBar.Maximum = minesMaxCount;
                MinesRangeLabel.Text = $"[9 - {minesMaxCount}]";
            }
        }

        private void WidthTrackBar_ValueChanged(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                TrackBar trackBar = sender as TrackBar;

                int minesMaxCount = CustomGameLogic.GetMinesMaxCount(HeightTrackBar.Value, trackBar.Value);

                MinesCountTrackBar.Maximum = minesMaxCount;
                MinesRangeLabel.Text = $"[9 - {minesMaxCount}]";
            }
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

        private void MinesCountTrackBar_Scroll(object sender, EventArgs e)
        {
            if (sender != null)
            {
                TrackBar trackBar = sender as TrackBar;

                if (trackBar != null)
                {
                    CurrentMinesLabel.Text = trackBar.Value.ToString();
                }
            }
        }

        private void MinutesCountTrackBar_Scroll(object sender, EventArgs e)
        {
            if (sender != null)
            {
                TrackBar trackBar = sender as TrackBar;

                if (trackBar != null)
                {
                     CurrentMinutesLabel.Text = trackBar.Value.ToString();
                }
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {

        }
    }
}

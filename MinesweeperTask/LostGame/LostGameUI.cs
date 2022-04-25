using MinesweeperTask.Minesweeper;

namespace MinesweeperTask.LostGame
{
    public partial class LostGameUI : Form
    {

        public LostGameUI(int elapsedMinutesCount, int elapsedSecondCount)
        {
            InitializeComponent();

            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            ElapsedTimeCountLabel.Text = $"{elapsedMinutesCount}:{elapsedSecondCount}"; // можно это в логику не переносить?
        }

        private void EasyDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;
            
            minesweeper.EasyDifficultyToolStripMenuItem_Click(sender, e);
            Dispose();
        }

        private void HardDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.MediumDifficultyToolStripMenuItem_Click(sender, e);
            Dispose();
        }

        private void MediumDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.HardDifficultyToolStripMenuItem_Click(sender, e);
            Dispose();
        }

        private void CanselButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
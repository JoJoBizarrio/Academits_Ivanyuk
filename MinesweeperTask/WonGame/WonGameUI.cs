using MinesweeperTask.Minesweeper;

namespace MinesweeperTask.WonGame
{
    public partial class WonGameUI : Form
    {
        public WonGameUI(int elapsedSecondCount)
        {
            InitializeComponent();

            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            ElapsedTimeCountLabel.Text = $"{elapsedSecondCount / 60}:{elapsedSecondCount % 60}"; // можно это в логику не переносить?

        }

        private void EasyDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.StartCustomNewGame(9, 9, 10, 10);
            Dispose();
        }

        private void MediumDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.StartCustomNewGame(30, 16, 99, 80);
            Dispose();
        }

        private void HardDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.StartCustomNewGame(16, 16, 40, 40);
            Dispose();
        }

        private void CanselButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
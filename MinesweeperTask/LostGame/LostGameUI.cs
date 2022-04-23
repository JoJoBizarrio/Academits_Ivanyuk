using MinesweeperTask.Minesweeper;
using MinesweeperTask.CustomGame;

namespace MinesweeperTask.LostGame
{
    public partial class LostGameUI : Form
    {

        public LostGameUI(int elapsedSecondCount)
        {
            InitializeComponent();

            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            ElapsedTimeCountLabel.Text = $"{elapsedSecondCount / 60}:{elapsedSecondCount % 60}";

        }

        private void EasyDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.StartCustomNewGame(9, 9, 10, 10);
            Dispose();
        }

        private void HardDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.StartCustomNewGame(16, 16, 40, 40);
            Dispose();
        }

        private void MediumDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.StartCustomNewGame(30, 16, 99, 80);
            Dispose();
        }

        private void CustomDifficultyButton_Click(object sender, EventArgs e)
        {
            CustomGameUI customGameUI = new CustomGameUI();
            MinesweeperUI minesweeperUI = customGameUI.Owner as MinesweeperUI;
            this.Owner = minesweeperUI;
            customGameUI.ShowDialog();

        }

        private void CanselButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
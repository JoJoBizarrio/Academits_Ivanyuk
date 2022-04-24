using MinesweeperTask.Minesweeper;
using System.Globalization;

namespace MinesweeperTask.WonGame
{
    public partial class WonGameUI : Form
    {
        public WonGameUI(int elapsedMinutesCount, int elapsedSecondsCount, MinesweeperLogic minesweeperLogic)
        {
            InitializeComponent();

            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            ElapsedTimeCountLabel.Text = $"{elapsedMinutesCount}:{elapsedSecondsCount}";

            if (minesweeperLogic.IsEasy || minesweeperLogic.IsMedium || minesweeperLogic.IsHard)
            {
                string path = "..\\HighScores.txt";
                List<TimeOnly> highScoresList = new List<TimeOnly>();

                if (File.Exists(path))
                {
                    using StreamReader reader = new StreamReader(path);
                    {
                        string currentLine;

                        while ((currentLine = reader.ReadLine()) != null)
                        {
                            int minutes = Convert.ToInt32(currentLine.Remove(currentLine.IndexOf(':')));
                            int seconds = Convert.ToInt32(currentLine.Substring(currentLine.IndexOf(':') + 1));

                            highScoresList.Add(new TimeOnly(0, minutes, seconds));
                        }

                        TimeOnly newScore = new TimeOnly(0, elapsedMinutesCount, elapsedSecondsCount);

                        if (minesweeperLogic.IsEasy)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                if (highScoresList[i] > newScore)
                                {
                                    highScoresList.Insert(i, newScore);
                                    highScoresList.RemoveAt(9);
                                    break;
                                }
                            }
                        }
                        else if (minesweeperLogic.IsMedium)
                        {
                            for (int i = 9; i < 18; i++)
                            {
                                if (highScoresList[i] > newScore)
                                {
                                    highScoresList.Insert(i, newScore);
                                    highScoresList.RemoveAt(18);
                                    break;
                                }
                            }
                        }
                        else if (minesweeperLogic.IsHard)
                        {
                            for (int i = 18; i < 27; i++)
                            {
                                if (highScoresList[i] > newScore)
                                {
                                    highScoresList.Insert(i, newScore);
                                    highScoresList.RemoveAt(27);
                                    break;
                                }
                            }
                        }
                    }

                    reader.Close();
                    reader.Dispose();

                    using StreamWriter writer = new StreamWriter(path);
                    {
                        for (int i = 0; i < highScoresList.Count; i++)
                        {
                            writer.WriteLine($"{highScoresList[i].Minute}:{highScoresList[i].Second}"); // Если highScoresList[i].ToString() сделать - секунды не пишет.
                                                                                                        // не могу понять что такое string? format?
                                                                                                        // Пытался через CultureInfo, тоже не получилось.
                        }
                    }
                }
            }
        }

        private void EasyDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.EasyDifficultyToolStripMenuItem_Click(sender, e);
            Dispose();
        }

        private void MediumDifficultyButton_Click(object sender, EventArgs e)
        {
            MinesweeperUI minesweeper = this.Owner as MinesweeperUI;

            minesweeper.MediumDifficultyToolStripMenuItem_Click(sender, e);
            Dispose();
        }

        private void HardDifficultyButton_Click(object sender, EventArgs e)
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
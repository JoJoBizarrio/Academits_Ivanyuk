﻿namespace MinesweeperTask.HighScores
{
    public partial class HighScoreTableUI : Form
    {
        public HighScoreTableUI()
        {
            InitializeComponent();

            string path = "..\\HighScores.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write($"00:30{Environment.NewLine}" +
                                 $"00:45{Environment.NewLine}" +
                                 $"01:00{Environment.NewLine}" +
                                 $"01:15{Environment.NewLine}" +
                                 $"01:30{Environment.NewLine}" +
                                 $"01:45{Environment.NewLine}" +
                                 $"02:00{Environment.NewLine}" +
                                 $"02:30{Environment.NewLine}" +
                                 $"03:00{Environment.NewLine}" +
                                 $"01:00{Environment.NewLine}" +
                                 $"01:30{Environment.NewLine}" +
                                 $"02:00{Environment.NewLine}" +
                                 $"02:30{Environment.NewLine}" +
                                 $"03:00{Environment.NewLine}" +
                                 $"04:00{Environment.NewLine}" +
                                 $"05:00{Environment.NewLine}" +
                                 $"08:00{Environment.NewLine}" +
                                 $"11:00{Environment.NewLine}" +
                                 $"02:30{Environment.NewLine}" +
                                 $"05:00{Environment.NewLine}" +
                                 $"07:30{Environment.NewLine}" +
                                 $"10:00{Environment.NewLine}" +
                                 $"12:30{Environment.NewLine}" +
                                 $"15:00{Environment.NewLine}" +
                                 $"20:00{Environment.NewLine}" +
                                 $"25:00{Environment.NewLine}" +
                                 $"30:00{Environment.NewLine}");
                }
            }

            using StreamReader reader = new StreamReader(path);
            {
                string currentLine;
                int i = 1;

                while (i < 10)
                {
                    EasyListBox.Items.Add($"{i} - {reader.ReadLine()}");
                    i++;
                }
                i = 1;

                while (i < 10)
                {
                    MediumListBox.Items.Add($"{i} - {reader.ReadLine()}");
                    i++;
                }

                i = 1;
                while (i < 10)
                {

                    HardListBox.Items.Add($"{i} - {reader.ReadLine()}");
                    i++;
                }
            }
        }
    }
}
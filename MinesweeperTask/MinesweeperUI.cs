namespace MinesweeperTask
{
    public partial class MinesweeperUI : Form
    {
        private MinesweeperLogic _minesweeper;
        private Button[,] _buttons;
        private int _minutesCount;
        private int _secondCount;


        private Image _number1 = Image.FromFile("..\\number1.png");
        private Image _number2 = Image.FromFile("..\\number2.png");
        private Image _number3 = Image.FromFile("..\\number3.png");
        private Image _number4 = Image.FromFile("..\\number4.png");
        private Image _number5 = Image.FromFile("..\\number5.png");
        private Image _number6 = Image.FromFile("..\\number6.png");
        private Image _number7 = Image.FromFile("..\\number7.png");
        private Image _number8 = Image.FromFile("..\\number8.png");
        private Image _mine = Image.FromFile("..\\mine.png");
        private Image _flag = Image.FromFile("..\\flag.png");

        public MinesweeperUI()
        {
            InitializeComponent();

            CountdownTimerLabel.Text = $"00:00";

            EasyDifficultyToolStripMenuItem_Click(new object(), new EventArgs());
        }

        public void MinesweeperUI_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Button currentButton = sender as Button;

                int buttonIndex = FieldTableLayoutPanel.Controls.IndexOf(currentButton);

                int i = buttonIndex / FieldTableLayoutPanel.RowCount;
                int j = buttonIndex % FieldTableLayoutPanel.ColumnCount;

                int value = _minesweeper.Field[i, j];

                if (e.Button == MouseButtons.Right)
                {
                    if (currentButton.BackgroundImage == null)
                    {
                        currentButton.BackgroundImage = _flag;
                        MineCounterLable.Text = (Convert.ToInt32(MineCounterLable.Text) - 1).ToString();

                        _minesweeper.LockCell(i, j);

                        return;
                    }

                    if (value <= 0)
                    {
                        currentButton.BackgroundImage = null;
                        MineCounterLable.Text = (Convert.ToInt32(MineCounterLable.Text) + 1).ToString();

                        _minesweeper.UnlockCell(i, j);

                        return;
                    }
                }

                if (e.Button == MouseButtons.Left && currentButton.BackgroundImage == null)
                {
                    if (value == 0)
                    {
                        OpenZeroCells(currentButton, i, j);
                    }
                    else if (value == 9)
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _mine;
                        //TODO: функция о конце игры , откртыия поля и диаолговое окно.
                    }
                    else
                    {
                        OpenNumericCell(value, buttonIndex);
                    }
                }
            }
        }

        private void OpenZeroCells(Button button, int x, int y)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                if (i < 0 || i >= _minesweeper.FieldWidth)
                {
                    continue;
                }

                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (j < 0 || j >= _minesweeper.FieldHeight)
                    {
                        continue;
                    }

                    if (_minesweeper.Field[i, j] >= 9 || !_buttons[i, j].Enabled)
                    {
                        continue;
                    }

                    if (_buttons[i, j].BackgroundImage == null && _minesweeper.Field[i, j] == 0 && _buttons[i, j].Enabled)
                    {
                        _buttons[i, j].Enabled = false;

                        OpenZeroCells(_buttons[i, j], i, j);
                    }

                    int buttonIndex = i * FieldTableLayoutPanel.ColumnCount + j;

                    if (_minesweeper.Field[i, j] > 0 && _minesweeper.Field[i, j] < 9)
                    {
                        OpenNumericCell(_minesweeper.Field[i, j], buttonIndex);
                    }
                }
            }
        }

        private void OpenNumericCell(int value, int buttonIndex)
        {
            switch (value)
            {
                case 1:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number1;
                        break;
                    }
                case 2:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number2;
                        break;
                    }
                case 3:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number3;
                        break;
                    }
                case 4:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number4;
                        break;
                    }
                case 5:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number5;
                        break;
                    }
                case 6:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number6;
                        break;
                    }
                case 7:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number7;
                        break;
                    }
                case 8:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number8;
                        break;
                    }
            }

            FieldTableLayoutPanel.Controls[buttonIndex].Enabled = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void EasyDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame(9, 9, 10, 10);
        }

        private void MediumDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame(16, 16, 40, 40);
        }

        private void HardDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame(30, 16, 99, 80);
        }

        public void StartNewGame(int sizeX, int sizeY, int minesCount, int minutesCount)
        {
            Enabled = false;

            _minesweeper = new MinesweeperLogic(sizeX, sizeY, minesCount, minutesCount);
            _buttons = new Button[sizeX, sizeY];
            MineCounterLable.Text = minesCount.ToString();

            _minutesCount = 2;
            CountdownTimer.Interval = 1000;
            CountdownTimer.Enabled = true;
            CountdownTimer.Start();

            FieldTableLayoutPanel.Controls.Clear();

            FieldTableLayoutPanel.RowCount = sizeX;
            FieldTableLayoutPanel.ColumnCount = sizeY;

            for (int i = 0; i < FieldTableLayoutPanel.RowCount; ++i)
            {
                for (int j = 0; j < FieldTableLayoutPanel.ColumnCount; ++j)
                {
                    _buttons[i, j] = new Button();
                    _buttons[i, j].Height = 30;
                    _buttons[i, j].Width = 30;
                    _buttons[i, j].Margin = Padding.Empty;
                    _buttons[i, j].Dock = DockStyle.Fill;
                    _buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    _buttons[i, j].MouseDown += MinesweeperUI_MouseDown;

                    FieldTableLayoutPanel.Controls.Add(_buttons[i, j], i, j);
                    _buttons[i, j].Text = _minesweeper.Field[i, j].ToString();
                }
            }

            Enabled = true;
        }

        private void GetGameOver()
        {

        }

        // Окно CustomGame:
        private void CustomGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enabled = false;

            CustomGameUI customGame = new CustomGameUI();
            customGame.Activate();
            customGame.BringToFront();
            customGame.Show();

            customGame.Disposed += CustomGame_Disposed;
        }

        private void CustomGame_Disposed(object? sender, EventArgs e)
        {
            Enabled = true;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {

            if (_secondCount == 0)
            {
                if (_minutesCount == 0)
                {
                    GetGameOver();
                }

                _minutesCount -= 1;
                _secondCount = 59;
                CountdownTimerLabel.Text = $"{_minutesCount}:{_secondCount}";
            }
            else
            {
                _secondCount -= 1;
                CountdownTimerLabel.Text = $"{_minutesCount}:{_secondCount}";
            }
        }
    }
}
namespace MinesweeperTask
{
    public partial class MinesweeperUI : Form
    {
        internal MinesweeperLogic _minesweeper;
        private CustomGameUI _customGame;
        private Button[,] _buttons;

        private int _minutesCount;
        private int _secondCount;

        private Image _number1Image = Image.FromFile("..\\number1.png");
        private Image _number2Image = Image.FromFile("..\\number2.png");
        private Image _number3Image = Image.FromFile("..\\number3.png");
        private Image _number4Image = Image.FromFile("..\\number4.png");
        private Image _number5Image = Image.FromFile("..\\number5.png");
        private Image _number6Image = Image.FromFile("..\\number6.png");
        private Image _number7Image = Image.FromFile("..\\number7.png");
        private Image _number8Image = Image.FromFile("..\\number8.png");
        private Image _mineImage = Image.FromFile("..\\mine.png");
        private Image _flagImage = Image.FromFile("..\\flag.png");

        public MinesweeperUI()
        {
            InitializeComponent();


            EasyDifficultyToolStripMenuItem_Click(new object(), new EventArgs());
        }

        public void MinesweeperUI_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Button currentButton = sender as Button;

                int buttonIndex = FieldTableLayoutPanel.Controls.IndexOf(currentButton);

                int i = buttonIndex / FieldTableLayoutPanel.RowCount;
                int j = buttonIndex % FieldTableLayoutPanel.RowCount;

                int value = _minesweeper.Field[i, j];

                if (e.Button == MouseButtons.Right)
                {
                    if (currentButton.BackgroundImage == null)
                    {
                        currentButton.BackgroundImage = _flagImage;
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
                        OpenZeroCells(i, j);
                    }
                    else if (value == 9)
                    {
                        currentButton.BackgroundImage = _mineImage;
                        currentButton.Enabled = false;

                        OpenMineCells(i, j);
                        GameOver();
                    }
                    else
                    {
                        OpenNumericCell(value, buttonIndex);
                    }
                }
            }
        }

        private void OpenZeroCells(int x, int y)
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

                        OpenZeroCells(i, j);
                    }

                    int buttonIndex = i * FieldTableLayoutPanel.RowCount + j;

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
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number1Image;
                        break;
                    }
                case 2:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number2Image;
                        break;
                    }
                case 3:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number3Image;
                        break;
                    }
                case 4:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number4Image;
                        break;
                    }
                case 5:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number5Image;
                        break;
                    }
                case 6:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number6Image;
                        break;
                    }
                case 7:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number7Image;
                        break;
                    }
                case 8:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = _number8Image;
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
            StartCustomNewGame(9, 9, 10, 10);
        }

        private void MediumDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCustomNewGame(16, 16, 40, 40);
        }

        private void HardDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCustomNewGame(30, 16, 99, 80);
        }

        public void StartCustomNewGame(int sizeX, int sizeY, int minesCount, int minutesCount)
        {
            Enabled = false;

            _minesweeper = new MinesweeperLogic(sizeX, sizeY, minesCount, minutesCount);
            _buttons = new Button[sizeX, sizeY];
            MineCounterLable.Text = minesCount.ToString();

            FieldTableLayoutPanel.Controls.Clear();

            CountdownTimerLabel.Text = $"00:00";
            _minutesCount = minutesCount;
            _secondCount = 0;

            CountdownTimer.Interval = 1000;
            CountdownTimer.Enabled = true;
            CountdownTimer.Start();

            FieldTableLayoutPanel.RowCount = sizeY;
            FieldTableLayoutPanel.ColumnCount = sizeX;

            for (int i = 0; i < FieldTableLayoutPanel.ColumnCount; ++i)
            {
                for (int j = 0; j < FieldTableLayoutPanel.RowCount; ++j)
                {
                    _buttons[i, j] = new Button();
                    _buttons[i, j].Height = 30;
                    _buttons[i, j].Width = 30;
                    _buttons[i, j].Margin = Padding.Empty;
                    _buttons[i, j].Dock = DockStyle.Fill;
                    _buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    _buttons[i, j].MouseDown += MinesweeperUI_MouseDown;

                    FieldTableLayoutPanel.Controls.Add(_buttons[i, j], i, j);
                    //TODO: убрать строчку ниже
                    _buttons[i, j].Text = _minesweeper.Field[i, j].ToString();
                }
            }

            Enabled = true;
        }

        public void StartCustomNewGame(MinesweeperLogic minesweeper)
        {
            StartCustomNewGame(minesweeper.FieldHeight, minesweeper.FieldWidth, minesweeper.MinesCount, minesweeper.MinutesCount);
        }

        private void GameOver()
        {
            CountdownTimer.Stop();

            //TODO: диалоговое окно о конце игры, количестве затраченного времени
        }

        // Волна открывающихся мин равномерно расходящаяся от взрованной мины
        private void OpenMineCells(int x, int y)
        {
            Queue<Point> minePoints = new Queue<Point>();
            minePoints.Enqueue(new Point(x, y));
            bool[,] visited = new bool[_minesweeper.FieldWidth, _minesweeper.FieldHeight];

            while (minePoints.Count > 0)
            {
                Point minePoint = minePoints.Dequeue();
                visited[minePoint.X, minePoint.Y] = true;

                for (int i = minePoint.X - 1; i <= minePoint.X + 1; i++)
                {
                    if (i < 0 || i >= _minesweeper.FieldWidth)
                    {
                        continue;
                    }

                    for (int j = minePoint.Y - 1; j <= minePoint.Y + 1; j++)
                    {
                        if (j < 0 || j >= _minesweeper.FieldHeight || visited[i, j])
                        {
                            continue;
                        }

                        if (_minesweeper.Field[i, j] < 9)
                        {
                            _buttons[i, j].Enabled = false;
                        }

                        if (_minesweeper.Field[i, j] >= 9)
                        {
                            _buttons[i, j].BackgroundImage = _mineImage;
                            _buttons[i, j].Enabled = false;
                        }

                        minePoints.Enqueue(new Point(i, j));
                    }
                }
            }
        }

        // Окно CustomGame:
        private void CustomGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Enabled = false;

            _customGame = new CustomGameUI();

            _customGame.Owner = this;
            _customGame.ShowDialog();
            _customGame.BringToFront();
            _customGame.Activate();

            SendToBack();

            _customGame.Disposed += CustomGame_Disposed;
        }

        public void NewGame(int sizeX, int sizeY, int minesCount, int minutesCount)
        {

        }

        private void CustomGame_Disposed(object? sender, EventArgs e)
        {
            Enabled = true;

            Show();
            BringToFront();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {

            if (_secondCount == 0)
            {
                if (_minutesCount == 0)
                {
                    OpenMineCells(_minesweeper.FieldHeight / 2, _minesweeper.FieldWidth / 2);
                    GameOver();
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

        private void HighScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon...", "In developing");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon...", "In developing");
        }
    }
}
using MinesweeperTask.CustomGame;
using MinesweeperTask.LostGame;
using MinesweeperTask.WonGame;
using MinesweeperTask.HighScores;

namespace MinesweeperTask.Minesweeper
{
    public partial class MinesweeperUI : Form
    {
        public const int EasyDifficultyFieldWidth = 9;
        public const int EasyDifficultyFieldHeight = 9;
        public const int EasyDifficultyMinesCount = 10;
        public const int EasyDifficultyMinutesCount = 5;

        public const int MediumDifficultyFieldWidth = 16;
        public const int MediumDifficultyFieldHeight = 16;
        public const int MediumDifficultyMinesCount = 40;
        public const int MediumDifficultyMinutesCount = 15;

        public const int HardDifficultyFieldWidth = 30;
        public const int HardDifficultyFieldHeight = 24;
        public const int HardDifficultyMinesCount = 99;
        public const int HardDifficultyMinutesCount = 40;

        private MinesweeperLogic _minesweeper;
        private Button[,] _buttons;

        public bool Easy { get; private set; }

        public bool Medium { get; private set; }

        public bool Hard { get; private set; }


        private int _minutesCount;
        private int _secondCount;
        private int _elapsedMinutesCount;
        private int _elapsedSecondCount;

        private Image _number1Image = Image.FromFile("..\\images\\number1.png");
        private Image _number2Image = Image.FromFile("..\\images\\number2.png");
        private Image _number3Image = Image.FromFile("..\\images\\number3.png");
        private Image _number4Image = Image.FromFile("..\\images\\number4.png");
        private Image _number5Image = Image.FromFile("..\\images\\number5.png");
        private Image _number6Image = Image.FromFile("..\\images\\number6.png");
        private Image _number7Image = Image.FromFile("..\\images\\number7.png");
        private Image _number8Image = Image.FromFile("..\\images\\number8.png");
        private Image _mineImage = Image.FromFile("..\\images\\mine.png");
        private Image _flagImage = Image.FromFile("..\\images\\flag.png");

        public MinesweeperUI() // зачем мне здесь конструктор MinesweeperUI ? он нужен?
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

                        _minesweeper.IsLockedCell[i, j] = true;

                        return;
                    }

                    if (_minesweeper.IsLockedCell[i, j])
                    {
                        currentButton.BackgroundImage = null;
                        MineCounterLable.Text = (Convert.ToInt32(MineCounterLable.Text) + 1).ToString();

                        _minesweeper.IsLockedCell[i, j] = false;

                        return;
                    }
                }

                if (e.Button == MouseButtons.Left && currentButton.BackgroundImage == null)
                {
                    if (value == 0)
                    {
                        OpenZeroCells(i, j);
                        CheckIsWin();
                    }
                    else if (value == 9)
                    {
                        currentButton.BackgroundImage = _mineImage;
                        currentButton.Enabled = false;

                        OpenMineCells(i, j);
                        FinishLostGame();
                    }
                    else
                    {
                        OpenNumericCell(value, currentButton);
                        CheckIsWin();
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

                    if (_minesweeper.Field[i, j] < 9)
                    {
                        OpenNumericCell(_minesweeper.Field[i, j], _buttons[i, j]);
                    }
                }
            }
        }

        private void OpenNumericCell(int value, Button button)
        {
            switch (value)
            {
                case 1:
                    {
                        button.BackgroundImage = _number1Image;
                        break;
                    }
                case 2:
                    {
                        button.BackgroundImage = _number2Image;
                        break;
                    }
                case 3:
                    {
                        button.BackgroundImage = _number3Image;
                        break;
                    }
                case 4:
                    {
                        button.BackgroundImage = _number4Image;
                        break;
                    }
                case 5:
                    {
                        button.BackgroundImage = _number5Image;
                        break;
                    }
                case 6:
                    {
                        button.BackgroundImage = _number6Image;
                        break;
                    }
                case 7:
                    {
                        button.BackgroundImage = _number7Image;
                        break;
                    }
                case 8:
                    {
                        button.BackgroundImage = _number8Image;
                        break;
                    }
            }

            button.Enabled = false;
        }

        public void CheckIsWin()
        {
            for (int i = 0; i < _minesweeper.FieldHeight; i++)
            {
                for (int j = 0; j < _minesweeper.FieldWidth; j++)
                {
                    if (_minesweeper.Field[i, j] == 9)
                    {
                        continue;
                    }

                    if (_buttons[i, j].Enabled)
                    {
                        return;
                    }
                }
            }

            FieldTableLayoutPanel.Enabled = false;
            CountdownTimer.Stop();

            WonGameUI wonGame = new WonGameUI(_elapsedMinutesCount, _elapsedSecondCount, _minesweeper);
            wonGame.Owner = this;
            wonGame.ShowDialog();
        }

        public void EasyDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCustomNewGame(EasyDifficultyFieldHeight, EasyDifficultyFieldWidth, EasyDifficultyMinesCount, EasyDifficultyMinutesCount);
        }

        public void MediumDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCustomNewGame(MediumDifficultyFieldHeight, MediumDifficultyFieldWidth, MediumDifficultyMinesCount, MediumDifficultyMinutesCount);
        }

        public void HardDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCustomNewGame(HardDifficultyFieldHeight, HardDifficultyFieldWidth, HardDifficultyMinesCount, HardDifficultyMinutesCount);
        }

        public void StartCustomNewGame(int fieldWidth, int fieldHeight, int minesCount, int minutesCount)
        {
            Enabled = false;

            _minesweeper = new MinesweeperLogic(fieldWidth, fieldHeight, minesCount, minutesCount);

            if (fieldWidth == EasyDifficultyFieldWidth && fieldHeight == EasyDifficultyFieldHeight &&
                minesCount == EasyDifficultyMinesCount && minutesCount == EasyDifficultyMinutesCount)
            {
                _minesweeper.IsEasy = true;
                _minesweeper.IsMedium = false;
                _minesweeper.IsHard = false;
            }
            else if (fieldWidth == MediumDifficultyFieldWidth && fieldHeight == MediumDifficultyFieldHeight &&
                     minesCount == MediumDifficultyMinesCount && minutesCount == MediumDifficultyMinutesCount)
            {
                _minesweeper.IsEasy = false;
                _minesweeper.IsMedium = true;
                _minesweeper.IsHard = false;
            }
            else if (fieldWidth == HardDifficultyFieldWidth && fieldHeight == HardDifficultyFieldHeight &&
                     minesCount == HardDifficultyMinesCount && minutesCount == HardDifficultyMinutesCount)
            {
                _minesweeper.IsEasy = false;
                _minesweeper.IsMedium = false;
                _minesweeper.IsHard = true;
            }
            else
            {
                _minesweeper.IsEasy = false;
                _minesweeper.IsMedium = false;
                _minesweeper.IsHard = false;
            }

            _buttons = new Button[fieldWidth, fieldHeight];
            MineCounterLable.Text = minesCount.ToString();

            FieldTableLayoutPanel.Controls.Clear();

            CountdownTimerLabel.Text = "00:00";
            _minutesCount = minutesCount;
            _secondCount = 0;
            _elapsedMinutesCount = -1;
            _elapsedSecondCount = 0;

            CountdownTimer.Interval = 1000;
            CountdownTimer.Enabled = true;
            CountdownTimer.Start();

            FieldTableLayoutPanel.RowCount = fieldHeight;
            FieldTableLayoutPanel.ColumnCount = fieldWidth;

            for (int i = 0; i < fieldWidth; ++i)
            {
                for (int j = 0; j < fieldHeight; ++j)
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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FinishLostGame()
        {
            CountdownTimer.Stop();

            LostGameUI lostGameUI = new LostGameUI(_elapsedMinutesCount, _elapsedSecondCount);

            lostGameUI.Owner = this;

            lostGameUI.ShowDialog();
        }

        // ¬олна открывающихс€ мин равномерно расход€ща€с€ от взрованной мины
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

        // ќкно CustomGame:
        private void CustomGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomGameUI customGameUI = new CustomGameUI();

            Easy = false;
            Medium = false;
            Hard = false;

            customGameUI.Owner = this;
            customGameUI.ShowDialog();

            customGameUI.Activate();
            customGameUI.BringToFront();

            SendToBack();

            customGameUI.Disposed += CustomGame_Disposed;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {

            if (_secondCount == 0)
            {
                if (_minutesCount == 0)
                {
                    OpenMineCells(_minesweeper.FieldWidth / 2, _minesweeper.FieldHeight / 2);
                    FinishLostGame();
                }

                _elapsedMinutesCount += 1;
                _elapsedSecondCount = 1;
                _minutesCount -= 1;
                _secondCount = 59;
                CountdownTimerLabel.Text = $"{_minutesCount}:{_secondCount}";
            }
            else
            {
                _elapsedSecondCount += 1;
                _secondCount -= 1;
                CountdownTimerLabel.Text = $"{_minutesCount}:{_secondCount}";
            }
        }

        private void HighScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighScoreTableUI highScoreTable = new HighScoreTableUI();

            highScoreTable.ShowDialog();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon...", "In developing");
        }

        private void CustomGame_Disposed(object? sender, EventArgs e)
        {
            Enabled = true;

            Show();
            BringToFront();
        }
    }
}
namespace MinesweeperTask
{
    public partial class MinesweeperUI : Form
    {
        private Minesweeper _minesweeper;

        private Button[,] _buttons;

        Image number1 = Image.FromFile("..\\number1.png");
        Image number2 = Image.FromFile("..\\number2.png");
        Image number3 = Image.FromFile("..\\number3.png");
        Image number4 = Image.FromFile("..\\number4.png");
        Image number5 = Image.FromFile("..\\number5.png");
        Image number6 = Image.FromFile("..\\number6.png");
        Image number7 = Image.FromFile("..\\number7.png");
        Image number8 = Image.FromFile("..\\number8.png");
        Image mine = Image.FromFile("..\\mine.png");
        Image flag = Image.FromFile("..\\flag.png");

        public MinesweeperUI()
        {
            InitializeComponent();

            MediumDifficultyToolStripMenuItem_Click(this, new EventArgs());
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

                if (value == 11)
                {
                    return;
                }

                if (e.Button == MouseButtons.Right)
                {
                    if (currentButton.BackgroundImage == null)
                    {
                        currentButton.BackgroundImage = flag;
                        _minesweeper.Field[i, j] = -value;
                        MineCounterLable.Text = (Convert.ToInt32(MineCounterLable.Text) - 1).ToString();

                        return;
                    }

                    if (value <= 0)
                    {
                        currentButton.BackgroundImage = null;
                        _minesweeper.Field[i, j] = -value;
                        MineCounterLable.Text = (Convert.ToInt32(MineCounterLable.Text) + 1).ToString();

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
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = mine;
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
                if (i < 0 || i >= _minesweeper.SizeX)
                {
                    continue;
                }

                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (j < 0 || j >= _minesweeper.SizeY)
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
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = number1;
                        break;
                    }
                case 2:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = number2;
                        break;
                    }
                case 3:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = number3;
                        break;
                    }
                case 4:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = number4;
                        break;
                    }
                case 5:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = number5;
                        break;
                    }
                case 6:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = number6;
                        break;
                    }
                case 7:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = number7;
                        break;
                    }
                case 8:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = number8;
                        break;
                    }
            }

            FieldTableLayoutPanel.Controls[buttonIndex].Enabled = false;
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CustomGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomGame customGame = new CustomGame();
            customGame.Show();
        }

        private void EasyDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewCustomGame(9, 9, 10, 10);
        }

        private void MediumDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewCustomGame(18, 18, 40, 20);
        }

        private void StartNewCustomGame(int sizeX, int sizeY, int minesCount, int minutesCount)
        {
            _minesweeper = new Minesweeper(sizeX, sizeY, minesCount, minutesCount);
            _buttons = new Button[sizeX, sizeY];
            MineCounterLable.Text = minesCount.ToString();
            
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
                    FieldTableLayoutPanel.Controls.Add(_buttons[i, j], i, j);
                    _buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    _buttons[i, j].MouseDown += MinesweeperUI_MouseDown;
                    _buttons[i, j].Text = _minesweeper.Field[i, j].ToString();

                }
            }
        }

        private void FieldTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
namespace MinesweeperTask
{
    public partial class MinesweeperUI : Form
    {
        private Minesweeper _minesweeper;

        private Button[,] _buttons;

        public MinesweeperUI()
        {
            InitializeComponent();
        }

        public void MinesweeperUI_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Button currentButton = sender as Button;

                int buttonIndex = FieldTableLayoutPanel.Controls.IndexOf(currentButton);

                int i = buttonIndex / FieldTableLayoutPanel.RowCount;
                int j = buttonIndex % FieldTableLayoutPanel.ColumnCount;

                int value = _minesweeper.MinesweeperArrayRepresentation[i, j];

                if (value == 11)
                {
                    return;
                }

                if (e.Button == MouseButtons.Right)
                {
                    if (currentButton.BackgroundImage == null)
                    {
                        currentButton.BackgroundImage = Image.FromFile("..\\flag.png");
                        _minesweeper.MinesweeperArrayRepresentation[i, j] = -value;
                        return;
                    }

                    if (value < 0)
                    {
                        currentButton.BackgroundImage = null;
                        _minesweeper.MinesweeperArrayRepresentation[i, j] = -value;
                        return;
                    }
                }

                if (e.Button == MouseButtons.Left && currentButton.BackgroundImage == null)
                {
                    if (value == 0)
                    {
                        OpenZerosField(currentButton, i, j);
                    }
                    else
                    {
                        OpenCell(value, buttonIndex);
                    }
                }
            }
        }

        private void OpenZerosField(Button button, int x, int y)
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

                    if (_minesweeper.MinesweeperArrayRepresentation[i, j] >= 9 || !_buttons[i, j].Enabled)
                    {
                        continue;
                    }

                    if (_buttons[i, j].BackgroundImage == null && _minesweeper.MinesweeperArrayRepresentation[i, j] == 0 && _buttons[i, j].Enabled)
                    {
                        _buttons[i, j].Enabled = false;

                        OpenZerosField(_buttons[i, j], i, j);
                    }

                    int buttonIndex = i * FieldTableLayoutPanel.ColumnCount + j;

                    if (_minesweeper.MinesweeperArrayRepresentation[i, j] > 0 && _minesweeper.MinesweeperArrayRepresentation[i, j] < 9)
                    {
                        OpenCell(_minesweeper.MinesweeperArrayRepresentation[i, j], buttonIndex);
                    }
                }
            }
        }

        private void OpenCell(int value, int buttonIndex)
        {
            switch (value)
            {
                case 1:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\number1.png");
                        break;
                    }
                case 2:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\number2.png");
                        break;
                    }
                case 3:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\number3.png");
                        break;
                    }
                case 4:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\number4.png");
                        break;
                    }
                case 5:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\number5.png");
                        break;
                    }
                case 6:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\number6.png");
                        break;
                    }
                case 7:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\number7.png");
                        break;
                    }
                case 8:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\number8.png");
                        break;
                    }
                case 9:
                    {
                        FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\mine.png");
                        //TODO: функция о конце игры , откртыия поля и диаолговое окно.
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

        private void StartNewCustomGame(int sizeX, int sizeY, int minesCount, int minutesCount)
        {
            _minesweeper = new Minesweeper(sizeX, sizeY, minesCount, minutesCount);

            _buttons = new Button[sizeX, sizeY];

            FieldTableLayoutPanel.RowCount = sizeX;
            FieldTableLayoutPanel.ColumnCount = sizeY;

            for (int i = 0; i < FieldTableLayoutPanel.RowCount; ++i)
            {
                for (int j = 0; j < FieldTableLayoutPanel.ColumnCount; ++j)
                {
                    _buttons[i, j] = new Button();
                    _buttons[i, j].Height = 10;
                    _buttons[i, j].Width = 10;
                    _buttons[i, j].Margin = Padding.Empty;
                    _buttons[i, j].Dock = DockStyle.Fill;
                    FieldTableLayoutPanel.Controls.Add(_buttons[i, j], i, j);
                    _buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    _buttons[i, j].MouseDown += MinesweeperUI_MouseDown;

                }
            }
        }

        private void FieldTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
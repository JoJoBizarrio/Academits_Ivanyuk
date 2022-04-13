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
            Image mineImage = Image.FromFile("..\\mine.png");


            if (sender != null)
            {
                Button button = sender as Button;

                int buttonIndex = FieldTableLayoutPanel.Controls.IndexOf(button);
                int i = buttonIndex / FieldTableLayoutPanel.RowCount;
                int j = buttonIndex % FieldTableLayoutPanel.ColumnCount;

                if (e.Button == MouseButtons.Left)
                {
                    int value = _minesweeper.MinesweeperArrayRepresentation[i, j];
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
                        case < 0:
                            {
                                FieldTableLayoutPanel.Controls[buttonIndex].BackgroundImage = Image.FromFile("..\\mine.png");
                                break;
                            }
                    }
                }
            }
        }

        private void MinesweeperUI_Load(object sender, EventArgs e)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 9;
            tableLayoutPanel.ColumnCount = 9;
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel.BackColor = Color.Black;
            tableLayoutPanel.CreateControl();
            tableLayoutPanel.Show();
            tableLayoutPanel.Enabled = true;
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
    }
}
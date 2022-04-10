namespace MinesweeperTask
{
    public partial class MinesweeperUI : Form
    {
        public MinesweeperUI()
        {
            InitializeComponent();

            // FieldTableLayoutPanel.ColumnStyles.Add(new Button());

            //Button button12314 = new Button();
            //button12314.Height = 40;
            //button12314.Width = 40;
            //button12314.BackColor = FieldTableLayoutPanel.BackColor;
            //Image mineImage = Image.FromFile("..\\mine.png");
            //button12314.BackgroundImage = mineImage;
            //button12314.BackgroundImageLayout = ImageLayout.Stretch;
            ////button12314.Dock = DockStyle.Fill;

            //Minesweeper minesweeper = new Minesweeper(9, 9, 10, 10);

            ////Button[,] buttonsArray = new Button[FieldTableLayoutPanel.RowCount, FieldTableLayoutPanel.ColumnCount];

            ////for (int i = 0; i < FieldTableLayoutPanel.RowCount; ++i)
            ////{
            ////    for (int j = 0; j < FieldTableLayoutPanel.ColumnCount; ++j)
            ////    {
            ////        buttonsArray[i, j] = new Button();
            ////        buttonsArray[i, j].Height = 40;
            ////        buttonsArray[i, j].Width = 40;
            ////        buttonsArray[i, j].Margin = Padding.Empty;
            ////        buttonsArray[i, j].BackColor = FieldTableLayoutPanel.BackColor;
            ////        //Image mineImage = Image.FromFile("..\\mine.png");
            ////        //buttonsArray[i, j].BackgroundImage = mineImage;
            ////        buttonsArray[i, j].BackgroundImageLayout = ImageLayout.Stretch;
            ////        buttonsArray[i, j].Dock = DockStyle.Fill;
            ////        FieldTableLayoutPanel.Controls.Add(buttonsArray[i, j], i, j);
            ////        buttonsArray[i, j].Click += MinesweeperUI_Click;
            ////    }
            ////}

            //for (int i = 0; i < FieldTableLayoutPanel.RowCount; ++i)
            //{
            //    for (int j = 0; j < FieldTableLayoutPanel.ColumnCount; ++j)
            //    {
            //        FieldTableLayoutPanel.Controls.Add(minesweeper.Buttons[i, j], i, j);
            //        minesweeper.Buttons[i, j].MouseDown += MinesweeperUI_MouseDown;
            //    }
            //}

        }

        public void MinesweeperUI_MouseDown(object? sender, MouseEventArgs e)
        {
            Image mineImage = Image.FromFile("..\\mine.png");
            
            
            if (sender != null)
            {
                Button button = sender as Button;
                int please =  FieldTableLayoutPanel.Controls.IndexOf(button);
                int x = please / FieldTableLayoutPanel.ColumnCount;
                int y = please % FieldTableLayoutPanel.ColumnCount;

                if (e.Button == MouseButtons.Left)
                {
                    button.BackgroundImage = mineImage;
                    FieldTableLayoutPanel.Controls[0].BackgroundImage = mineImage;
                    //button.BackgroundImageLayout = ImageLayout.Stretch;
                    //button.Dock = DockStyle.Fill;
                    
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

        public void Open(Minesweeper minesweeper, int x, int y)
        {
            if (minesweeper.MinesweeperArrayRepresentation[x, y] == 0)
            {

            }
        }

        private void FillTable()
        {
            Button[,] buttonsArray = new Button[FieldTableLayoutPanel.RowCount, FieldTableLayoutPanel.ColumnCount];

            for (int i = 0; i < FieldTableLayoutPanel.RowCount; ++i)
            {
                for (int j = 0; j < FieldTableLayoutPanel.ColumnCount; ++j)
                {
                    buttonsArray[i, j] = new Button();
                    buttonsArray[i, j].Height = 40;
                    buttonsArray[i, j].Width = 40;
                    buttonsArray[i, j].Margin = Padding.Empty;
                    buttonsArray[i, j].BackColor = FieldTableLayoutPanel.BackColor;
                    //Image mineImage = Image.FromFile("..\\mine.png");
                    //buttonsArray[i, j].BackgroundImage = mineImage;
                    buttonsArray[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    buttonsArray[i, j].Dock = DockStyle.Fill;
                    FieldTableLayoutPanel.Controls.Add(buttonsArray[i, j], i, j);
                }
            }
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
            Minesweeper minesweeper = new Minesweeper(sizeX, sizeY, minesCount, minutesCount);

            FieldTableLayoutPanel.RowCount = sizeX;
            FieldTableLayoutPanel.ColumnCount = sizeY;

            for (int i = 0; i < FieldTableLayoutPanel.RowCount; ++i)
            {
                for (int j = 0; j < FieldTableLayoutPanel.ColumnCount; ++j)
                {
                    FieldTableLayoutPanel.Controls.Add(minesweeper.Buttons[i, j], i, j);
                    minesweeper.Buttons[i, j].MouseDown += MinesweeperUI_MouseDown;
                    FieldTableLayoutPanel.Controls.
                }
            }
        }

        private void FieldTableLayoutPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Image mineImage = Image.FromFile("..\\mine.png");


            if (sender != null)
            { 
                Control control = sender as Control;

                if (e.Button == MouseButtons.Left)
                {
                    control.BackgroundImage = mineImage;
                   // FieldTableLayoutPanel.Controls[0].BackgroundImage = mineImage;
                    //button.BackgroundImageLayout = ImageLayout.Stretch;
                    //button.Dock = DockStyle.Fill;

                }

            }
        }
    }
}
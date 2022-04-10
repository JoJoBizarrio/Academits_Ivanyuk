namespace MinesweeperTask
{
    public partial class MinesweeperUI : Form
    {
        public MinesweeperUI()
        {
            InitializeComponent();

            // FieldTableLayoutPanel.ColumnStyles.Add(new Button());

            Button button12314 = new Button();
            button12314.Height = 40;
            button12314.Width = 40;
            button12314.BackColor = FieldTableLayoutPanel.BackColor;
            Image mineImage = Image.FromFile("..\\mine.png");
            button12314.BackgroundImage = mineImage;
            button12314.BackgroundImageLayout = ImageLayout.Stretch;
            button12314.Dock = DockStyle.Fill;


            FillTable();
        }

        private void FieldTableLayoutPanel_Click1(object? sender, EventArgs e)
        {
            //Button[] buttonsArray = new Button();
            //button12314.Height = 40;
            //button12314.Width = 40;
            //button12314.BackColor = FieldTableLayoutPanel.BackColor;
            //Image mineImage = Image.FromFile("..\\mine.png");
            //button12314.BackgroundImage = mineImage;
            //button12314.BackgroundImageLayout = ImageLayout.Stretch;
            //button12314.Dock = DockStyle.Fill;
            //FieldTableLayoutPanel.Controls.Add(button12314, 2, 2);
            //FieldTableLayoutPanel.Controls.Add(control, 2, 2);

        }

        public void DrawLinesPoint(PaintEventArgs e)
        {
            // Create pen.
            Pen pen = new Pen(Color.Black, 3);

            // Create array of points that define lines to draw.
            Point[] points =
                     {
                 new Point(10,  10),
                 new Point(10, 100),
                 new Point(200,  50),
                 new Point(250, 300)
             };

            //Draw lines to screen.
            e.Graphics.DrawLines(pen, points);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            {
                g.DrawLine(Pens.Black, new Point(0, 0), new Point(20, 100));
                g.DrawLine(Pens.Black, new Point(20, 100), new Point(250, 100));
            }

            //Image image = new Bitmap("..\\mine.png");
            //button1.Image = Image.FromFile("..\\mine.png");

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 9;
            tableLayoutPanel.ColumnCount = 9;
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel.BackColor = Color.Black;
            tableLayoutPanel.Enabled = true;

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

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Image mineImage = Image.FromFile("..\\mine.png");
            Image flagImage = Image.FromFile("..\\flag.png");


            if (e.Button == MouseButtons.Left)
            {
                button1.BackgroundImage = flagImage;
                button1.BackgroundImageLayout = ImageLayout.Stretch;
                button1.Text = "";
            }

            if (e.Button == MouseButtons.Right)
            {

                if (button1.Enabled)
                {
                    button1.Enabled = false;
                    button1.BackgroundImage = mineImage;
                    button1.BackgroundImageLayout = ImageLayout.Stretch;
                    button1.Text = "";
                }
                else
                {

                }
            }

            //mineImage.Dispose();
            //flagImage.Dispose();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        public void Open(Minesweeper minesweeper, int x, int y)
        {
            if (minesweeper.MinesweeperArrayRepresentation[x, y] == 0)
            {

            }
        }

        private void FieldTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

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
                    Image mineImage = Image.FromFile("..\\mine.png");
                    buttonsArray[i, j].BackgroundImage = mineImage;
                    buttonsArray[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    buttonsArray[i, j].Dock = DockStyle.Fill;
                    FieldTableLayoutPanel.Controls.Add(buttonsArray[i, j], i, j);
                }
            }
        }
    }
}
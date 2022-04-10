namespace MinesweeperTask
{
    public partial class MinesweeperUI : Form
    {
        public MinesweeperUI()
        {
            InitializeComponent();

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();

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

            ;



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
            tableLayoutPanel.BackColor = Color.Black ;
            tableLayoutPanel.Enabled = true;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //tableLayoutPanel1.Size = new Size(100, 100);
            
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

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        //private void button1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    Image mineImage = Image.FromFile("..\\mine.png");
        //    Image flagImage = Image.FromFile("..\\flag.png");
                

        //    if (e.Button == MouseButtons.Right)
        //    {
        //        button1.BackgroundImage = flagImage;
        //        button1.BackgroundImageLayout = ImageLayout.Stretch;
        //        button1.Text = "";
        //    }

        //    if (button1.BackgroundImage.Size != flagImage.Size & e.Button == MouseButtons.Left)
        //    {
        //        button1.BackgroundImage = mineImage;
        //        button1.BackgroundImageLayout = ImageLayout.Stretch;
        //        button1.Text = "";
        //    }
        //}

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void GameFieldFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
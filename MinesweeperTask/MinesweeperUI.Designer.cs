namespace MinesweeperTask
{
    partial class MinesweeperUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinesweeperUI));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.GameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EasyDifficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MediumDifficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HighDifficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpertDifficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HighScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.MineCountLabel = new System.Windows.Forms.Label();
            this.FieldTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameToolStripMenuItem,
            this.HighScoresToolStripMenuItem,
            this.ReferenceToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(542, 28);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            this.MenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // GameToolStripMenuItem
            // 
            this.GameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameToolStripMenuItem,
            this.CustomGameToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.GameToolStripMenuItem.Name = "GameToolStripMenuItem";
            this.GameToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.GameToolStripMenuItem.Text = "Game";
            // 
            // NewGameToolStripMenuItem
            // 
            this.NewGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EasyDifficultyToolStripMenuItem,
            this.MediumDifficultyToolStripMenuItem,
            this.HighDifficultyToolStripMenuItem,
            this.ExpertDifficultyToolStripMenuItem});
            this.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem";
            this.NewGameToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.NewGameToolStripMenuItem.Text = "New game";
            // 
            // EasyDifficultyToolStripMenuItem
            // 
            this.EasyDifficultyToolStripMenuItem.Name = "EasyDifficultyToolStripMenuItem";
            this.EasyDifficultyToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.EasyDifficultyToolStripMenuItem.Text = "Easy";
            this.EasyDifficultyToolStripMenuItem.Click += new System.EventHandler(this.EasyDifficultyToolStripMenuItem_Click);
            // 
            // MediumDifficultyToolStripMenuItem
            // 
            this.MediumDifficultyToolStripMenuItem.Name = "MediumDifficultyToolStripMenuItem";
            this.MediumDifficultyToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.MediumDifficultyToolStripMenuItem.Text = "Medium";
            // 
            // HighDifficultyToolStripMenuItem
            // 
            this.HighDifficultyToolStripMenuItem.Name = "HighDifficultyToolStripMenuItem";
            this.HighDifficultyToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.HighDifficultyToolStripMenuItem.Text = "High";
            // 
            // ExpertDifficultyToolStripMenuItem
            // 
            this.ExpertDifficultyToolStripMenuItem.Name = "ExpertDifficultyToolStripMenuItem";
            this.ExpertDifficultyToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.ExpertDifficultyToolStripMenuItem.Text = "Expert";
            // 
            // CustomGameToolStripMenuItem
            // 
            this.CustomGameToolStripMenuItem.Name = "CustomGameToolStripMenuItem";
            this.CustomGameToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.CustomGameToolStripMenuItem.Text = "Custom game";
            this.CustomGameToolStripMenuItem.Click += new System.EventHandler(this.CustomGameToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // HighScoresToolStripMenuItem
            // 
            this.HighScoresToolStripMenuItem.Name = "HighScoresToolStripMenuItem";
            this.HighScoresToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.HighScoresToolStripMenuItem.Text = "High scores";
            // 
            // ReferenceToolStripMenuItem
            // 
            this.ReferenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.ReferenceToolStripMenuItem.Name = "ReferenceToolStripMenuItem";
            this.ReferenceToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.ReferenceToolStripMenuItem.Text = "Reference";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.AboutToolStripMenuItem.Text = "About";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FieldTableLayoutPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.45749F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.54252F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 605);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.MineCountLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 544);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(536, 58);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // MineCountLabel
            // 
            this.MineCountLabel.AutoSize = true;
            this.MineCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MineCountLabel.Location = new System.Drawing.Point(10, 10);
            this.MineCountLabel.Margin = new System.Windows.Forms.Padding(10);
            this.MineCountLabel.Name = "MineCountLabel";
            this.MineCountLabel.Size = new System.Drawing.Size(248, 38);
            this.MineCountLabel.TabIndex = 0;
            this.MineCountLabel.Text = "000";
            this.MineCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FieldTableLayoutPanel
            // 
            this.FieldTableLayoutPanel.AutoSize = true;
            this.FieldTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FieldTableLayoutPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.FieldTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.FieldTableLayoutPanel.ColumnCount = 9;
            this.FieldTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldTableLayoutPanel.Location = new System.Drawing.Point(20, 20);
            this.FieldTableLayoutPanel.Margin = new System.Windows.Forms.Padding(20);
            this.FieldTableLayoutPanel.Name = "FieldTableLayoutPanel";
            this.FieldTableLayoutPanel.RowCount = 9;
            this.FieldTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.FieldTableLayoutPanel.Size = new System.Drawing.Size(502, 501);
            this.FieldTableLayoutPanel.TabIndex = 1;
            // 
            // MinesweeperUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(542, 633);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(558, 659);
            this.Name = "MinesweeperUI";
            this.Text = "Minesweeper";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip MenuStrip;
        private ToolStripMenuItem GameToolStripMenuItem;
        private ToolStripMenuItem NewGameToolStripMenuItem;
        private ToolStripMenuItem CustomGameToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem HighScoresToolStripMenuItem;
        private ToolStripMenuItem ReferenceToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label MineCountLabel;
        private TableLayoutPanel FieldTableLayoutPanel;
        private ToolStripMenuItem EasyDifficultyToolStripMenuItem;
        private ToolStripMenuItem MediumDifficultyToolStripMenuItem;
        private ToolStripMenuItem HighDifficultyToolStripMenuItem;
        private ToolStripMenuItem ExpertDifficultyToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}
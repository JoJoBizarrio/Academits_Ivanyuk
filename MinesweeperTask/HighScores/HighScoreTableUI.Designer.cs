namespace MinesweeperTask.HighScores
{
    partial class HighScoreTableUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HighScoresTabControl = new System.Windows.Forms.TabControl();
            this.EasyTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.EasyListBox = new System.Windows.Forms.ListBox();
            this.MediumTabPage = new System.Windows.Forms.TabPage();
            this.MediumListBox = new System.Windows.Forms.ListBox();
            this.HardTabPage = new System.Windows.Forms.TabPage();
            this.HardListBox = new System.Windows.Forms.ListBox();
            this.HighScoresTabControl.SuspendLayout();
            this.EasyTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.MediumTabPage.SuspendLayout();
            this.HardTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // HighScoresTabControl
            // 
            this.HighScoresTabControl.Controls.Add(this.EasyTabPage);
            this.HighScoresTabControl.Controls.Add(this.MediumTabPage);
            this.HighScoresTabControl.Controls.Add(this.HardTabPage);
            this.HighScoresTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HighScoresTabControl.Location = new System.Drawing.Point(0, 0);
            this.HighScoresTabControl.Name = "HighScoresTabControl";
            this.HighScoresTabControl.SelectedIndex = 0;
            this.HighScoresTabControl.Size = new System.Drawing.Size(287, 373);
            this.HighScoresTabControl.TabIndex = 0;
            // 
            // EasyTabPage
            // 
            this.EasyTabPage.Controls.Add(this.tableLayoutPanel1);
            this.EasyTabPage.Location = new System.Drawing.Point(4, 29);
            this.EasyTabPage.Name = "EasyTabPage";
            this.EasyTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EasyTabPage.Size = new System.Drawing.Size(279, 340);
            this.EasyTabPage.TabIndex = 0;
            this.EasyTabPage.Text = "Easy";
            this.EasyTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.EasyListBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 334);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // EasyListBox
            // 
            this.EasyListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EasyListBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EasyListBox.FormattingEnabled = true;
            this.EasyListBox.ItemHeight = 31;
            this.EasyListBox.Location = new System.Drawing.Point(0, 0);
            this.EasyListBox.Margin = new System.Windows.Forms.Padding(0);
            this.EasyListBox.Name = "EasyListBox";
            this.EasyListBox.Size = new System.Drawing.Size(273, 334);
            this.EasyListBox.TabIndex = 0;
            // 
            // MediumTabPage
            // 
            this.MediumTabPage.Controls.Add(this.MediumListBox);
            this.MediumTabPage.Location = new System.Drawing.Point(4, 29);
            this.MediumTabPage.Name = "MediumTabPage";
            this.MediumTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MediumTabPage.Size = new System.Drawing.Size(279, 340);
            this.MediumTabPage.TabIndex = 1;
            this.MediumTabPage.Text = "Medium";
            this.MediumTabPage.UseVisualStyleBackColor = true;
            // 
            // MediumListBox
            // 
            this.MediumListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediumListBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MediumListBox.FormattingEnabled = true;
            this.MediumListBox.ItemHeight = 31;
            this.MediumListBox.Location = new System.Drawing.Point(3, 3);
            this.MediumListBox.Name = "MediumListBox";
            this.MediumListBox.Size = new System.Drawing.Size(273, 334);
            this.MediumListBox.TabIndex = 1;
            // 
            // HardTabPage
            // 
            this.HardTabPage.Controls.Add(this.HardListBox);
            this.HardTabPage.Location = new System.Drawing.Point(4, 29);
            this.HardTabPage.Name = "HardTabPage";
            this.HardTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HardTabPage.Size = new System.Drawing.Size(279, 340);
            this.HardTabPage.TabIndex = 2;
            this.HardTabPage.Text = "Hard";
            this.HardTabPage.UseVisualStyleBackColor = true;
            // 
            // HardListBox
            // 
            this.HardListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HardListBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HardListBox.FormattingEnabled = true;
            this.HardListBox.ItemHeight = 31;
            this.HardListBox.Location = new System.Drawing.Point(3, 3);
            this.HardListBox.Name = "HardListBox";
            this.HardListBox.Size = new System.Drawing.Size(273, 334);
            this.HardListBox.TabIndex = 2;
            // 
            // HighScoreTableUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 373);
            this.Controls.Add(this.HighScoresTabControl);
            this.Name = "HighScoreTableUI";
            this.Text = "High score table";
            this.HighScoresTabControl.ResumeLayout(false);
            this.EasyTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.MediumTabPage.ResumeLayout(false);
            this.HardTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl HighScoresTabControl;
        private TabPage EasyTabPage;
        private TabPage MediumTabPage;
        private TabPage HardTabPage;
        private ListBox MediumListBox;
        private ListBox HardListBox;
        private TableLayoutPanel tableLayoutPanel1;
        private ListBox EasyListBox;
    }
}
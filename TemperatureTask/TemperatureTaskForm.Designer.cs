namespace TemperatureTask
{
    partial class TemperatureTaskForm
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
            this.InputBox = new System.Windows.Forms.TextBox();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.ConvertSymbolsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ConvertFromComboBox = new System.Windows.Forms.ComboBox();
            this.ConvertToComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.InputBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InputBox.Location = new System.Drawing.Point(3, 8);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(137, 27);
            this.InputBox.TabIndex = 0;
            // 
            // OutputBox
            // 
            this.OutputBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OutputBox.Enabled = false;
            this.OutputBox.Location = new System.Drawing.Point(217, 8);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(137, 27);
            this.OutputBox.TabIndex = 5;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.ConvertButton.Location = new System.Drawing.Point(52, 109);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(277, 60);
            this.ConvertButton.TabIndex = 16;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // ConvertSymbolsLabel
            // 
            this.ConvertSymbolsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConvertSymbolsLabel.AutoSize = true;
            this.ConvertSymbolsLabel.Location = new System.Drawing.Point(164, 11);
            this.ConvertSymbolsLabel.Name = "ConvertSymbolsLabel";
            this.ConvertSymbolsLabel.Size = new System.Drawing.Size(29, 20);
            this.ConvertSymbolsLabel.TabIndex = 12;
            this.ConvertSymbolsLabel.Text = "=>";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.InputBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ConvertSymbolsLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.OutputBox, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(358, 43);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.ConvertFromComboBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ConvertToComboBox, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 61);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(358, 42);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // ConvertFromComboBox
            // 
            this.ConvertFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConvertFromComboBox.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.ConvertFromComboBox.Location = new System.Drawing.Point(3, 3);
            this.ConvertFromComboBox.Name = "ConvertFromComboBox";
            this.ConvertFromComboBox.Size = new System.Drawing.Size(137, 28);
            this.ConvertFromComboBox.TabIndex = 1;
            // 
            // ConvertToComboBox
            // 
            this.ConvertToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConvertToComboBox.FormattingEnabled = true;
            this.ConvertToComboBox.Location = new System.Drawing.Point(217, 3);
            this.ConvertToComboBox.Name = "ConvertToComboBox";
            this.ConvertToComboBox.Size = new System.Drawing.Size(137, 28);
            this.ConvertToComboBox.TabIndex = 2;
            // 
            // TemperatureTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 183);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ConvertButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 230);
            this.Name = "TemperatureTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature\'s converter";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox InputBox;
        private TextBox OutputBox;
        private Button ConvertButton;
        private Label ConvertSymbolsLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox ConvertFromComboBox;
        private ComboBox ConvertToComboBox;
    }
}
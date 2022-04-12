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
            this.InitialValueBox = new System.Windows.Forms.TextBox();
            this.ConvertedValueBox = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.ConvertSymbolsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FromComboBox = new System.Windows.Forms.ComboBox();
            this.ToComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // InitialValueBox
            // 
            this.InitialValueBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.InitialValueBox.Location = new System.Drawing.Point(40, 8);
            this.InitialValueBox.Name = "InitialValueBox";
            this.InitialValueBox.Size = new System.Drawing.Size(100, 27);
            this.InitialValueBox.TabIndex = 0;
            // 
            // ConvertedValueBox
            // 
            this.ConvertedValueBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConvertedValueBox.Enabled = false;
            this.ConvertedValueBox.Location = new System.Drawing.Point(217, 8);
            this.ConvertedValueBox.Name = "ConvertedValueBox";
            this.ConvertedValueBox.ReadOnly = true;
            this.ConvertedValueBox.Size = new System.Drawing.Size(100, 27);
            this.ConvertedValueBox.TabIndex = 5;
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
            this.tableLayoutPanel1.Controls.Add(this.InitialValueBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ConvertSymbolsLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ConvertedValueBox, 2, 0);
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
            this.tableLayoutPanel2.Controls.Add(this.FromComboBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ToComboBox, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 61);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(358, 42);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // FromComboBox
            // 
            this.FromComboBox.FormattingEnabled = true;
            this.FromComboBox.Items.AddRange(new object[] {
            "Celsius",
            "Kelvin",
            "Fahrenheit"});
            this.FromComboBox.Location = new System.Drawing.Point(3, 3);
            this.FromComboBox.Name = "FromComboBox";
            this.FromComboBox.Size = new System.Drawing.Size(137, 28);
            this.FromComboBox.TabIndex = 1;
            this.FromComboBox.Text = "From";
            // 
            // ToComboBox
            // 
            this.ToComboBox.FormattingEnabled = true;
            this.ToComboBox.Items.AddRange(new object[] {
            "Celsius",
            "Kelvin",
            "Fahrenheit"});
            this.ToComboBox.Location = new System.Drawing.Point(217, 3);
            this.ToComboBox.Name = "ToComboBox";
            this.ToComboBox.Size = new System.Drawing.Size(137, 28);
            this.ToComboBox.TabIndex = 2;
            this.ToComboBox.Text = "To";
            // 
            // TemperatureTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 183);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ConvertButton);
            this.MinimumSize = new System.Drawing.Size(400, 230);
            this.Name = "TemperatureTaskForm";
            this.Text = "Temperature\'s converter";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox InitialValueBox;
        private TextBox ConvertedValueBox;
        private Button ConvertButton;
        private Label ConvertSymbolsLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ComboBox FromComboBox;
        private ComboBox ToComboBox;
    }
}
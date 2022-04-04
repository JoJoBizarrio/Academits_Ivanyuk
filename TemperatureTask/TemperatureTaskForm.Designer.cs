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
            this.CelciusBox = new System.Windows.Forms.TextBox();
            this.KelvinBox = new System.Windows.Forms.TextBox();
            this.FarengeitBox = new System.Windows.Forms.TextBox();
            this.ConvertedCelciusBox = new System.Windows.Forms.TextBox();
            this.ConvertedKelvinBox = new System.Windows.Forms.TextBox();
            this.ConvertedFarengeitBox = new System.Windows.Forms.TextBox();
            this.CelciusLabel = new System.Windows.Forms.Label();
            this.KelvinLabel = new System.Windows.Forms.Label();
            this.FarengeitLabel = new System.Windows.Forms.Label();
            this.ConvertSymbolsLabel = new System.Windows.Forms.Label();
            this.toKelvinaRadioButton = new System.Windows.Forms.RadioButton();
            this.toCelciusRadioButton = new System.Windows.Forms.RadioButton();
            this.toFarengeitRadioButton = new System.Windows.Forms.RadioButton();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CelciusBox
            // 
            this.CelciusBox.Location = new System.Drawing.Point(110, 25);
            this.CelciusBox.Name = "CelciusBox";
            this.CelciusBox.Size = new System.Drawing.Size(79, 27);
            this.CelciusBox.TabIndex = 0;
            // 
            // KelvinBox
            // 
            this.KelvinBox.Location = new System.Drawing.Point(110, 63);
            this.KelvinBox.Name = "KelvinBox";
            this.KelvinBox.Size = new System.Drawing.Size(79, 27);
            this.KelvinBox.TabIndex = 1;
            // 
            // FarengeitBox
            // 
            this.FarengeitBox.Location = new System.Drawing.Point(110, 99);
            this.FarengeitBox.Name = "FarengeitBox";
            this.FarengeitBox.Size = new System.Drawing.Size(79, 27);
            this.FarengeitBox.TabIndex = 2;
            // 
            // ConvertedCelciusBox
            // 
            this.ConvertedCelciusBox.Enabled = false;
            this.ConvertedCelciusBox.Location = new System.Drawing.Point(262, 25);
            this.ConvertedCelciusBox.Name = "ConvertedCelciusBox";
            this.ConvertedCelciusBox.ReadOnly = true;
            this.ConvertedCelciusBox.Size = new System.Drawing.Size(79, 27);
            this.ConvertedCelciusBox.TabIndex = 5;
            // 
            // ConvertedKelvinBox
            // 
            this.ConvertedKelvinBox.Enabled = false;
            this.ConvertedKelvinBox.Location = new System.Drawing.Point(262, 63);
            this.ConvertedKelvinBox.Name = "ConvertedKelvinBox";
            this.ConvertedKelvinBox.ReadOnly = true;
            this.ConvertedKelvinBox.Size = new System.Drawing.Size(79, 27);
            this.ConvertedKelvinBox.TabIndex = 4;
            // 
            // ConvertedFarengeitBox
            // 
            this.ConvertedFarengeitBox.Enabled = false;
            this.ConvertedFarengeitBox.Location = new System.Drawing.Point(262, 103);
            this.ConvertedFarengeitBox.Name = "ConvertedFarengeitBox";
            this.ConvertedFarengeitBox.ReadOnly = true;
            this.ConvertedFarengeitBox.Size = new System.Drawing.Size(79, 27);
            this.ConvertedFarengeitBox.TabIndex = 3;
            // 
            // CelciusLabel
            // 
            this.CelciusLabel.AutoSize = true;
            this.CelciusLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CelciusLabel.Location = new System.Drawing.Point(32, 31);
            this.CelciusLabel.Name = "CelciusLabel";
            this.CelciusLabel.Size = new System.Drawing.Size(72, 18);
            this.CelciusLabel.TabIndex = 6;
            this.CelciusLabel.Text = "Celcius:";
            // 
            // KelvinLabel
            // 
            this.KelvinLabel.AutoSize = true;
            this.KelvinLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KelvinLabel.Location = new System.Drawing.Point(40, 68);
            this.KelvinLabel.Name = "KelvinLabel";
            this.KelvinLabel.Size = new System.Drawing.Size(64, 18);
            this.KelvinLabel.TabIndex = 7;
            this.KelvinLabel.Text = "Kelvin:";
            // 
            // FarengeitLabel
            // 
            this.FarengeitLabel.AutoSize = true;
            this.FarengeitLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FarengeitLabel.Location = new System.Drawing.Point(16, 108);
            this.FarengeitLabel.Name = "FarengeitLabel";
            this.FarengeitLabel.Size = new System.Drawing.Size(88, 18);
            this.FarengeitLabel.TabIndex = 11;
            this.FarengeitLabel.Text = "Farengeit:";
            // 
            // ConvertSymbolsLabel
            // 
            this.ConvertSymbolsLabel.AutoSize = true;
            this.ConvertSymbolsLabel.Location = new System.Drawing.Point(211, 28);
            this.ConvertSymbolsLabel.Name = "ConvertSymbolsLabel";
            this.ConvertSymbolsLabel.Size = new System.Drawing.Size(29, 100);
            this.ConvertSymbolsLabel.TabIndex = 12;
            this.ConvertSymbolsLabel.Text = "=>\r\n\r\n=>\r\n\r\n=>\r\n";
            // 
            // toKelvinaRadioButton
            // 
            this.toKelvinaRadioButton.AutoSize = true;
            this.toKelvinaRadioButton.Checked = true;
            this.toKelvinaRadioButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toKelvinaRadioButton.Location = new System.Drawing.Point(17, 157);
            this.toKelvinaRadioButton.Name = "toKelvinaRadioButton";
            this.toKelvinaRadioButton.Size = new System.Drawing.Size(101, 22);
            this.toKelvinaRadioButton.TabIndex = 13;
            this.toKelvinaRadioButton.TabStop = true;
            this.toKelvinaRadioButton.Text = "to Kelvin";
            this.toKelvinaRadioButton.UseVisualStyleBackColor = true;
            // 
            // toCelciusRadioButton
            // 
            this.toCelciusRadioButton.AutoSize = true;
            this.toCelciusRadioButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toCelciusRadioButton.Location = new System.Drawing.Point(125, 157);
            this.toCelciusRadioButton.Name = "toCelciusRadioButton";
            this.toCelciusRadioButton.Size = new System.Drawing.Size(109, 22);
            this.toCelciusRadioButton.TabIndex = 14;
            this.toCelciusRadioButton.Text = "to Celcius";
            this.toCelciusRadioButton.UseVisualStyleBackColor = true;
            // 
            // toFarengeitRadioButton
            // 
            this.toFarengeitRadioButton.AutoSize = true;
            this.toFarengeitRadioButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toFarengeitRadioButton.Location = new System.Drawing.Point(240, 157);
            this.toFarengeitRadioButton.Name = "toFarengeitRadioButton";
            this.toFarengeitRadioButton.Size = new System.Drawing.Size(125, 22);
            this.toFarengeitRadioButton.TabIndex = 15;
            this.toFarengeitRadioButton.Text = "to Farengeit";
            this.toFarengeitRadioButton.UseVisualStyleBackColor = true;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.ConvertButton.Location = new System.Drawing.Point(46, 208);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(285, 60);
            this.ConvertButton.TabIndex = 16;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // TemperatureTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 283);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.toFarengeitRadioButton);
            this.Controls.Add(this.toCelciusRadioButton);
            this.Controls.Add(this.toKelvinaRadioButton);
            this.Controls.Add(this.ConvertSymbolsLabel);
            this.Controls.Add(this.FarengeitLabel);
            this.Controls.Add(this.KelvinLabel);
            this.Controls.Add(this.CelciusLabel);
            this.Controls.Add(this.ConvertedCelciusBox);
            this.Controls.Add(this.ConvertedKelvinBox);
            this.Controls.Add(this.ConvertedFarengeitBox);
            this.Controls.Add(this.FarengeitBox);
            this.Controls.Add(this.KelvinBox);
            this.Controls.Add(this.CelciusBox);
            this.MinimumSize = new System.Drawing.Size(397, 318);
            this.Name = "TemperatureTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature\'s converter";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox CelciusBox;
        private TextBox KelvinBox;
        private TextBox FarengeitBox;
        private TextBox ConvertedCelciusBox;
        private TextBox ConvertedKelvinBox;
        private TextBox ConvertedFarengeitBox;
        private Label CelciusLabel;
        private Label KelvinLabel;
        private Label FarengeitLabel;
        private Label ConvertSymbolsLabel;
        private RadioButton toKelvinaRadioButton;
        private RadioButton toCelciusRadioButton;
        private RadioButton toFarengeitRadioButton;
        private Button ConvertButton;
    }
}
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
            this.toKelvinaLabel = new System.Windows.Forms.RadioButton();
            this.toCelciusLabel = new System.Windows.Forms.RadioButton();
            this.toFarengeitLabel = new System.Windows.Forms.RadioButton();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CelciusBox
            // 
            this.CelciusBox.Location = new System.Drawing.Point(100, 25);
            this.CelciusBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CelciusBox.Name = "CelciusBox";
            this.CelciusBox.Size = new System.Drawing.Size(70, 23);
            this.CelciusBox.TabIndex = 0;
            // 
            // KelvinBox
            // 
            this.KelvinBox.Location = new System.Drawing.Point(100, 53);
            this.KelvinBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.KelvinBox.Name = "KelvinBox";
            this.KelvinBox.Size = new System.Drawing.Size(70, 23);
            this.KelvinBox.TabIndex = 1;
            // 
            // FarengeitBox
            // 
            this.FarengeitBox.Location = new System.Drawing.Point(100, 80);
            this.FarengeitBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FarengeitBox.Name = "FarengeitBox";
            this.FarengeitBox.Size = new System.Drawing.Size(70, 23);
            this.FarengeitBox.TabIndex = 2;
            // 
            // ConvertedCelciusBox
            // 
            this.ConvertedCelciusBox.Enabled = false;
            this.ConvertedCelciusBox.Location = new System.Drawing.Point(233, 25);
            this.ConvertedCelciusBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConvertedCelciusBox.Name = "ConvertedCelciusBox";
            this.ConvertedCelciusBox.ReadOnly = true;
            this.ConvertedCelciusBox.Size = new System.Drawing.Size(70, 23);
            this.ConvertedCelciusBox.TabIndex = 5;
            // 
            // ConvertedKelvinBox
            // 
            this.ConvertedKelvinBox.Enabled = false;
            this.ConvertedKelvinBox.Location = new System.Drawing.Point(233, 53);
            this.ConvertedKelvinBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConvertedKelvinBox.Name = "ConvertedKelvinBox";
            this.ConvertedKelvinBox.ReadOnly = true;
            this.ConvertedKelvinBox.Size = new System.Drawing.Size(70, 23);
            this.ConvertedKelvinBox.TabIndex = 4;
            // 
            // ConvertedFarengeitBox
            // 
            this.ConvertedFarengeitBox.Enabled = false;
            this.ConvertedFarengeitBox.Location = new System.Drawing.Point(233, 83);
            this.ConvertedFarengeitBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConvertedFarengeitBox.Name = "ConvertedFarengeitBox";
            this.ConvertedFarengeitBox.ReadOnly = true;
            this.ConvertedFarengeitBox.Size = new System.Drawing.Size(70, 23);
            this.ConvertedFarengeitBox.TabIndex = 3;
            // 
            // CelciusLabel
            // 
            this.CelciusLabel.AutoSize = true;
            this.CelciusLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CelciusLabel.Location = new System.Drawing.Point(38, 29);
            this.CelciusLabel.Name = "CelciusLabel";
            this.CelciusLabel.Size = new System.Drawing.Size(63, 14);
            this.CelciusLabel.TabIndex = 6;
            this.CelciusLabel.Text = "Celcius:";
            // 
            // KelvinLabel
            // 
            this.KelvinLabel.AutoSize = true;
            this.KelvinLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KelvinLabel.Location = new System.Drawing.Point(45, 57);
            this.KelvinLabel.Name = "KelvinLabel";
            this.KelvinLabel.Size = new System.Drawing.Size(56, 14);
            this.KelvinLabel.TabIndex = 7;
            this.KelvinLabel.Text = "Kelvin:";
            // 
            // FarengeitLabel
            // 
            this.FarengeitLabel.AutoSize = true;
            this.FarengeitLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FarengeitLabel.Location = new System.Drawing.Point(24, 87);
            this.FarengeitLabel.Name = "FarengeitLabel";
            this.FarengeitLabel.Size = new System.Drawing.Size(77, 14);
            this.FarengeitLabel.TabIndex = 11;
            this.FarengeitLabel.Text = "Farengeit:";
            // 
            // ConvertSymbolsLabel
            // 
            this.ConvertSymbolsLabel.AutoSize = true;
            this.ConvertSymbolsLabel.Location = new System.Drawing.Point(189, 27);
            this.ConvertSymbolsLabel.Name = "ConvertSymbolsLabel";
            this.ConvertSymbolsLabel.Size = new System.Drawing.Size(23, 75);
            this.ConvertSymbolsLabel.TabIndex = 12;
            this.ConvertSymbolsLabel.Text = "=>\r\n\r\n=>\r\n\r\n=>\r\n";
            // 
            // toKelvinaLabel
            // 
            this.toKelvinaLabel.AutoSize = true;
            this.toKelvinaLabel.Checked = true;
            this.toKelvinaLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toKelvinaLabel.Location = new System.Drawing.Point(14, 122);
            this.toKelvinaLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toKelvinaLabel.Name = "toKelvinaLabel";
            this.toKelvinaLabel.Size = new System.Drawing.Size(88, 18);
            this.toKelvinaLabel.TabIndex = 13;
            this.toKelvinaLabel.TabStop = true;
            this.toKelvinaLabel.Text = "to Kelvin";
            this.toKelvinaLabel.UseVisualStyleBackColor = true;
            // 
            // toCelciusLabel
            // 
            this.toCelciusLabel.AutoSize = true;
            this.toCelciusLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toCelciusLabel.Location = new System.Drawing.Point(108, 122);
            this.toCelciusLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toCelciusLabel.Name = "toCelciusLabel";
            this.toCelciusLabel.Size = new System.Drawing.Size(95, 18);
            this.toCelciusLabel.TabIndex = 14;
            this.toCelciusLabel.Text = "to Celcius";
            this.toCelciusLabel.UseVisualStyleBackColor = true;
            // 
            // toFarengeitLabel
            // 
            this.toFarengeitLabel.AutoSize = true;
            this.toFarengeitLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toFarengeitLabel.Location = new System.Drawing.Point(209, 122);
            this.toFarengeitLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toFarengeitLabel.Name = "toFarengeitLabel";
            this.toFarengeitLabel.Size = new System.Drawing.Size(109, 18);
            this.toFarengeitLabel.TabIndex = 15;
            this.toFarengeitLabel.Text = "to Farengeit";
            this.toFarengeitLabel.UseVisualStyleBackColor = true;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.ConvertButton.Location = new System.Drawing.Point(40, 156);
            this.ConvertButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(249, 45);
            this.ConvertButton.TabIndex = 16;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // TemperatureTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 212);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.toFarengeitLabel);
            this.Controls.Add(this.toCelciusLabel);
            this.Controls.Add(this.toKelvinaLabel);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(350, 250);
            this.MinimumSize = new System.Drawing.Size(350, 250);
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
        private RadioButton toKelvinaLabel;
        private RadioButton toCelciusLabel;
        private RadioButton toFarengeitLabel;
        private Button ConvertButton;
    }
}
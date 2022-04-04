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
            this.label4 = new System.Windows.Forms.Label();
            this.toKelvin = new System.Windows.Forms.RadioButton();
            this.toCelcius = new System.Windows.Forms.RadioButton();
            this.toFarengeit = new System.Windows.Forms.RadioButton();
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 75);
            this.label4.TabIndex = 12;
            this.label4.Text = "=>\r\n\r\n=>\r\n\r\n=>\r\n";
            // 
            // toKelvin
            // 
            this.toKelvin.AutoSize = true;
            this.toKelvin.Checked = true;
            this.toKelvin.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toKelvin.Location = new System.Drawing.Point(14, 122);
            this.toKelvin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toKelvin.Name = "toKelvin";
            this.toKelvin.Size = new System.Drawing.Size(88, 18);
            this.toKelvin.TabIndex = 13;
            this.toKelvin.TabStop = true;
            this.toKelvin.Text = "to Kelvin";
            this.toKelvin.UseVisualStyleBackColor = true;
            this.toKelvin.CheckedChanged += new System.EventHandler(this.toKelvin_CheckedChanged);
            // 
            // toCelcius
            // 
            this.toCelcius.AutoSize = true;
            this.toCelcius.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toCelcius.Location = new System.Drawing.Point(108, 122);
            this.toCelcius.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toCelcius.Name = "toCelcius";
            this.toCelcius.Size = new System.Drawing.Size(95, 18);
            this.toCelcius.TabIndex = 14;
            this.toCelcius.Text = "to Celcius";
            this.toCelcius.UseVisualStyleBackColor = true;
            this.toCelcius.CheckedChanged += new System.EventHandler(this.toCelcius_CheckedChanged);
            // 
            // toFarengeit
            // 
            this.toFarengeit.AutoSize = true;
            this.toFarengeit.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toFarengeit.Location = new System.Drawing.Point(209, 122);
            this.toFarengeit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toFarengeit.Name = "toFarengeit";
            this.toFarengeit.Size = new System.Drawing.Size(109, 18);
            this.toFarengeit.TabIndex = 15;
            this.toFarengeit.Text = "to Farengeit";
            this.toFarengeit.UseVisualStyleBackColor = true;
            this.toFarengeit.CheckedChanged += new System.EventHandler(this.toFarengeit_CheckedChanged);
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
            this.Controls.Add(this.toFarengeit);
            this.Controls.Add(this.toCelcius);
            this.Controls.Add(this.toKelvin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FarengeitLabel);
            this.Controls.Add(this.KelvinLabel);
            this.Controls.Add(this.CelciusLabel);
            this.Controls.Add(this.ConvertedCelciusBox);
            this.Controls.Add(this.ConvertedKelvinBox);
            this.Controls.Add(this.ConvertedFarengeitBox);
            this.Controls.Add(this.FarengeitBox);
            this.Controls.Add(this.KelvinBox);
            this.Controls.Add(this.CelciusBox);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
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
        private Label label4;
        private RadioButton toKelvin;
        private RadioButton toCelcius;
        private RadioButton toFarengeit;
        private Button ConvertButton;
    }
}
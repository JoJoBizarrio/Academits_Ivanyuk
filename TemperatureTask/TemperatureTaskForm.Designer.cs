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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toKelvin = new System.Windows.Forms.RadioButton();
            this.toCelcius = new System.Windows.Forms.RadioButton();
            this.toFarengeit = new System.Windows.Forms.RadioButton();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(132, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(132, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 27);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(132, 105);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 27);
            this.textBox3.TabIndex = 2;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(285, 32);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(80, 27);
            this.textBox4.TabIndex = 5;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(285, 69);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(80, 27);
            this.textBox5.TabIndex = 4;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(285, 109);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(80, 27);
            this.textBox6.TabIndex = 3;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Celcius";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kelvin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Farengeit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 100);
            this.label4.TabIndex = 12;
            this.label4.Text = "=>\r\n\r\n=>\r\n\r\n=>\r\n";
            // 
            // toKelvin
            // 
            this.toKelvin.AutoSize = true;
            this.toKelvin.Checked = true;
            this.toKelvin.Location = new System.Drawing.Point(31, 175);
            this.toKelvin.Name = "toKelvin";
            this.toKelvin.Size = new System.Drawing.Size(88, 24);
            this.toKelvin.TabIndex = 13;
            this.toKelvin.TabStop = true;
            this.toKelvin.Text = "to Kelvin";
            this.toKelvin.UseVisualStyleBackColor = true;
            this.toKelvin.CheckedChanged += new System.EventHandler(this.toKelvin_CheckedChanged);
            // 
            // toCelcius
            // 
            this.toCelcius.AutoSize = true;
            this.toCelcius.Location = new System.Drawing.Point(141, 175);
            this.toCelcius.Name = "toCelcius";
            this.toCelcius.Size = new System.Drawing.Size(90, 24);
            this.toCelcius.TabIndex = 14;
            this.toCelcius.Text = "toCelcius";
            this.toCelcius.UseVisualStyleBackColor = true;
            this.toCelcius.CheckedChanged += new System.EventHandler(this.toCelcius_CheckedChanged);
            // 
            // toFarengeit
            // 
            this.toFarengeit.AutoSize = true;
            this.toFarengeit.Location = new System.Drawing.Point(256, 175);
            this.toFarengeit.Name = "toFarengeit";
            this.toFarengeit.Size = new System.Drawing.Size(109, 24);
            this.toFarengeit.TabIndex = 15;
            this.toFarengeit.Text = "to Farengeit";
            this.toFarengeit.UseVisualStyleBackColor = true;
            this.toFarengeit.CheckedChanged += new System.EventHandler(this.toFarengeit_CheckedChanged);
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(31, 217);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(94, 29);
            this.ConvertButton.TabIndex = 16;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // TemperatureTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 552);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.toFarengeit);
            this.Controls.Add(this.toCelcius);
            this.Controls.Add(this.toKelvin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "TemperatureTaskForm";
            this.Text = "Converter\'s temperature ";
            this.Load += new System.EventHandler(this.TemperatureTaskForm_Load);
            this.Click += new System.EventHandler(this.TemperatureTaskForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RadioButton toKelvin;
        private RadioButton toCelcius;
        private RadioButton toFarengeit;
        private Button ConvertButton;
    }
}
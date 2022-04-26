namespace MinesweeperTask.Referense
{
    partial class CreatorsUI
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CreatorsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OkButton.Location = new System.Drawing.Point(94, 79);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(150, 42);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CreatorsLabel
            // 
            this.CreatorsLabel.AutoEllipsis = true;
            this.CreatorsLabel.AutoSize = true;
            this.CreatorsLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreatorsLabel.Location = new System.Drawing.Point(12, 9);
            this.CreatorsLabel.Name = "CreatorsLabel";
            this.CreatorsLabel.Size = new System.Drawing.Size(318, 62);
            this.CreatorsLabel.TabIndex = 1;
            this.CreatorsLabel.Text = "Ivanyuk Konstantin V. 2022 \r\nby support Academ IT School.";
            // 
            // CreatorsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 133);
            this.Controls.Add(this.CreatorsLabel);
            this.Controls.Add(this.OkButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 180);
            this.Name = "CreatorsUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Creators";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button OkButton;
        private Label CreatorsLabel;
    }
}
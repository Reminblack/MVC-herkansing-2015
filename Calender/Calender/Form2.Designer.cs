namespace Calender
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.infoName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.infoStart = new System.Windows.Forms.Label();
            this.infoEnd = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.infoDescription = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.infoDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // infoName
            // 
            this.infoName.AutoSize = true;
            this.infoName.Location = new System.Drawing.Point(122, 81);
            this.infoName.Name = "infoName";
            this.infoName.Size = new System.Drawing.Size(52, 13);
            this.infoName.TabIndex = 1;
            this.infoName.Text = "infoName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Starting date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ending Date";
            // 
            // infoStart
            // 
            this.infoStart.AutoSize = true;
            this.infoStart.Location = new System.Drawing.Point(122, 169);
            this.infoStart.Name = "infoStart";
            this.infoStart.Size = new System.Drawing.Size(46, 13);
            this.infoStart.TabIndex = 4;
            this.infoStart.Text = "infoStart";
            // 
            // infoEnd
            // 
            this.infoEnd.AutoSize = true;
            this.infoEnd.Location = new System.Drawing.Point(378, 169);
            this.infoEnd.Name = "infoEnd";
            this.infoEnd.Size = new System.Drawing.Size(43, 13);
            this.infoEnd.TabIndex = 5;
            this.infoEnd.Text = "infoEnd";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description";
            // 
            // infoDescription
            // 
            this.infoDescription.AutoSize = true;
            this.infoDescription.Location = new System.Drawing.Point(122, 269);
            this.infoDescription.Name = "infoDescription";
            this.infoDescription.Size = new System.Drawing.Size(35, 13);
            this.infoDescription.TabIndex = 7;
            this.infoDescription.Text = "label8";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(584, 363);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // infoDelete
            // 
            this.infoDelete.Location = new System.Drawing.Point(462, 363);
            this.infoDelete.Name = "infoDelete";
            this.infoDelete.Size = new System.Drawing.Size(75, 23);
            this.infoDelete.TabIndex = 9;
            this.infoDelete.Text = "Delete";
            this.infoDelete.UseVisualStyleBackColor = true;
            this.infoDelete.Click += new System.EventHandler(this.infoDelete_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 420);
            this.Controls.Add(this.infoDelete);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.infoDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.infoEnd);
            this.Controls.Add(this.infoStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.infoName);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label infoName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label infoStart;
        private System.Windows.Forms.Label infoEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label infoDescription;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button infoDelete;
    }
}
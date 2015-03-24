namespace Calender
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.weekRadio = new System.Windows.Forms.RadioButton();
            this.monthRadio = new System.Windows.Forms.RadioButton();
            this.calendarRender = new System.Windows.Forms.FlowLayoutPanel();
            this.allRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(833, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addItem_Click);
            // 
            // weekRadio
            // 
            this.weekRadio.AutoSize = true;
            this.weekRadio.Location = new System.Drawing.Point(318, 51);
            this.weekRadio.Name = "weekRadio";
            this.weekRadio.Size = new System.Drawing.Size(54, 17);
            this.weekRadio.TabIndex = 2;
            this.weekRadio.TabStop = true;
            this.weekRadio.Text = "Week";
            this.weekRadio.UseVisualStyleBackColor = true;
            this.weekRadio.CheckedChanged += new System.EventHandler(this.weekRadio_CheckedChanged);
            // 
            // monthRadio
            // 
            this.monthRadio.AutoSize = true;
            this.monthRadio.BackColor = System.Drawing.SystemColors.Control;
            this.monthRadio.Location = new System.Drawing.Point(492, 51);
            this.monthRadio.Name = "monthRadio";
            this.monthRadio.Size = new System.Drawing.Size(55, 17);
            this.monthRadio.TabIndex = 3;
            this.monthRadio.TabStop = true;
            this.monthRadio.Text = "Month";
            this.monthRadio.UseVisualStyleBackColor = false;
            this.monthRadio.CheckedChanged += new System.EventHandler(this.monthRadio_CheckedChanged);
            // 
            // calendarRender
            // 
            this.calendarRender.AutoScroll = true;
            this.calendarRender.Location = new System.Drawing.Point(32, 92);
            this.calendarRender.Name = "calendarRender";
            this.calendarRender.Size = new System.Drawing.Size(781, 365);
            this.calendarRender.TabIndex = 4;
            this.calendarRender.WrapContents = false;
            this.calendarRender.Paint += new System.Windows.Forms.PaintEventHandler(this.calendarRender_Paint);
            // 
            // allRadio
            // 
            this.allRadio.AutoSize = true;
            this.allRadio.Location = new System.Drawing.Point(184, 51);
            this.allRadio.Name = "allRadio";
            this.allRadio.Size = new System.Drawing.Size(36, 17);
            this.allRadio.TabIndex = 5;
            this.allRadio.TabStop = true;
            this.allRadio.Text = "All";
            this.allRadio.UseVisualStyleBackColor = true;
            this.allRadio.CheckedChanged += new System.EventHandler(this.allRadio_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 469);
            this.Controls.Add(this.allRadio);
            this.Controls.Add(this.calendarRender);
            this.Controls.Add(this.monthRadio);
            this.Controls.Add(this.weekRadio);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Calender";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton weekRadio;
        private System.Windows.Forms.RadioButton monthRadio;
        private System.Windows.Forms.FlowLayoutPanel calendarRender;
        private System.Windows.Forms.RadioButton allRadio;
    }
}


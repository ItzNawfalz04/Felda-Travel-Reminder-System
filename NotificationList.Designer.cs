namespace Felda_Travel_Reminder_System
{
    partial class NotificationList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectedTimesLabel = new System.Windows.Forms.Label();
            this.SelectedDaysLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectedTimesLabel
            // 
            this.SelectedTimesLabel.AutoSize = true;
            this.SelectedTimesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTimesLabel.ForeColor = System.Drawing.Color.White;
            this.SelectedTimesLabel.Location = new System.Drawing.Point(26, 17);
            this.SelectedTimesLabel.Name = "SelectedTimesLabel";
            this.SelectedTimesLabel.Size = new System.Drawing.Size(61, 16);
            this.SelectedTimesLabel.TabIndex = 1;
            this.SelectedTimesLabel.Text = "6:00 AM";
            // 
            // SelectedDaysLabel
            // 
            this.SelectedDaysLabel.AutoSize = true;
            this.SelectedDaysLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedDaysLabel.ForeColor = System.Drawing.Color.White;
            this.SelectedDaysLabel.Location = new System.Drawing.Point(121, 17);
            this.SelectedDaysLabel.Name = "SelectedDaysLabel";
            this.SelectedDaysLabel.Size = new System.Drawing.Size(221, 16);
            this.SelectedDaysLabel.TabIndex = 2;
            this.SelectedDaysLabel.Text = "Mon | Tue | Wed | Thu | Fri | Sat | Sun";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(391, 8);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(80, 34);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // NotificationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SelectedDaysLabel);
            this.Controls.Add(this.SelectedTimesLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "NotificationList";
            this.Size = new System.Drawing.Size(510, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectedTimesLabel;
        private System.Windows.Forms.Label SelectedDaysLabel;
        private System.Windows.Forms.Button DeleteButton;
    }
}

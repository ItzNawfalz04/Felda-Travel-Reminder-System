namespace Felda_Travel_Reminder_System
{
    partial class MainMenuForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.ReminderFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.SourceCodeButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.CurrentDateLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.AddEventButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.ShowNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReminderFlowLayoutPanel
            // 
            this.ReminderFlowLayoutPanel.AutoScroll = true;
            this.ReminderFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.ReminderFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ReminderFlowLayoutPanel.Location = new System.Drawing.Point(234, 139);
            this.ReminderFlowLayoutPanel.Name = "ReminderFlowLayoutPanel";
            this.ReminderFlowLayoutPanel.Size = new System.Drawing.Size(800, 472);
            this.ReminderFlowLayoutPanel.TabIndex = 5;
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.DarkGray;
            this.TitlePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TitlePanel.Controls.Add(this.SourceCodeButton);
            this.TitlePanel.Controls.Add(this.label7);
            this.TitlePanel.Controls.Add(this.CurrentDateLabel);
            this.TitlePanel.Controls.Add(this.label5);
            this.TitlePanel.Controls.Add(this.CurrentTimeLabel);
            this.TitlePanel.Controls.Add(this.label2);
            this.TitlePanel.Controls.Add(this.pictureBox1);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(228, 616);
            this.TitlePanel.TabIndex = 7;
            this.TitlePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TitlePanel_Paint);
            // 
            // SourceCodeButton
            // 
            this.SourceCodeButton.Location = new System.Drawing.Point(58, 493);
            this.SourceCodeButton.Name = "SourceCodeButton";
            this.SourceCodeButton.Size = new System.Drawing.Size(107, 32);
            this.SourceCodeButton.TabIndex = 18;
            this.SourceCodeButton.Text = "Source Code";
            this.SourceCodeButton.UseVisualStyleBackColor = true;
            this.SourceCodeButton.Click += new System.EventHandler(this.SourceCodeButton_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 531);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 70);
            this.label7.TabIndex = 15;
            this.label7.Text = "© Copyright. | All Right Reserved.\r\nFelda Travel Sdn. Bhd.\r\nProgram Version : v1." +
    "0.1";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentDateLabel
            // 
            this.CurrentDateLabel.BackColor = System.Drawing.Color.White;
            this.CurrentDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CurrentDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentDateLabel.ForeColor = System.Drawing.Color.Black;
            this.CurrentDateLabel.Location = new System.Drawing.Point(28, 207);
            this.CurrentDateLabel.Name = "CurrentDateLabel";
            this.CurrentDateLabel.Size = new System.Drawing.Size(170, 25);
            this.CurrentDateLabel.TabIndex = 10;
            this.CurrentDateLabel.Text = "01/01/2024";
            this.CurrentDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Current Date:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.BackColor = System.Drawing.Color.White;
            this.CurrentTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CurrentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(58, 131);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(107, 25);
            this.CurrentTimeLabel.TabIndex = 8;
            this.CurrentTimeLabel.Text = "01:01:01";
            this.CurrentTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Current Time:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(325, 12);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(709, 27);
            this.SearchTextBox.TabIndex = 0;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // AddEventButton
            // 
            this.AddEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AddEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEventButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEventButton.ForeColor = System.Drawing.SystemColors.Control;
            this.AddEventButton.Location = new System.Drawing.Point(832, 46);
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(202, 35);
            this.AddEventButton.TabIndex = 7;
            this.AddEventButton.Text = "Add Event Reminder";
            this.AddEventButton.UseVisualStyleBackColor = false;
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.ClearFilterButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.StatusComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CategoryComboBox);
            this.groupBox1.Location = new System.Drawing.Point(234, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 79);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Reminder List";
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.Location = new System.Drawing.Point(358, 40);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(75, 26);
            this.ClearFilterButton.TabIndex = 13;
            this.ClearFilterButton.Text = "Clear";
            this.ClearFilterButton.UseVisualStyleBackColor = true;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(182, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Status:";
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Items.AddRange(new object[] {
            "Not Started Yet",
            "Ongoing",
            "Completed"});
            this.StatusComboBox.Location = new System.Drawing.Point(185, 40);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(156, 24);
            this.StatusComboBox.TabIndex = 12;
            this.StatusComboBox.SelectedIndexChanged += new System.EventHandler(this.StatusComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Category:";
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Items.AddRange(new object[] {
            "Certificate Renewal",
            "License Renewal",
            "Project",
            "Task",
            "Other"});
            this.CategoryComboBox.Location = new System.Drawing.Point(13, 40);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(156, 24);
            this.CategoryComboBox.TabIndex = 10;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // ShowNotification
            // 
            this.ShowNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("ShowNotification.Icon")));
            this.ShowNotification.Text = "Felda Travel Reminder System";
            this.ShowNotification.Visible = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(234, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Search:";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 616);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ReminderFlowLayoutPanel);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.AddEventButton);
            this.Controls.Add(this.SearchTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenuForm";
            this.Text = "Felda Travel Reminder System";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.TitlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel ReminderFlowLayoutPanel;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button AddEventButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CurrentDateLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.NotifyIcon ShowNotification;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ClearFilterButton;
        private System.Windows.Forms.Button SourceCodeButton;
        //private ReminderList reminderList1;
    }
}


namespace Felda_Travel_Reminder_System
{
    partial class AddReminderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReminderForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddEditLabel = new System.Windows.Forms.Label();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RemarksTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TickAllCheckBox = new System.Windows.Forms.GroupBox();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.TickAllBox = new System.Windows.Forms.CheckBox();
            this.DayCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AddNotificationButton = new System.Windows.Forms.Button();
            this.NotificationListFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EndsAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StartsAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TickAllCheckBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.AddEditLabel);
            this.panel1.Controls.Add(this.DiscardButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 65);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // AddEditLabel
            // 
            this.AddEditLabel.AutoSize = true;
            this.AddEditLabel.BackColor = System.Drawing.Color.Transparent;
            this.AddEditLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.AddEditLabel.ForeColor = System.Drawing.Color.White;
            this.AddEditLabel.Location = new System.Drawing.Point(15, 16);
            this.AddEditLabel.Name = "AddEditLabel";
            this.AddEditLabel.Size = new System.Drawing.Size(180, 29);
            this.AddEditLabel.TabIndex = 0;
            this.AddEditLabel.Text = "Add Reminder";
            this.AddEditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiscardButton
            // 
            this.DiscardButton.Location = new System.Drawing.Point(398, 16);
            this.DiscardButton.Name = "DiscardButton";
            this.DiscardButton.Size = new System.Drawing.Size(83, 33);
            this.DiscardButton.TabIndex = 16;
            this.DiscardButton.Text = "Discard";
            this.DiscardButton.UseVisualStyleBackColor = true;
            this.DiscardButton.Click += new System.EventHandler(this.DiscardButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(487, 16);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(83, 33);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(80, 27);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(464, 27);
            this.NameTextBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.RemarksTextBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.TickAllCheckBox);
            this.groupBox1.Controls.Add(this.NotificationListFlowLayoutPanel);
            this.groupBox1.Controls.Add(this.StatusComboBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CategoryComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.EndsAtDateTimePicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.StartsAtDateTimePicker);
            this.groupBox1.Controls.Add(this.NameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 609);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reminder Information";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 418);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Push Notification List:";
            // 
            // RemarksTextBox
            // 
            this.RemarksTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RemarksTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemarksTextBox.Location = new System.Drawing.Point(20, 149);
            this.RemarksTextBox.Multiline = true;
            this.RemarksTextBox.Name = "RemarksTextBox";
            this.RemarksTextBox.Size = new System.Drawing.Size(524, 73);
            this.RemarksTextBox.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "Remarks:";
            // 
            // TickAllCheckBox
            // 
            this.TickAllCheckBox.Controls.Add(this.TimePicker);
            this.TickAllCheckBox.Controls.Add(this.TickAllBox);
            this.TickAllCheckBox.Controls.Add(this.DayCheckedListBox);
            this.TickAllCheckBox.Controls.Add(this.label12);
            this.TickAllCheckBox.Controls.Add(this.label8);
            this.TickAllCheckBox.Controls.Add(this.AddNotificationButton);
            this.TickAllCheckBox.Location = new System.Drawing.Point(20, 288);
            this.TickAllCheckBox.Name = "TickAllCheckBox";
            this.TickAllCheckBox.Size = new System.Drawing.Size(524, 111);
            this.TickAllCheckBox.TabIndex = 18;
            this.TickAllCheckBox.TabStop = false;
            this.TickAllCheckBox.Text = "Add Notification";
            // 
            // TimePicker
            // 
            this.TimePicker.Checked = false;
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePicker.Location = new System.Drawing.Point(10, 45);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.ShowUpDown = true;
            this.TimePicker.Size = new System.Drawing.Size(159, 22);
            this.TimePicker.TabIndex = 0;
            this.TimePicker.Value = new System.DateTime(2025, 3, 22, 12, 30, 0, 0);
            // 
            // TickAllBox
            // 
            this.TickAllBox.AutoSize = true;
            this.TickAllBox.Location = new System.Drawing.Point(281, 50);
            this.TickAllBox.Name = "TickAllBox";
            this.TickAllBox.Size = new System.Drawing.Size(73, 20);
            this.TickAllBox.TabIndex = 25;
            this.TickAllBox.Text = "Tick All";
            this.TickAllBox.UseVisualStyleBackColor = true;
            this.TickAllBox.CheckedChanged += new System.EventHandler(this.TickAllBox_CheckedChanged);
            // 
            // DayCheckedListBox
            // 
            this.DayCheckedListBox.FormattingEnabled = true;
            this.DayCheckedListBox.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.DayCheckedListBox.Location = new System.Drawing.Point(363, 14);
            this.DayCheckedListBox.Name = "DayCheckedListBox";
            this.DayCheckedListBox.Size = new System.Drawing.Size(150, 89);
            this.DayCheckedListBox.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(301, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 18);
            this.label12.TabIndex = 23;
            this.label12.Text = "Day(s):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Time:";
            // 
            // AddNotificationButton
            // 
            this.AddNotificationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AddNotificationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNotificationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNotificationButton.ForeColor = System.Drawing.Color.White;
            this.AddNotificationButton.Location = new System.Drawing.Point(10, 73);
            this.AddNotificationButton.Name = "AddNotificationButton";
            this.AddNotificationButton.Size = new System.Drawing.Size(159, 30);
            this.AddNotificationButton.TabIndex = 17;
            this.AddNotificationButton.Text = "Add Notification";
            this.AddNotificationButton.UseVisualStyleBackColor = false;
            this.AddNotificationButton.Click += new System.EventHandler(this.AddNotificationButton_Click);
            // 
            // NotificationListFlowLayoutPanel
            // 
            this.NotificationListFlowLayoutPanel.AutoScroll = true;
            this.NotificationListFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.NotificationListFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NotificationListFlowLayoutPanel.ForeColor = System.Drawing.Color.Black;
            this.NotificationListFlowLayoutPanel.Location = new System.Drawing.Point(20, 441);
            this.NotificationListFlowLayoutPanel.Name = "NotificationListFlowLayoutPanel";
            this.NotificationListFlowLayoutPanel.Size = new System.Drawing.Size(524, 151);
            this.NotificationListFlowLayoutPanel.TabIndex = 14;
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Items.AddRange(new object[] {
            "Not Started Yet",
            "Ongoing",
            "Completed"});
            this.StatusComboBox.Location = new System.Drawing.Point(354, 243);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(182, 24);
            this.StatusComboBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(294, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Status:";
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Items.AddRange(new object[] {
            "Certificate Renewal",
            "License Renewal",
            "Project",
            "Task",
            "Other"});
            this.CategoryComboBox.Location = new System.Drawing.Point(94, 242);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(163, 24);
            this.CategoryComboBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Category:";
            // 
            // EndsAtDateTimePicker
            // 
            this.EndsAtDateTimePicker.Location = new System.Drawing.Point(298, 90);
            this.EndsAtDateTimePicker.Name = "EndsAtDateTimePicker";
            this.EndsAtDateTimePicker.Size = new System.Drawing.Size(246, 22);
            this.EndsAtDateTimePicker.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(294, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ends At:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Starts At:";
            // 
            // StartsAtDateTimePicker
            // 
            this.StartsAtDateTimePicker.Location = new System.Drawing.Point(20, 90);
            this.StartsAtDateTimePicker.Name = "StartsAtDateTimePicker";
            this.StartsAtDateTimePicker.Size = new System.Drawing.Size(246, 22);
            this.StartsAtDateTimePicker.TabIndex = 4;
            // 
            // AddReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 694);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddReminderForm";
            this.Text = "Add Reminder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TickAllCheckBox.ResumeLayout(false);
            this.TickAllCheckBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AddEditLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker EndsAtDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker StartsAtDateTimePicker;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel NotificationListFlowLayoutPanel;
        //private NotificationList notificationList1;
        private System.Windows.Forms.Button DiscardButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AddNotificationButton;
        private System.Windows.Forms.GroupBox TickAllCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox RemarksTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox DayCheckedListBox;
        private System.Windows.Forms.CheckBox TickAllBox;
        private System.Windows.Forms.DateTimePicker TimePicker;
        //private NotificationList notificationList2;
    }
}
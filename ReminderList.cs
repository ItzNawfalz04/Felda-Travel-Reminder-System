using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Felda_Travel_Reminder_System
{
    public partial class ReminderList : UserControl
    {
        public int EventId { get; private set; } // Store event ID
        private MainMenuForm mainMenuForm; // Reference to MainMenuForm
        private Color defaultBackColor; // Store default color

        public ReminderList(MainMenuForm mainMenu)
        {
            InitializeComponent();
            this.mainMenuForm = mainMenu;
            // Store default color
            defaultBackColor = this.BackColor;

            // Attach event handlers for hover effect
            this.MouseEnter += ReminderList_MouseEnter;
            this.MouseLeave += ReminderList_MouseLeave;
            this.Click += ReminderList_Click; // Attach click event
        }

        public void SetReminderData(int eventId, string name, string dueDate, int daysLeft, string status, string category)
        {
            EventId = eventId;
            EventNameLabel.Text = name;
            DueDateLabel.Text = dueDate;
            StatusLabel.Text = status;
            CategoryLabel.Text = category; // Show category

            int adjustedDaysLeft = (DateTime.Parse(dueDate) - DateTime.Today).Days;

            if (adjustedDaysLeft == 0)
            {
                DaysLeftLabel.Text = "Today";
            }
            else if (adjustedDaysLeft == 1)
            {
                DaysLeftLabel.Text = "Tomorrow";
            }
            else if (adjustedDaysLeft > 1)
            {
                DaysLeftLabel.Text = $"{adjustedDaysLeft} days left";
            }
            else
            {
                DaysLeftLabel.Text = $"Late {Math.Abs(adjustedDaysLeft)} days"; // Show "Late i days"
                DaysLeftLabel.ForeColor = Color.Red; // Make it visually stand out
            }

            // Change StatusIcon based on status
            switch (status)
            {
                case "Completed":
                    StatusIcon.Image = Properties.Resources.check_circle;
                    panel1.BackColor = Color.Lime;
                    StatusLabel.ForeColor = Color.Lime;
                    break;
                case "Ongoing":
                    StatusIcon.Image = Properties.Resources.minus_circle;
                    panel1.BackColor = Color.Gold;
                    StatusLabel.ForeColor = Color.Gold;
                    break;
                case "Not Started Yet":
                    StatusIcon.Image = Properties.Resources.cross_circle;
                    panel1.BackColor = Color.Red;
                    StatusLabel.ForeColor = Color.Red;
                    break;
                default:
                    StatusIcon.Image = null; // No image if status is unrecognized
                    break;
            }
        }

        // Hover effect - Change background color
        private void ReminderList_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkOrange; // Change to hover color
            this.Cursor = Cursors.Hand; // Change cursor to hand
        }

        // Reset to default when mouse leaves
        private void ReminderList_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = defaultBackColor; // Revert color
            this.Cursor = Cursors.Default; // Reset cursor
        }

        private void ReminderList_Click(object sender, EventArgs e)
        {
            AddReminderForm editForm = new AddReminderForm(mainMenuForm, EventId);
            editForm.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string reminderName = EventNameLabel.Text; // Get reminder name

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete \"{reminderName}\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeldaTravelReminder", "reminder.db");
                string connectionString = $"Data Source={dbPath};Version=3;";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // First, delete associated notifications
                    string deleteNotificationsQuery = "DELETE FROM notification WHERE event_id = @eventId";
                    using (SQLiteCommand deleteNotificationsCommand = new SQLiteCommand(deleteNotificationsQuery, connection))
                    {
                        deleteNotificationsCommand.Parameters.AddWithValue("@eventId", EventId);
                        deleteNotificationsCommand.ExecuteNonQuery();
                    }

                    // Then, delete the event itself
                    string deleteEventQuery = "DELETE FROM event WHERE Id = @eventId";
                    using (SQLiteCommand deleteEventCommand = new SQLiteCommand(deleteEventQuery, connection))
                    {
                        deleteEventCommand.Parameters.AddWithValue("@eventId", EventId);
                        deleteEventCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                // Show success message
                MessageBox.Show($"Reminder \"{reminderName}\" deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                mainMenuForm.RemoveReminder(this);
            }
        }
        public string GetReminderName()
        {
            return EventNameLabel.Text;
        }

        public string GetCategory()
        {
            return CategoryLabel.Text;
        }

        public string GetStatus()
        {
            return StatusLabel.Text;
        }
    }
}
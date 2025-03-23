using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Felda_Travel_Reminder_System
{
    public partial class AddReminderForm : Form
    {
        private MainMenuForm mainMenu;

        private int? eventId = null; // Store event ID if editing

        public AddReminderForm(MainMenuForm menuForm, int? eventId = null)
        {
            InitializeComponent();
            this.mainMenu = menuForm;
            this.eventId = eventId;

            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Refresh();

            // Set UI for Editing Mode or Adding Mode
            if (eventId.HasValue)
            {
                AddEditLabel.Text = "Edit Reminder";
                this.Text = "Edit Reminder";
                LoadEventData(eventId.Value);
                LoadNotifications();
            }
            else
            {
                AddEditLabel.Text = "Add Reminder";
                this.Text = "Add Reminder";
            }
        }

        private void LoadEventData(int eventId)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeldaTravelReminder", "reminder.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT name, remarks, starts_at, ends_at, category, status FROM event WHERE Id = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", eventId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NameTextBox.Text = reader["name"].ToString();
                            RemarksTextBox.Text = reader["remarks"].ToString();
                            CategoryComboBox.SelectedItem = reader["category"].ToString();
                            StatusComboBox.SelectedItem = reader["status"].ToString();
                            StartsAtDateTimePicker.Value = Convert.ToDateTime(reader["starts_at"]);
                            EndsAtDateTimePicker.Value = Convert.ToDateTime(reader["ends_at"]);
                        }
                    }
                }
                connection.Close();
            }
        }


        private void AddReminderForm_Load(object sender, EventArgs e)
        {
            // Set DateTimePicker format to show HH:mm AM/PM without seconds
            TimePicker.Format = DateTimePickerFormat.Custom;
            TimePicker.CustomFormat = "hh:mm tt";

            // Set DateTimePicker format to only show date
            StartsAtDateTimePicker.Format = DateTimePickerFormat.Custom;
            StartsAtDateTimePicker.CustomFormat = "dddd, dd MMM yyyy"; // Shows Day and Date

            EndsAtDateTimePicker.Format = DateTimePickerFormat.Custom;
            EndsAtDateTimePicker.CustomFormat = "dddd, dd MMM yyyy"; // Shows Day and Date

            TickAllBox.CheckedChanged += TickAllBox_CheckedChanged; // Attach the event


            if (eventId.HasValue)
            {
                LoadNotifications();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string remarks = RemarksTextBox.Text.Trim();
            string category = CategoryComboBox.SelectedItem?.ToString();
            string status = StatusComboBox.SelectedItem?.ToString();
            string startsAt = StartsAtDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endsAt = EndsAtDateTimePicker.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeldaTravelReminder", "reminder.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query;

                if (eventId.HasValue) // Update existing event
                {
                    query = "UPDATE event SET name = @name, remarks = @remarks, starts_at = @starts_at, ends_at = @ends_at, category = @category, status = @status WHERE Id = @id";
                }
                else // Insert new event
                {
                    query = "INSERT INTO event (name, remarks, starts_at, ends_at, category, status) VALUES (@name, @remarks, @starts_at, @ends_at, @category, @status)";
                }

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@remarks", remarks);
                    command.Parameters.AddWithValue("@starts_at", startsAt);
                    command.Parameters.AddWithValue("@ends_at", endsAt);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@status", status);

                    if (eventId.HasValue)
                    {
                        command.Parameters.AddWithValue("@id", eventId.Value);
                    }

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        if (!eventId.HasValue) // If new event, get last inserted ID
                        {
                            eventId = (int)connection.LastInsertRowId;
                        }

                        // Save notifications
                        string deleteQuery = "DELETE FROM notification WHERE event_id = @event_id";
                        using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@event_id", eventId.Value);
                            deleteCommand.ExecuteNonQuery();
                        }

                        foreach (NotificationList notification in NotificationListFlowLayoutPanel.Controls)
                        {
                            string insertQuery = "INSERT INTO notification (event_id, time, day) VALUES (@event_id, @time, @day)";

                            // Dictionary to map short names to full names
                            Dictionary<string, string> dayMapping = new Dictionary<string, string>()
                            {
                                { "Mon", "Monday" },
                                { "Tue", "Tuesday" },
                                { "Wed", "Wednesday" },
                                { "Thu", "Thursday" },
                                { "Fri", "Friday" },
                                { "Sat", "Saturday" },
                                { "Sun", "Sunday" }
                            };

                            foreach (string day in notification.GetDays())
                            {
                                string fullDay = dayMapping.ContainsKey(day) ? dayMapping[day] : day; // Convert to full name if necessary

                                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@event_id", eventId.Value);
                                    insertCommand.Parameters.AddWithValue("@time", notification.GetTime());
                                    insertCommand.Parameters.AddWithValue("@day", fullDay); // Save full name
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        MessageBox.Show("Reminder saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainMenu.LoadReminders();

                        if (eventId.HasValue)
                        {
                            this.Close();
                        }
                        else
                        {
                            ClearForm();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to save the reminder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearForm()
        {
            NameTextBox.Clear();
            RemarksTextBox.Clear();
            CategoryComboBox.SelectedIndex = -1;
            StatusComboBox.SelectedIndex = -1;
            StartsAtDateTimePicker.Value = DateTime.Now;
            EndsAtDateTimePicker.Value = DateTime.Now;
            NotificationListFlowLayoutPanel.Controls.Clear();
        }


        private void DiscardButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to discard?", "Confirm Discard", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void AddNotificationButton_Click(object sender, EventArgs e)
        {
            // Save selected time in 12-hour format (HH:mm AM/PM)
            string selectedTime = TimePicker.Value.ToString("hh:mm tt");

            List<string> selectedDays = new List<string>();

            foreach (object item in DayCheckedListBox.CheckedItems)
            {
                selectedDays.Add(item.ToString());
            }

            if (selectedDays.Count == 0)
            {
                MessageBox.Show("Please select at least one day.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if a notification with the same time already exists
            foreach (NotificationList notification in NotificationListFlowLayoutPanel.Controls)
            {
                if (notification.GetTime() == selectedTime)
                {
                    List<string> existingDays = notification.GetDays();
                    List<string> newDays = selectedDays.Except(existingDays).ToList();

                    if (newDays.Count == 0)
                    {
                        MessageBox.Show("The selected time and days already exist.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    existingDays.AddRange(newDays);
                    notification.UpdateDays(existingDays);
                    return;
                }
            }

            // Add Notification to UI
            NotificationList notificationItem = new NotificationList(eventId ?? -1, selectedTime, selectedDays, this);
            NotificationListFlowLayoutPanel.Controls.Add(notificationItem);
        }

        public void LoadNotifications()
        {
            NotificationListFlowLayoutPanel.Controls.Clear(); // Clear previous items

            if (!eventId.HasValue) return;

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeldaTravelReminder", "reminder.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, time, day FROM notification WHERE event_id = @event_id ORDER BY time";

                Dictionary<string, List<string>> groupedNotifications = new Dictionary<string, List<string>>();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@event_id", eventId.Value);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["id"].ToString();
                            string time = reader["time"].ToString();
                            string day = reader["day"].ToString();

                            if (!groupedNotifications.ContainsKey(time))
                            {
                                groupedNotifications[time] = new List<string>();
                            }
                            groupedNotifications[time].Add(day);
                        }
                    }
                }

                foreach (var entry in groupedNotifications)
                {
                    NotificationList notificationItem = new NotificationList(eventId.Value, entry.Key, entry.Value, this);
                    NotificationListFlowLayoutPanel.Controls.Add(notificationItem);
                }

                connection.Close();
            }
        }

        private void TickAllBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkAll = TickAllBox.Checked; // Get the checkbox state

            for (int i = 0; i < DayCheckedListBox.Items.Count; i++)
            {
                DayCheckedListBox.SetItemChecked(i, checkAll); // Check/uncheck all items
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Create a linear gradient brush for smooth blending
            using (LinearGradientBrush lgb = new LinearGradientBrush(
                new Rectangle(0, 0, panel1.Width, panel1.Height),
                Color.Black, // Temporary (Overridden by ColorBlend)
                Color.Black, // Temporary (Overridden by ColorBlend)
                LinearGradientMode.Vertical)) // Top to Bottom Gradient
            {
                // Define multiple colors and positions for blending
                ColorBlend cb = new ColorBlend();
                cb.Colors = new Color[]
                {
                    ColorTranslator.FromHtml("#ec541c"), // Dark Orange (Top)
                    ColorTranslator.FromHtml("#f03b33"), // Vibrant Red-Orange (Middle)
                    ColorTranslator.FromHtml("#f58521")  // Bright Orange (Bottom)
                };

                cb.Positions = new float[] { 0.0f, 0.5f, 1.0f }; // Position of each color

                // Apply color blend to the brush
                lgb.InterpolationColors = cb;

                // Fill the panel with the gradient
                e.Graphics.FillRectangle(lgb, new Rectangle(0, 0, panel1.Width, panel1.Height));
            }
        }
    }
}
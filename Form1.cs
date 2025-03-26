using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.Win32; // Required for registry
using System.Globalization; // For formatting the day name
using System.IO; // For formatting the day name

namespace Felda_Travel_Reminder_System
{
    public partial class MainMenuForm : Form
    {
        private Timer timer;
        // Declare NotifyIcon at class level to persist
        private NotifyIcon notifyIcon;
        // List to store active notifications
        private List<NotifyIcon> activeNotifications = new List<NotifyIcon>();

        public MainMenuForm()
        {
            InitializeComponent();

            // Initialize and configure the timer
            timer = new Timer();
            timer.Interval = 1000; // Update every 1 second
            timer.Tick += Timer_Tick;
            timer.Start(); // Start the timer
            EnsureDatabaseExists();

        }

        void EnsureDatabaseExists()
        {
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeldaTravelReminder");
            string dbPath = Path.Combine(appDataFolder, "reminder.db");
            string dbSourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "reminder.db"); // Original database

            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }

            if (!File.Exists(dbPath))
            {
                File.Copy(dbSourcePath, dbPath, true); // Copy database to AppData
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update time in 24-hour format
            CurrentTimeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");

            // Update date in "Day, dd/MM/yyyy" format
            CurrentDateLabel.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");

            // Check for notifications every minute (when seconds are 00)
            if (DateTime.Now.Second == 0)
            {
                CheckAndShowNotifications();
            }
        }

        private void CheckAndShowNotifications()
        {
            string currentDay = DateTime.Now.ToString("dddd");
            string currentTime = DateTime.Now.ToString("hh:mm tt");

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeldaTravelReminder", "reminder.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT e.name, e.ends_at, e.status 
            FROM notification n 
            INNER JOIN event e ON n.event_id = e.id 
            WHERE n.day = @currentDay 
              AND n.time = @currentTime 
              AND (e.status = 'Ongoing' OR e.status = 'Not Started Yet');"; // Only show for valid statuses

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@currentDay", currentDay);
                    command.Parameters.AddWithValue("@currentTime", currentTime);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string eventName = reader["name"].ToString();
                            DateTime endsAt = Convert.ToDateTime(reader["ends_at"]);
                            int daysLeft = (endsAt.Date - DateTime.Now.Date).Days;
                            string status = reader["status"].ToString();

                            if (status == "Ongoing" || status == "Not Started Yet") // Double-checking, just in case
                            {
                                string dueDate = endsAt.ToString("dd/MM/yyyy");
                                ShowReminderNotification(eventName, dueDate, daysLeft);
                            }
                        }
                    }
                }
                connection.Close();
            }
        }

        public void RemoveReminder(ReminderList reminder)
        {
            ReminderFlowLayoutPanel.Controls.Remove(reminder);
        }

        // Create a separate method to generate unique notifications
        private void ShowReminderNotification(string eventName, string dueDate, int daysLeft)
        {
            ShowNotification.BalloonTipTitle = "Event Reminder";
            ShowNotification.BalloonTipText = $"Event: {eventName}\nDue Date: {dueDate}\nDays Left: {daysLeft}";
            ShowNotification.Visible = true;

            // Show the notification
            ShowNotification.ShowBalloonTip(5000);

            // Ensure clicking the notification brings MainMenuForm to front
            ShowNotification.BalloonTipClicked += (sender, e) =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    this.TopMost = true;  // Set to topmost
                    this.BringToFront();
                    this.Activate();
                    this.TopMost = false; // Reset to avoid interfering with other apps
                });
            };
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            SetStartup(true);

            TitlePanel.Paint += new PaintEventHandler(TitlePanel_Paint);
            TitlePanel.Refresh();
            LoadReminders();
            this.Text = "Felda Travel Reminder System";

            // Ensure the NotifyIcon is visible
            ShowNotification.Visible = true;
            ShowNotification.Text = "Felda Travel Reminder System";

            // Restore window when double-clicked in tray
            ShowNotification.DoubleClick += (s, ev) => OpenMainMenu();

            // Create context menu for NotifyIcon
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open Reminder", null, (s, ev) => OpenMainMenu());
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", null, ExitApplication);

            contextMenu.Items.Add(openMenuItem);
            contextMenu.Items.Add(exitMenuItem);
            ShowNotification.ContextMenuStrip = contextMenu;

            // **Show the form when opened from shortcut**
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            ShowInTaskbar = true;

            CategoryComboBox.SelectedIndexChanged += CategoryComboBox_SelectedIndexChanged;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            ClearFilterButton.Click += ClearFilterButton_Click;
        }

        // Open the main menu
        private void OpenMainMenu()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true; // Show in taskbar
            this.BringToFront();
        }

        // Minimize to system tray when the user clicks "X" (close)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide(); // Hide the form instead
                ShowInTaskbar = false; // Remove from taskbar
                ShowNotification.Visible = true; // Ensure the tray icon is visible
            }
        }

        // Exit application from tray menu
        private void ExitApplication(object sender, EventArgs e)
        {
            ShowNotification.Visible = false; // Hide the tray icon before exit
            ShowNotification.Dispose(); // Properly dispose the icon
            Application.Exit();
        }

        private void SetStartup(bool enable)
        {
            string appName = "ReminderApp";
            string appPath = Application.ExecutablePath;
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (enable)
            {
                registryKey.SetValue(appName, appPath);
            }
            else
            {
                registryKey.DeleteValue(appName, false);
            }
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            AddReminderForm addReminderForm = new AddReminderForm(this); // Pass `this`
            addReminderForm.ShowDialog();
        }

        public void LoadReminders()
        {
            ReminderFlowLayoutPanel.Controls.Clear(); // Clear previous items

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeldaTravelReminder", "reminder.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, name, ends_at, category, status FROM event"; // Include category

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int eventId = Convert.ToInt32(reader["Id"]); // Get event ID
                            string name = reader["name"].ToString();
                            string dueDate = Convert.ToDateTime(reader["ends_at"]).ToString("ddd, dd MMM yyyy");
                            string category = reader["category"].ToString(); // Get category
                            string status = reader["status"].ToString();

                            DateTime endDate = Convert.ToDateTime(reader["ends_at"]);
                            int daysLeft = (endDate - DateTime.Now).Days;

                            ReminderList reminderItem = new ReminderList(this); // Pass MainMenuForm reference
                            reminderItem.SetReminderData(eventId, name, dueDate, daysLeft, status, category); // Pass category

                            ReminderFlowLayoutPanel.Controls.Add(reminderItem);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void TitlePanel_Paint(object sender, PaintEventArgs e)
        {
            // Create a linear gradient brush for smooth blending
            using (LinearGradientBrush lgb = new LinearGradientBrush(
                new Rectangle(0, 0, TitlePanel.Width, TitlePanel.Height),
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
                e.Graphics.FillRectangle(lgb, new Rectangle(0, 0, TitlePanel.Width, TitlePanel.Height));
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = SearchTextBox.Text.Trim().ToLower();

            foreach (Control control in ReminderFlowLayoutPanel.Controls)
            {
                if (control is ReminderList reminder)
                {
                    bool isVisible = reminder.GetReminderName().ToLower().Contains(searchQuery);
                    reminder.Visible = isVisible;
                }
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryComboBox.SelectedItem != null)
            {
                StatusComboBox.SelectedIndex = -1; // Clear StatusComboBox selection
                FilterReminders();
            }
        }


        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StatusComboBox.SelectedItem != null)
            {
                CategoryComboBox.SelectedIndex = -1; // Clear CategoryComboBox selection
                FilterReminders();
            }
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            CategoryComboBox.SelectedIndex = -1; // Reset category filter
            StatusComboBox.SelectedIndex = -1; // Reset status filter
            FilterReminders(); // Reload all reminders
        }

        private void FilterReminders()
        {
            string selectedCategory = CategoryComboBox.SelectedItem?.ToString();
            string selectedStatus = StatusComboBox.SelectedItem?.ToString();

            foreach (Control control in ReminderFlowLayoutPanel.Controls)
            {
                if (control is ReminderList reminder)
                {
                    bool categoryMatch = string.IsNullOrEmpty(selectedCategory) || reminder.GetCategory().Equals(selectedCategory, StringComparison.OrdinalIgnoreCase);
                    bool statusMatch = string.IsNullOrEmpty(selectedStatus) || reminder.GetStatus().Equals(selectedStatus, StringComparison.OrdinalIgnoreCase);

                    reminder.Visible = categoryMatch && statusMatch;
                }
            }
        }

        private void SourceCodeButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/ItzNawfalz04/Felda-Travel-Reminder-System/",
                UseShellExecute = true
            });
        }
    }
}
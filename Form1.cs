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
            CurrentTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");

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
            string currentTime = DateTime.Now.ToString("HH:mm");

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeldaTravelReminder", "reminder.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT e.name, e.ends_at 
                FROM notification n 
                INNER JOIN event e ON n.event_id = e.id 
                WHERE n.day = @currentDay AND n.time = @currentTime;";

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

                            string dueDate = endsAt.ToString("dd/MM/yyyy");
                            string message = $"Event: {eventName}\nDue Date: {dueDate}\nDays Left: {daysLeft}";

                            // Call the method to show each notification separately
                            ShowReminderNotification(eventName, dueDate, daysLeft);
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
            NotifyIcon notification = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true,
                BalloonTipTitle = "Event Reminder",
                BalloonTipText = $"Event: {eventName}\nDue Date: {dueDate}\nDays Left: {daysLeft}"
            };

            // Store the notification to prevent it from being garbage collected
            activeNotifications.Add(notification);

            // Show the notification
            notification.ShowBalloonTip(5000); // Show for 5 seconds

            // Event: When notification is clicked, open the main menu
            notification.BalloonTipClicked += (sender, e) => OpenMainMenu();

            // Dispose of it properly after it's closed
            notification.BalloonTipClosed += (sender, e) =>
            {
                notification.Dispose();
                activeNotifications.Remove(notification); // Remove from list to free memory
            };
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            TitlePanel.Paint += new PaintEventHandler(TitlePanel_Paint); // Attach Paint Event
            TitlePanel.Refresh(); // Redraw panel
            LoadReminders();
            SetStartup(true);

            // Ensure ShowNotification is visible
            ShowNotification.Visible = true;
            ShowNotification.Text = "Reminder System";

            // Restore window when double-clicked
            ShowNotification.DoubleClick += (s, ev) => OpenMainMenu();

            // Create context menu for NotifyIcon
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // "Open Reminder" option
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open Reminder", null, (s, ev) => OpenMainMenu());
            contextMenu.Items.Add(openMenuItem);

            // "Exit" option
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", null, ExitApplication);
            contextMenu.Items.Add(exitMenuItem);

            // Assign the menu to the NotifyIcon
            ShowNotification.ContextMenuStrip = contextMenu;
        }

        // Open the main menu
        private void OpenMainMenu()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        // Minimize to system tray when the user clicks "X" (close)
        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancel close action
                this.Hide(); // Hide the form instead
            }
        }

        // Exit application from tray menu
        private void ExitApplication(object sender, EventArgs e)
        {
            ShowNotification.Dispose();
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
    }
}
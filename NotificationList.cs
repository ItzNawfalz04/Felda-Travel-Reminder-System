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

namespace Felda_Travel_Reminder_System
{
    public partial class NotificationList : UserControl
    {
        //private int notificationId;
        private int eventId;
        private AddReminderForm parentForm;

        public string GetTime()
        {
            return SelectedTimesLabel.Text;
        }

        public List<string> GetDays()
        {
            return SelectedDaysLabel.Text.Split('|').Select(d => d.Trim()).ToList();
        }

        public NotificationList(int eventId, string time, List<string> days, AddReminderForm parentForm)
        {
            InitializeComponent();
            this.eventId = eventId;
            this.parentForm = parentForm;

            SelectedTimesLabel.Text = time;
            // Convert full day names to three-letter abbreviations
            Dictionary<string, string> dayAbbreviations = new Dictionary<string, string>()
            {
                { "Monday", "Mon" },
                { "Tuesday", "Tue" },
                { "Wednesday", "Wed" },
                { "Thursday", "Thu" },
                { "Friday", "Fri" },
                { "Saturday", "Sat" },
                { "Sunday", "Sun" }
            };

            List<string> abbreviatedDays = days
                .Select(day => dayAbbreviations.ContainsKey(day) ? dayAbbreviations[day] : day)
                .ToList();

            SelectedDaysLabel.Text = string.Join(" | ", abbreviatedDays);
        }

        public void UpdateDays(List<string> days)
        {
            Dictionary<string, string> dayAbbreviations = new Dictionary<string, string>()
            {
                { "Monday", "Mon" },
                { "Tuesday", "Tue" },
                { "Wednesday", "Wed" },
                { "Thursday", "Thu" },
                { "Friday", "Fri" },
                { "Saturday", "Sat" },
                { "Sunday", "Sun" }
            };

            List<string> weekOrder = new List<string> { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

            List<string> abbreviatedDays = days
                .Select(day => dayAbbreviations.ContainsKey(day) ? dayAbbreviations[day] : day)
                .Distinct()
                .OrderBy(d => weekOrder.IndexOf(d)) // Sort based on predefined order
                .ToList();

            SelectedDaysLabel.Text = string.Join(" | ", abbreviatedDays);
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}

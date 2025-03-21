using System;
using System.Data.SQLite;
using System.IO;

public static class DatabaseHelper
{
    private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "reminder.db");
    private static string connectionString = $"Data Source={dbPath};Version=3;";

    public static void InitializeDatabase()
    {
        try
        {
            string directoryPath = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                Console.WriteLine("Database file created at: " + dbPath);

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection))
                    {
                        // Create 'event' table
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS event (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                name TEXT NOT NULL,
                                remarks TEXT,
                                starts_at TEXT NOT NULL,
                                ends_at TEXT NOT NULL,
                                category TEXT,
                                status TEXT
                            );";
                        command.ExecuteNonQuery();

                        // Create 'notification' table
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS notification (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                event_id INTEGER NOT NULL,
                                time TEXT NOT NULL,
                                day TEXT NOT NULL,
                                FOREIGN KEY (event_id) REFERENCES event(Id) ON DELETE CASCADE
                            );";
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Tables created successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error initializing database: " + ex.Message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Felda_Travel_Reminder_System
{
    internal static class Program
    {
        private static Mutex mutex = new Mutex(true, "FeldaTravelReminderSystem");

        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                // If another instance is already running, focus on it
                BringExistingInstanceToFront();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm());

            mutex.ReleaseMutex();
        }

        private static void BringExistingInstanceToFront()
        {
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (process.Id != currentProcess.Id)
                {
                    IntPtr handle = process.MainWindowHandle;
                    if (handle == IntPtr.Zero)
                    {
                        // If the window handle is zero, find the main window using a different approach
                        handle = FindMainWindow(process);
                    }

                    if (handle != IntPtr.Zero)
                    {
                        // Restore and bring the window to the front
                        NativeMethods.ShowWindow(handle, 9); // SW_RESTORE
                        NativeMethods.SetForegroundWindow(handle);
                    }
                    break;
                }
            }
        }

        // Try to find the main window handle if process.MainWindowHandle is zero
        private static IntPtr FindMainWindow(Process process)
        {
            IntPtr handle = IntPtr.Zero;
            foreach (ProcessThread thread in process.Threads)
            {
                handle = NativeMethods.FindWindow(null, "Felda Travel Reminder System"); // Match the window title
                if (handle != IntPtr.Zero)
                    break;
            }
            return handle;
        }


        internal static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        }
    }
}

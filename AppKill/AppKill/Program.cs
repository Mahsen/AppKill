using System;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace AppKill
{
    internal class Program
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void Main(string[] args)
        {

            IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(h, 0);
            String[] Apps = { "csp_ctrlagent", "csp_ctrlagentsvc" };
            while (true)
            {
                foreach (string App in Apps)
                {
                    try
                    {
                        Process[] processes;
                        processes = Process.GetProcessesByName(App);
                        foreach (Process proc in processes)
                        {
                            proc.Kill();
                            proc.WaitForExit(5000);
                        }

                        Console.WriteLine(App + " Killed");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Thread.Sleep(6000);
                }
            }            
        }
    }
}

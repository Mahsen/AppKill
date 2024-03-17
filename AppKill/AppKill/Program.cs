using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppKill
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    String App = "csp_ctrlagent.exe";

                    Process[] processes;
                    processes = Process.GetProcessesByName(App);
                    foreach (Process proc in processes)
                    {
                        proc.Kill();
                        proc.WaitForExit(5000);
                    }

                    Console.WriteLine(App + " Killed");
                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }            
        }
    }
}

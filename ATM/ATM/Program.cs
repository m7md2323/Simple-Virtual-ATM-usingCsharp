using System;
using static System.Console;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{   
    internal class Program
    {
        
        static void Main()
        {
            while (true)
            {
                States.loadFrontScreen();
                States.logInScreen();
                WriteLine("DO YOU WANT TO PROCEED ?(Y/N)");
                if (ReadLine().ToLower() == "n") {Clear(); continue;}
                System.Threading.Thread.Sleep(2500);
                Clear();
                States.Menu();
                System.Threading.Thread.Sleep(2500);
                Clear();

            }

        }
    }
}

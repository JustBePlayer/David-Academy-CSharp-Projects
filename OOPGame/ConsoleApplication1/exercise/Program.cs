using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace exercise
{
    class Program
    {
        static void Main(string[] args)
        {
           /*
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                DateTime time = DateTime.Now;              // Use current time
                string format = "HH:mm:ss ";    // Use this format
                Console.WriteLine(time.ToString(format));
            }
            */

            
            Timer t = new Timer(TimerCallback, null, 2000, 1000);
            // Wait for the user to hit <Enter>
            Console.ReadLine();
            


            
        }

        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("In TimerCallback: " + DateTime.Now.ToString("HH:mm:ss"));
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }
    }
}

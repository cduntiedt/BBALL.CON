using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Helpers
{
    public static class TimeoutHelper
    {
        public static int callCount = 0;

        public static void Count()
        {
            callCount += 1;
            if (callCount >= 9)
            {
                Wait(2000);
                callCount = 0;
            }
        }

        public static void APICount(int count)
        {
            count += 1;
            if (count >= 9)
            {
                Wait(2000);
            }
        }

        public static void Wait(int milliseconds)
        {
            Console.WriteLine("Wait...");
            Thread.Sleep(milliseconds);
            Console.WriteLine("Continue...");
        }
    }
}

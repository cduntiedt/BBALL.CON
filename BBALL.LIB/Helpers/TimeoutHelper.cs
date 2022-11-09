using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BBALL.LIB.Helpers
{
    public static class TimeoutHelper
    {
        public static int callCount = 0;
        public static int timeoutCount = 0;

        public static async Task Count()
        {
            callCount += 1;
            //var waitIncrement = callCount / 10;

            if(callCount % 2 == 0)
            {
                timeoutCount += 1;
            }

            if (timeoutCount >= 1)
            {
                await Wait(2000 * timeoutCount);
            }
        }

        public static async Task APICount(int count)
        {
            count += 1;
            if (count >= 9)
            {
                await Wait(2000);
            }
        }

        public static async Task Wait(int milliseconds)
        {
            await Task.Delay(milliseconds);
        }
    }
}

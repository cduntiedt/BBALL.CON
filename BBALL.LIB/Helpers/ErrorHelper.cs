using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBALL.LIB.Helpers
{
    public static class ErrorHelper
    {
        private static int _errorCount = 0;
        public static void Reset()
        {
            _errorCount = 0;
        }

        public static int Increment()
        {
            _errorCount += 1;
            Terminate();
            return _errorCount;
        }

        public static void Terminate()
        {
            if (_errorCount > 5)
            {
                Environment.Exit(_errorCount);
            }
        }
    }
}

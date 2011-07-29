using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubRefactor.Library
{
    public static class Extensions
    {
        public static bool IsNegative(this int number)
        {
            return number < 0;
        }
    }
}

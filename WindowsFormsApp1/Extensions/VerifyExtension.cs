using System;
using System.Collections.Generic;
using System.Text;

namespace RunBatForm.Extensions
{
    public static class VerifyExtension
    {
        public static bool NotNullOrEmpty(this string target)
        {
            return !string.IsNullOrEmpty(target);
        }

        public static bool NotNullOrEmpty<T>(this T target)
        {
            return target != null;
        }
    }
}

using IISTA.Common.Enums;

namespace IISTA.Common.ExtentionMethods
{
    public static class CustomExtentions
    {
        /// <summary>
        /// Compares two string if they are equal.
        /// </summary>
        /// <param name="firstString">First string.</param>
        /// <param name="secondString">Second string.</param>
        /// <returns></returns>
        public static bool CustomStringCompareTo(this string firstString, string secondString)
        {
            if (string.Compare(firstString, secondString) == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares if the first string is equals to the Http verb(Method).
        /// </summary>
        /// <param name="firstString">The first string.</param>
        /// <param name="httpVerb">The HTTP verb.</param>
        /// <returns></returns>
        public static bool CustomStringCompareTo(this string firstString, HttpVerbs httpVerb)
        {
            if (string.Compare(firstString, httpVerb.ToString()) == 0)
            {
                return true;
            }

            return false;
        }


        
    }
}

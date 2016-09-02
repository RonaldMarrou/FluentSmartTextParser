namespace FluentSmartTextParser.Extension
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return false;
            }

            if(string.IsNullOrEmpty(value.Trim()))
            {
                return false;
            }

            return true;
        }
    }
}

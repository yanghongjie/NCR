namespace NCR.Extensions
{
    public static class ObjectExtension
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsNull(this object obj)
        {
            return null == obj;
        }

        public static bool IsNotNull(this object obj)
        {
            return null != obj;
        }
    }
}
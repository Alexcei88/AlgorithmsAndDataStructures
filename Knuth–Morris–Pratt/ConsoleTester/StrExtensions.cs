namespace ConsoleTester
{
    public static class StrExtensions
    {
        public static string Left(this string str, int length) => str.Substring(0, length);

        public static string Right(this string str, int length) => str.Substring(str.Length - length);
    }
}
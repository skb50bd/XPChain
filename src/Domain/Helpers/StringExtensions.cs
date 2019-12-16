using static System.Convert;
using static System.Text.Encoding;

namespace Domain
{
    public static class StringExtensions
    {
        public static byte[] ToByteArray(this string str) =>
            UTF8.GetBytes(str?.Trim() ?? "");

        public static string ToBase64(this string str) =>
            ToBase64String((str?.Trim() ?? "").ToByteArray());

        public static string ToBase64(this byte[] array) =>
            ToBase64String(array);

        public static string GetLast(this string source, int length) =>
            length >= source.Length 
                ? source 
                : "..." + source.Substring(source.Length - length);

        public static string RemoveWhiteSpaces(this string source) =>
            source.Replace(" ", string.Empty);
    }
}

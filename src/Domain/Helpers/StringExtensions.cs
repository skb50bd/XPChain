namespace Domain
{
    public static class StringExtensions
    {
        public static byte[] ToByteArray(this string str) =>
            System.Text.Encoding.UTF8.GetBytes(str?.Trim() ?? "");

        public static string ToBase64(this string str) =>
            System.Convert.ToBase64String((str?.Trim() ?? "").ToByteArray());

        public static string ToBase64(this byte[] array) =>
            System.Convert.ToBase64String(array);
    }
}

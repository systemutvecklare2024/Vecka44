namespace StudentRegistry.Util
{
    public static class PrintHelper
    {
        public static string ClearScreen { get; } = "\x1b[m\x1b[2J\x1b[H"; // ANSI ESC Code

        public static void Clear()
        {
            Console.Write(ClearScreen);
        }

        public static void Halt()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}

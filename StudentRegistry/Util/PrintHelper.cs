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

        public static string GetStringInput(string inputText)
        {
            string firstName;
            while (true)
            {
                Console.Write($"{inputText}: ");
                firstName = Console.ReadLine();
                if (string.IsNullOrEmpty(firstName)) {
                    Console.WriteLine("Invalid input, try again.");
                    continue;
                }
                return firstName;
            }
        }
    }
}

namespace StudentRegistry.Student
{
    internal class StudentPrinter
    {
        private static string _tableFormat = "{0,-7} {1, -25} {2,-15}";
        public static void PrintStudentRow(Student student)
        {
            Console.WriteLine($"{student.StudentId}. {student.FirstName} {student.LastName} - {student.City}");
        }

        public static void PrintStudentTable(IEnumerable<Student> students)
        {
            var spacer = new String('-', 9);
            Console.WriteLine("Students");
            Console.WriteLine(spacer);

            Console.WriteLine(_tableFormat, "Id", "Name", "City");

            foreach (Student student in students)
            {
                Console.WriteLine(_tableFormat, student.StudentId, $"{student.FirstName} {student.LastName}", student.City);
            }
            Console.WriteLine(spacer);
        }

        public static void PrintStudentInfo(Student student)
        {
            var spacer = new String('-', 17);
            Console.WriteLine("Edit Student Info");
            Console.WriteLine(spacer);
            Console.WriteLine($"1. Firstname: {student.FirstName}");
            Console.WriteLine($"2. Lastname: {student.LastName}");
            Console.WriteLine($"3. City: {student.City}");
            Console.WriteLine($"0. Back");
            Console.WriteLine(spacer);
        }
    }
}

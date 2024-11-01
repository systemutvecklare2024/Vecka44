using StudentRegistry.Student;
using StudentRegistry.Util;

namespace StudentRegistry.Student.Menu
{
    internal class StudentFindMenu : StudentBaseMenu
    {
        public StudentFindMenu(StudentBaseMenu menu) : base(menu)
        {
        }

        public override void Show()
        {
            PrintHelper.Clear();
            Console.WriteLine("Enter search phrase, or write q to go back.");
            Console.Write("Search phrase: ");
            var searchPhrase = Console.ReadLine();
            if (string.IsNullOrEmpty(searchPhrase))
            {
                Console.WriteLine("Invalid search phrase");
                PrintHelper.Halt();
                return;
            }
            if (searchPhrase.Equals("q"))
            {
                PrintHelper.Halt();
                App.ChangeMenu(new StudentMainMenu(this));
                return;
            }

            var students = StudentController.FindStudentByPhrase(searchPhrase);
            if (students == null || students.Count() <= 0)
            {
                Console.WriteLine("Unable to find any students.");
                PrintHelper.Halt();
                App.ChangeMenu(new StudentMainMenu(this));
                return;
            }

            StudentPrinter.PrintStudentTable(students);
            Console.WriteLine("Input id to select student, or q to go back.");
            Console.Write("Input: ");
            var id = Console.ReadLine();
            if (int.TryParse(id, out var result))
            {
                var student = StudentController.GetStudentById(result);
                if (student == null)
                {
                    Console.WriteLine("Unable to find student with that id");
                    PrintHelper.Halt();
                    return;

                }
                App.ChangeMenu(new StudentViewMenu(this, student));
            }
        }
    }
}
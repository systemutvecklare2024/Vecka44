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
            Console.WriteLine("Enter search phrase");
            Console.WriteLine("0. Back");

            var searchPhrase = PrintHelper.GetStringInput("Search phrase");

            if (searchPhrase.Equals("0"))
            {
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

            if (students.Count() == 1)
            {
                App.ChangeMenu(new StudentViewMenu(this, students.First()));
                return;
            }

            StudentPrinter.PrintStudentTable(students);

            Console.WriteLine("Input id to select student");
            Console.WriteLine("0. Back");
            
            var id = PrintHelper.GetStringInput("Id");
            
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
using StudentRegistry.Util;

namespace StudentRegistry.Student.Menu
{
    internal class StudentMainMenu : StudentBaseMenu
    {

        // Menu alternatives
        const string CreateStudent = "1";
        const string FindStudent = "2";
        const string ListAllStudents = "3";
        const string Back = "0";

        public StudentMainMenu(App app, StudentController studentController) : base(app, studentController) { }

        public StudentMainMenu(StudentBaseMenu menu) : base(menu) { }

        public override void Show()
        {
            PrintHelper.Clear();
            Console.WriteLine("1. Register new student");
            Console.WriteLine("2. Find student");
            Console.WriteLine("3. List all students");
            Console.WriteLine("0. Back");

            var response = PrintHelper.GetStringInput("Choice");

            if (string.IsNullOrEmpty(response))
            {
                return;
            }

            switch (response)
            {
                case CreateStudent:
                    App.ChangeMenu(new StudentCreateMenu(this));
                    break;
                case FindStudent:
                    App.ChangeMenu(new StudentFindMenu(this));
                    break;
                case ListAllStudents:
                    App.ChangeMenu(new StudentListAllMenu(this));
                    break;
                case Back:
                    Environment.Exit(0);
                    break;
                default:
                    return;
            }

            PrintHelper.Clear();
        }
    }
}

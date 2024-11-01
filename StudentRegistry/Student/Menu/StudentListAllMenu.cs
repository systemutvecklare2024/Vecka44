using StudentRegistry.Util;

namespace StudentRegistry.Student.Menu
{
    internal class StudentListAllMenu : StudentBaseMenu
    {
        public StudentListAllMenu(StudentBaseMenu menu) : base(menu) { }

        public override void Show()
        {
            PrintHelper.Clear();

            var students = StudentController.GetAllStudents();
            if (students != null)
            {
                StudentPrinter.PrintStudentTable(students);
                App.ChangeMenu(new StudentMainMenu(this));
            }
            else
            {
                Console.WriteLine("No students found.");
            }

            PrintHelper.Halt();
        }
    }
}
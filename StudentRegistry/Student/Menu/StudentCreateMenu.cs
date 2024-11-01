using StudentRegistry.Util;

namespace StudentRegistry.Student.Menu
{
    internal class StudentCreateMenu : StudentBaseMenu
    {
        public StudentCreateMenu(StudentBaseMenu menu) : base(menu) { }

        public override void Show()
        {
            PrintHelper.Clear();

            Console.WriteLine("Create Student");
            var firstName = PrintHelper.GetStringInput("Firstname");
            var lastName = PrintHelper.GetStringInput("Surname");
            var city = PrintHelper.GetStringInput("City");

            StudentController.CreateStudent(firstName, lastName, city);

            App.ChangeMenu(new StudentMainMenu(this));
            PrintHelper.Halt();
        }
    }
}
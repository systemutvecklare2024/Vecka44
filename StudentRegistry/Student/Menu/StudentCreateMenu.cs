using StudentRegistry.Util;

namespace StudentRegistry.Student.Menu
{
    internal class StudentCreateMenu : StudentBaseMenu
    {
        public StudentCreateMenu(StudentBaseMenu menu) : base(menu)
        {
        }

        public override void Show()
        {
            PrintHelper.Clear();

            Console.WriteLine("Create Student");
            Console.Write("Firstname: ");
            var firstName = Console.ReadLine();
            Console.Write("Lastname: ");
            var lastName = Console.ReadLine();
            Console.Write("City: ");
            var city = Console.ReadLine();

            StudentController.CreateStudent(new StudentDto(firstName, lastName, city));

            App.ChangeMenu(new StudentMainMenu(this));
            PrintHelper.Halt();
            PrintHelper.Clear();
        }
    }
}
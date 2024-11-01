using StudentRegistry.Util;

namespace StudentRegistry.Student.Menu
{
    internal class StudentViewMenu : StudentBaseMenu
    {
        private const string FirstName = "1";
        private const string LastName = "2";
        private const string City = "3";

        private Student student;

        public StudentViewMenu(StudentBaseMenu menu, Student student) : base(menu)
        {
            this.student = student;
        }

        public override void Show()
        {
            PrintHelper.Clear();
            StudentPrinter.PrintStudentInfo(student);

            Console.WriteLine("q to go back");
            Console.WriteLine("Select option.");
            Console.Write("Choice: ");

            var response = Console.ReadLine();

            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine("Invalid option.");
                PrintHelper.Halt();
                return;
            }
            if (response.Equals("q"))
            {
                PrintHelper.Halt();
                App.ChangeMenu(new StudentMainMenu(this));
                return;
            }

            switch (response)
            {
                case FirstName:
                    student.FirstName = ReadNewValue("Firstname");
                    break;
                case LastName:
                    student.FirstName = ReadNewValue("Surname");
                    break;
                case City:
                    student.City = ReadNewValue("City");
                    break;
                default:
                    return;
            }

            StudentController.Update(student);
            Console.WriteLine("Student has been updated.");
            PrintHelper.Halt();
        }

        private void UpdateLastName()
        {
            var lname = Console.ReadLine();
            if (!string.IsNullOrEmpty(lname))
            {
                student.LastName = lname;
                StudentController.Update(student);
                Console.WriteLine("Surname has been updated.");
            }
        }

        private void UpdateCity()
        {
            var city = Console.ReadLine();
            if (!string.IsNullOrEmpty(city))
            {
                student.LastName = city;
                StudentController.Update(student);
                Console.WriteLine("City has been updated.");
            }
        }

        private string ReadNewValue(string field)
        {
            Console.WriteLine($"Update {field}");
            while (true)
            {
                Console.Write("New value: ");
                var response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    // Could add more validation here...
                    return response;
                }
            }
        }
    }
}
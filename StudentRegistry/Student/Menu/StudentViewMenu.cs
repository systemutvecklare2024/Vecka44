using StudentRegistry.Util;

namespace StudentRegistry.Student.Menu
{
    internal class StudentViewMenu : StudentBaseMenu
    {
        // Menu alternatives
        private const string Back = "0";
        private const string FirstName = "1";
        private const string LastName = "2";
        private const string City = "3";

        private Student _student;

        public StudentViewMenu(StudentBaseMenu menu, Student student) : base(menu)
        {
            this._student = student;
        }

        public override void Show()
        {
            PrintHelper.Clear();

            StudentPrinter.PrintStudentInfo(_student);

            var response = PrintHelper.GetStringInput("Choice");

            switch (response)
            {
                case FirstName:
                    StudentController.Update(_student, ReadNewValue("Firstname"), StudentField.FirstName);
                    break;
                case LastName:
                    StudentController.Update(_student, ReadNewValue("Lastname"), StudentField.LastName);
                    break;
                case City:
                    StudentController.Update(_student, ReadNewValue("City"), StudentField.City);
                    break;
                case Back:
                    App.ChangeMenu(new StudentMainMenu(this));
                    return;
                default:
                    return;
            }
            
            PrintHelper.Halt();
        }

        private string ReadNewValue(string field)
        {
            Console.WriteLine($"Update {field}");
            var response = PrintHelper.GetStringInput("New value");

            return response;
        }
    }
}
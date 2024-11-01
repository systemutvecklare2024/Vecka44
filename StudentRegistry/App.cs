using StudentRegistry.Student.Menu;

namespace StudentRegistry
{
    internal class App
    {
        StudentBaseMenu menu;
        public App() {
            menu = new StudentMainMenu(this, new Student.StudentController(new Student.StudentDbContext()));
        }

        public void Run()
        {
            while (true)
            {
                menu.Show();
            }
        }


        public void ChangeMenu(StudentBaseMenu newMenu)
        {
            menu = newMenu;
        }
    }
}

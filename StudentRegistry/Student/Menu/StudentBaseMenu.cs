namespace StudentRegistry.Student.Menu
{
    internal abstract class StudentBaseMenu
    {
        public App App { get; set; }
        public StudentController StudentController { get; set; }

        public StudentBaseMenu(App app, StudentController studentController)
        {
            App = app;
            StudentController = studentController;
        }

        public StudentBaseMenu(StudentBaseMenu menu)
        {
            App = menu.App;
            StudentController = menu.StudentController;
        }
        public abstract void Show();
    }
}

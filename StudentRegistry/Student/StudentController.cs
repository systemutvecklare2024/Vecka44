namespace StudentRegistry.Student
{
    internal class StudentController
    {
        private StudentRepository _studentRepository;

        public StudentController(StudentDbContext context)
        {
            _studentRepository = new StudentRepository(context);
        }

        public void CreateStudent(string firstName, string lastName, string city)
        {
            Student student = new Student { FirstName = firstName, LastName = lastName, City = city};
            _studentRepository.Add(student);
            _studentRepository.Save();
        }

        internal IEnumerable<Student> FindStudentByPhrase(string searchPhrase)
        {
            return _studentRepository.FindByPhrase(searchPhrase);
        }

        internal IEnumerable<Student>? GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        internal Student? GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        internal void Update(Student student, string value, StudentField field)
        {
            switch (field)
            {
                case StudentField.FirstName:
                    student.FirstName = value;
                    break;
                case StudentField.LastName:
                    student.LastName = value;
                    break;
                case StudentField.City:
                    student.City = value;
                    break;
                default:
                    break;
            }
            _studentRepository.Update(student);
            _studentRepository.Save();
        }
    }
}

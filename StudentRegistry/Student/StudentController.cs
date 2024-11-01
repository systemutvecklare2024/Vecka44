namespace StudentRegistry.Student
{
    internal class StudentController
    {
        private StudentRepository _studentRepository;

        public StudentController(StudentDbContext context)
        {
            _studentRepository = new StudentRepository(context);
        }

        public void CreateStudent(StudentDto studentDto)
        {
            Student student = new Student { FirstName = studentDto.FirstName, LastName = studentDto.LastName, City = studentDto.City};
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

        internal void Update(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}

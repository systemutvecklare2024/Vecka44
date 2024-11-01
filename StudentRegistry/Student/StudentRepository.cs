using Microsoft.EntityFrameworkCore;

namespace StudentRegistry.Student
{
    internal class StudentRepository
    {
        private StudentDbContext _dbContext;

        public StudentRepository(StudentDbContext context)
        {
            _dbContext = context;
        }

        public Student? GetById(int id) => _dbContext.Students.Find(id);
        public IEnumerable<Student>? GetAll() => _dbContext.Students;

        public void Add(Student student)
        {
            _dbContext.Add(student);
        }

        public void Update(Student student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
        }

        public void Delete(Student student)
        {
            _dbContext.Remove(student);
        }

        public void Delete(int id)
        {
            var student = _dbContext.Students.Find(id);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        internal IEnumerable<Student> FindByPhrase(string searchPhrase)
        {
            return _dbContext.Students.
                Where(
                    x => x.FirstName.Contains(searchPhrase) ||
                    x.LastName.Contains(searchPhrase) ||
                    x.City.Contains(searchPhrase)
                 );
        }
    }
}
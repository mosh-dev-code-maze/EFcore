using System.Collections.Generic;
using System.Linq;
using crud.Models.Repository;

namespace crud.Models.DataManager
{
    public class StudentManager : IDataRepository<Student>
    {
        private readonly RepositoryContext repositoryContext;

        public StudentManager(RepositoryContext rcontext)
        {
            this.repositoryContext = rcontext;
        }

        public void Add(Student entity)
        {
            repositoryContext.Student.Add(entity);
            repositoryContext.SaveChanges();
        }

        public void Delete(Student entity)
        {
            repositoryContext.Student.Remove(entity);
            repositoryContext.SaveChanges();
        }

        public Student Get(int id)
        {
            return repositoryContext.Student.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return repositoryContext.Student.ToList();
        }

        public void Update(Student dbEntity, Student entity)
        {
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.Age = entity.Age;
            dbEntity.PhoneNumber = entity.PhoneNumber;
            dbEntity.Email = entity.Email;
            repositoryContext.SaveChanges();
        }
    }
}

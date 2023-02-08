using HRSystem.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace HRSystem.DAO
{
    public class OnBoardingDAO
    {
        private readonly HRDbContext _dbContext;

        public OnBoardingDAO(HRDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public void InsertForm(Person person) {
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
        }

        //async method
        //public async Task InsertFormAsync() {
           
        //    using (IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync())
        //    {
        //    }
        //}

        //test1
        public List<Person> GetAllPeople() {
            List<Person> people = new List<Person>();

            people = _dbContext.Persons.ToList();

            return people;
        }

        //test2
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users = _dbContext.Users.ToList();
            return users;
        }

        public string AddFile() {
            string res = "";
            return res;
        }
        
    }
}

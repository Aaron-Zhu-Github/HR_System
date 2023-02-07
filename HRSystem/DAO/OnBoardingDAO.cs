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


        public async Task InsertForm(FormDataContainer formDataContainer) {
           
            using (IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                //try
                //{
                //    //Add person table info
                //    //await _dbContext.Persons.AddAsync(formDataContainer.person);
                //    //await _dbContext.SaveChangesAsync();
                //    ////Add employee table info
                //    //await _dbContext.Employees.AddAsync(formDataContainer.employee);
                //    //await _dbContext.SaveChangesAsync();
                //    //add contactlist to contact table

                //    transaction.Commit();

                //}
                //catch (Exception ex)
                //{
                //    transaction.Rollback();
                //    Console.WriteLine(ex.Message);
                //}
            }

        }

        //test
        public List<Person> GetAllPeople() {
            List<Person> people = new List<Person>();

            people = _dbContext.Persons.ToList();

            return people;
        }

        //test
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users = _dbContext.Users.ToList();
            return users;
        }
        
    }
}

using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using HRSystem.Models;

namespace HRSystem.DAO
{
	public class PersonInfoDAO
	{
		private readonly HRDbContext _dbContext;

		public PersonInfoDAO(HRDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		//get user by userid
		public User GetUserByID(int userid)
		{
            return _dbContext.Users.Where(u => u.Id == userid).FirstOrDefault();
		}

		//get person by pid
		public Person GetPerson(int pid)
		{
			//var test = _dbContext.Persons.ToList();

            return _dbContext.Persons.Where(p => p.Id == pid).FirstOrDefault();
		}

		//get address by pid
		public List<Address> GetAddress(int pid)
		{
			return _dbContext.Addresses.Where(a => a.PersonId == pid).ToList();
		}

        //get contact by pid
        public List<Contact> GetContact(int pid)
        {
            return _dbContext.Contacts.Where(c => c.PersonId == pid).ToList();
        }

		//get employee by pid
		public Employee GetEmployee(int pid)
		{
			return _dbContext.Employees.Where(e => e.PersonId == pid).SingleOrDefault();
        }

    }
}


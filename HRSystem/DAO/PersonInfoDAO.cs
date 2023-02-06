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
			var test = _dbContext.Users.Select(u => u).ToList();
            return _dbContext.Users.Where(u => u.Id == userid).FirstOrDefault();
		}

		//get person by pid
		public Person GetPerson(int pid)
		{
			return _dbContext.Persons.SingleOrDefault(p => p.Id == pid);
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
    }
}


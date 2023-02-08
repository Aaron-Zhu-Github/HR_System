using System;
using HRSystem.DAO;
using HRSystem.Models;
using HRSystem.DTO;

namespace HRSystem.Services
{
	public class PersonInfoService
	{
		private readonly PersonInfoDAO _personInfoDAO;
        private readonly HRDbContext _dbContext;

        public PersonInfoService(PersonInfoDAO personInfoDAO, HRDbContext dbContext)
		{
			_personInfoDAO = personInfoDAO;
			_dbContext = dbContext;
		}

		//Name Section
		public NameSec GetNameSec(int pid)
		{
			var res = new NameSec();
			res.person = _personInfoDAO.GetPerson(pid);
			//res.avatar
			//if (res.person.SSN != null)
			//{
   //             string ssn_full = res.person.SSN;
   //             res.person.SSN = ssn_full.Substring(5);
   //         }

            return res;
		}

		public void UpdateNameSec(NameSec nameSec)
		{
			_personInfoDAO.UpdatePerson(nameSec.person);
			//avatar
		}

		//Address sec
		public AddressSec GetAddressSec(int pid)
		{
			var res = new AddressSec();
			res.Addresses = _personInfoDAO.GetAddress(pid);

            return res;
        }

        public void UpdateAddressSec(AddressSec addressSec)
        {
            foreach(var item in addressSec.Addresses)
			{
				_personInfoDAO.UpdateAddress(item);
			}
        }

        //Contact Info
        public Person GetContactSec(int pid)
		{
			var res = new Person();
			res = _personInfoDAO.GetPerson(pid);

            return res;
        }

        public void UpdateContactSec(Person person)
        {
			_personInfoDAO.UpdateContact(person);
        }

        //Employment sec
        public Employee GetEmployeeSec(int pid)
		{
            var res = new Employee();
            res = _personInfoDAO.GetEmployee(pid);

            return res;
        }

        public void UpdateEmployeeSec(Employee employee)
        {
            _personInfoDAO.UpdateEmployee(employee);
        }

        //Emergency Contact sec
        public EmergencyContactSec GetEmergencyContactSec(int pid)
		{
            var res = new EmergencyContactSec();
			res.emergencyContacts = new List<EmergencyContact>();
            var em_contacts = _personInfoDAO.GetContact(pid)
				.Where(c => c.isEmergency == true)
				.ToList();
			foreach (var item in em_contacts)
			{
				var new_elem = new EmergencyContact();
				new_elem.Address = _personInfoDAO.GetAddress(pid).FirstOrDefault();
                new_elem.person = _personInfoDAO.GetPerson(pid);
				res.emergencyContacts.Add(new_elem);
            }

			return res;
        }

        public void UpdateEmergencyContactSec(EmergencyContactSec emergencyContactSec)
        {
			foreach(var item in emergencyContactSec.emergencyContacts)
			{
                _personInfoDAO.UpdateEmergency(item);
            }
			
        }

        //Document Sec 
        public PersonalDocSec GetPersonalDocSec(int pid)
		{
			var res = new PersonalDocSec();
			res.personalDocuments = _personInfoDAO.GetPersonalDocuments(pid)
				.OrderByDescending(x => x.CreatedDate)
				.ToList();

			return res;
        }

		public void UpdateDocument(PersonalDocSec docSec)
		{
			foreach(var item in docSec.personalDocuments)
			{
				_personInfoDAO.UpdateDocument(item);
			}
		}
		


	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HRSystem.DAO;
using HRSystem.Models;
using HRSystem.Services;
using HRSystem.DTO;
using System.Security.Cryptography;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRSystem.Controllers
{
    [ApiController]
    [Route("api/PersonalInformation")]
    public class PersonInfoController : ControllerBase
    {
        private readonly PersonInfoDAO _personInfoDAO;
        private readonly PersonInfoService _personInfoService;

        public PersonInfoController(PersonInfoDAO personInfoDAO, PersonInfoService personInfoService)
        {
            _personInfoDAO = personInfoDAO;
            _personInfoService = personInfoService;
        }


        [HttpGet("name/{pid}")]
        public ActionResult<NameSec> GetNameSec(int pid)
        {
            var model = _personInfoService.GetNameSec(pid);
            if (model != null)
                return Ok(model);
            else
                return NoContent();
        }

        [HttpGet("address/{pid}")]
        public ActionResult<AddressSec> GetAddressSec(int pid)
        {
            var model = _personInfoService.GetAddressSec(pid);
            if (model != null)
                return Ok(model);
            else
                return NoContent();
        }

        [HttpGet("contact/{pid}")]
        public ActionResult<Person> GetContactSec(int pid)
        {
            var model = _personInfoService.GetContactSec(pid);
            if (model != null)
                return Ok(model);
            else
                return NoContent();
        }

        [HttpGet("employment/{pid}")]
        public ActionResult<Employee> GetEmployeeSec(int pid)
        {
            var model = _personInfoService.GetEmployeeSec(pid);
            if (model != null)
                return Ok(model);
            else
                return NoContent();
        }

        [HttpGet("emergencycontact/{pid}")]
        public ActionResult<EmergencyContactSec> GetEmergencyContactSec(int pid)
        {
            var model = _personInfoService.GetEmergencyContactSec(pid);
            if (model != null)
                return Ok(model);
            else
                return NoContent();
        }

        [HttpGet("document/{pid}")]
        public ActionResult<PersonalDocSec> GetPersonalDocSec(int pid)
        {
            var model = _personInfoService.GetPersonalDocSec(pid);
            if (model != null)
                return Ok(model);
            else
                return NoContent();
        }


        // Edit
        [HttpPost("name")]
        public void UpdateNameSec([FromBody] NameSec nameSec)
        {
            _personInfoService.UpdateNameSec(nameSec);
        }

        [HttpPost("address")]
        public void UpdateAddressSec([FromBody] AddressSec addressSec)
        {
            _personInfoService.UpdateAddressSec(addressSec);
        }

        [HttpPost("contact")]
        public void UpdateContactSec([FromBody] Person person)
        {
            _personInfoService.UpdateContactSec(person);
        }

        [HttpPost("employment")]
        public void UpdateEmployeeSec(Employee employee)
        {
            _personInfoService.UpdateEmployeeSec(employee);
        }

        [HttpPost("emergencycontact")]
        public void UpdateEmergencyContactSec(EmergencyContactSec emergencyContactSec)
        {
            _personInfoService.UpdateEmergencyContactSec(emergencyContactSec);
        }

        [HttpPost("document")]
        public void UpdateDocument(PersonalDocSec docSec)
        {
            _personInfoService.UpdateDocument(docSec);
        }

    }
}


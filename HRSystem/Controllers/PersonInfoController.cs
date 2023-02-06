using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HRSystem.DAO;
using HRSystem.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRSystem.Controllers
{
    public class PersonInfoController : ControllerBase
    {
        private readonly PersonInfoDAO _personInfoDAO;
        //private readonly ILogger _logger;

        public PersonInfoController(PersonInfoDAO personInfoDAO)
        {
            _personInfoDAO = personInfoDAO;
            //_logger = logger;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet("person/name/{userid}")]
        public ActionResult<Person> GetNameSec(int userid)
        {
            //try
            //{
            //    int pid = _personInfoDAO.GetUserByID(userid).PersonID;
            //    if (pid != null)
            //    {
            //        var res = _personInfoDAO.GetPerson(pid);
            //        return Ok(res);
            //    }

            //} catch (Exception ex)
            //{
            //    _logger.LogError(ex, ex.Message);
            //}
            //return NoContent();

            var test = _personInfoDAO.GetUserByID(userid);
            int pid = _personInfoDAO.GetUserByID(userid).PersonId;
            if (pid != null)
            {
                var res = _personInfoDAO.GetPerson(pid);
                return Ok(res);
            }

            return NoContent();
        }

        //public ActionResult<Address>


    }

}


using HRSystem.DAO;
using HRSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    [ApiController]
    [Route("api/apply")]
    public class OnBoardingController:ControllerBase
    {
        private readonly OnBoardingDAO _onBoardingDAO;

        public OnBoardingController(OnBoardingDAO onBoardingDAO) {
            _onBoardingDAO= onBoardingDAO;
        }

        //actions

        //test case 1
        [HttpGet("GetAllPeople")]
        public IActionResult GetAllPeople()
        {
            _ = new List<Person>();
            try
            {
                List<Person> people = _onBoardingDAO.GetAllPeople();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //test case 2
        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            //_ = new List<Person>();
            try
            {
                List<User> people = _onBoardingDAO.GetUsers();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Sync Action test
        [HttpPost("Form")]
        public IActionResult AddForm([FromBody] Person person)
        {
            //try
            //{
                _onBoardingDAO.InsertForm(person);
                return Ok("Succeed");
            //}
            //catch (Exception ex)
            //{
                //return BadRequest(ex.Message);
            //}
        }

        //Async Action

        //[HttpPost("Form")]
        //public async Task<IActionResult> AddApplication([FromBody] FormDataContainer formDataContainer) {
        //    try {
        //        await _onBoardingDAO.InsertForm(formDataContainer);
        //        return Ok("Succeed");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //Add a file
        [HttpPost]
        [Route("AddFileDetails")]
        public IActionResult AddFile()
        {
            //string result = "";
            //try
            //{
            //    PersonalDocument objFile = new PersonalDocument();
            //    result = _onBoardingDAO.AddFile();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return Ok();
        }

    }
}

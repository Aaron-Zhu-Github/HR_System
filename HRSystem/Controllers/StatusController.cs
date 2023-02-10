namespace HRSystem.Controllers
{
    using System.Security.Claims;
    using HRSystem.DAO;
    using HRSystem.DTO;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    public class StatusController:ControllerBase
    {
        private readonly ILogger<StatusController> _logger;

        private readonly HRDbContext _dbContext;

        public StatusController(ILogger<StatusController> logger, HRDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("/api/GetStatus")]
        public async Task<ActionResult> GetStatus()
        {
            var personId = Convert.ToInt32(User.FindFirstValue("PersonId"));
            var role = User.FindFirstValue("Role");

            if(role == "HR")
                return Ok(new StatusResponse() { Status = "HRStatus" });

            var employee = await _dbContext.Employees.Where(e=>e.PersonId== personId).FirstOrDefaultAsync();
            if(employee == null || employee.Id == 0)
            {
                return Ok(new StatusResponse() { Status = "Open" });
            }
            var applicationWorkFlow= await _dbContext.ApplicationWorkFlows.FirstOrDefaultAsync(a => a.EmployeeId == employee.Id && a.Type== "Onboarding");
            if(applicationWorkFlow == null)
            {
                _dbContext.ApplicationWorkFlows.Add(new Models.ApplicationWorkFlow()
                {
                    EmployeeId = employee.Id,
                    CreatedDate= DateTime.Now,
                    Status= "Open",
                    Type= "Onboarding"
                });

                return Ok(new StatusResponse() { Status = "Open" });
            }
            return Ok(new StatusResponse() { Status = applicationWorkFlow?.Status?? "Open" });
        }
    }
}

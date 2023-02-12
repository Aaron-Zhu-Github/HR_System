using HRSystem.DAO;
using HRSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using HRSystem.DTO;
using System.Security.Claims;

namespace HRSystem.Controllers
{
    [ApiController]
    //[Route("/House")]
    public class HouseController : ControllerBase
    {
        private readonly ILogger<HouseController> _logger;

        private readonly HRDbContext _dbContext;
        private readonly HouseDAO _houseDAO;


        public HouseController(ILogger<HouseController> logger, HRDbContext dbContext, HouseDAO houseDAO)
        {
            _logger = logger;

            _dbContext = dbContext;

            _houseDAO = houseDAO;
        }

        // Get House Detail
        [HttpGet("/houseDetail")]
        public List<HouseDetail> gethouseDetail()
        {
            return _houseDAO.viewHouseDetail();
        }

        //[HR] Add House
        [HttpPost("/addHouse")]
        public ActionResult<House> createHouse([FromBody] House house)
        {
            _houseDAO.addHouse(house);
            return Ok(house);
        }

        //[HR] Delete House
        [HttpDelete("/deleteHouse/{id:int}")]
        public ActionResult<House> deleteHouse([FromRoute] int id)
        {
            _houseDAO.removeHouse(id);
            return Ok("House "+ id + " Removed");
        }

        // [HR] View House Detail
        [HttpGet("/houseDetailHR")]
        public List<HouseDetailHR> gethouseDetailHR()
        {
            return _houseDAO.viewHouseDetailHR();
        }

        // Create Facility Report
        [HttpPost("/addReport")]
        public ActionResult<CreateFacilityReport> createReport([FromBody] CreateFacilityReport createFacilityReport)
        {
            var pid = Convert.ToInt32(User.FindFirstValue("PersonId"));
            _houseDAO.sendReport(createFacilityReport, pid);
            return Ok(createFacilityReport);
        }

        // [HR] View History Report with Comments
        [HttpGet("/viewHistoryReport")]
        public List<FacilityReport> viewHistoryReport()
        {
            return _houseDAO.viewReport();
        }

        // View History Report by Employee ID
        [HttpGet("/viewHistoryReportById")]
        public List<FacilityReport> viewHistoryReportById()
        {
            var pid = Convert.ToInt32(User.FindFirstValue("PersonId"));
            return _houseDAO.viewReportById(pid);
        }

        //Add Comments by ReportID
        [HttpPost("/addComment")]
        public ActionResult createComment([FromBody] CreateFacilityDetail createFacilityDetail)
        {
            
            _houseDAO.addComment(createFacilityDetail);

            return Ok(createFacilityDetail);
        }

        //View Comments by ReportID
        [HttpGet("/editComment/{id:int}")]
        public ActionResult editComment([FromRoute] int id)
        {
            var result = _houseDAO.getComment().Where(c => c.ReportID == id).FirstOrDefault();
            return Ok(result);
        }

        //Edit Comments
        [HttpPatch("/editComment")]
        public ActionResult editComment([FromBody] CreateFacilityDetail createFacilityDetail)
        {
            _houseDAO.updateComment(createFacilityDetail);
            return Ok(createFacilityDetail);
        }
    }
}


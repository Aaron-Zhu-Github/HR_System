using HRSystem.DAO;
using HRSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using HRSystem.DTO;

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

        // Create Facility Report
        [HttpPost("/addReport")]
        public ActionResult<CreateFacilityReport> createReport([FromBody] CreateFacilityReport createFacilityReport)
        {
            _houseDAO.sendReport(createFacilityReport);
            return Ok(createFacilityReport);
        }

        // NA
        [HttpGet("/viewHistoryReport")]
        public List<FacilityReport> viewHistoryReport()
        {
            return _dbContext.FacilityReports.ToList();
        }

        //Add Comments
        [HttpPost("/addComment")]
        public ActionResult createComment([FromBody] CreateFacilityDetail createFacilityDetail)
        {
            
            _houseDAO.addComment(createFacilityDetail);

            return Ok(createFacilityDetail);
        }

        //Edit Comments
        [HttpGet("/editComment")]
        public ActionResult editComment([FromRoute] int id)
        {
            var result = _houseDAO.getComment().Where(c => c.ID == id).FirstOrDefault();
            return Ok(result);
        }

        [HttpPost("/editComment")]
        public ActionResult editComment([FromBody] FacilityReportDetail facilityReportDetail)
        {
            _houseDAO.updateComment(facilityReportDetail);
            return Ok(facilityReportDetail);
        }
    }
}


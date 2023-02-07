using HRSystem.DAO;
using HRSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace HRSystem.Controllers
{
    [ApiController]
    //[Route("/House")]
    public class HouseController : ControllerBase
    {
        private readonly ILogger<HouseController> _logger;

        private readonly HRDbContext _dbContext;


        public HouseController(ILogger<HouseController> logger, HRDbContext dbContext)
        {
            _logger = logger;

            _dbContext = dbContext;
        }

        [HttpGet("/viewHouse")]
        public List<House> getAllHouses()
        {
            return _dbContext.Houses.ToList();
        }
    }
}


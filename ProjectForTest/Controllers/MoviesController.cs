using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectForTest.Models;
using ProjectForTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForTest.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IFilmSpecialist _filmSpecialist;
        private readonly ILogger<HomeController> _logger;

        public MoviesController(ILogger<HomeController> logger, IFilmSpecialist filmSpecialist)
        {
            _logger = logger;
            _filmSpecialist = filmSpecialist;
        }
        [HttpGet("getMovie")]
        public Movie GetMovie()
        {
            _logger.Log(LogLevel.Information, "Ask the film specialist.");
            var movie = _filmSpecialist.SuggestMovie();
            _logger.Log(LogLevel.Information, $"Suggested movie : {movie}");
            return movie;
        }
    }
}

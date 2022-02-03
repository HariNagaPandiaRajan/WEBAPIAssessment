using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assesment1.Controllers.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assesment1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class moviescontroller : ControllerBase
    {
        private readonly moviedbcontext moviecontext;
        public moviescontroller(moviedbcontext movieDbContext)
        {
            moviecontext = movieDbContext;
        }



        [HttpGet]
        public IEnumerable<movies> GetMovies()
        {
            return moviecontext.movie.ToList();
        }
        [HttpGet("GetMovieById")]
        public movies GetMovieById(int Id)
        {
            return moviecontext.movie.Find(Id);
        }
        [HttpPost("InsertMovie")]
        public IActionResult InsertMovie([FromBody] movies movie)
        {
            if (movie.Id.ToString() != "")
            {

                moviecontext.movie.Add(movie);
                moviecontext.SaveChanges();
                return Ok("Movie data saved successfully");
            }
            else
                return BadRequest();
        }
        [HttpPut("UpdateTutorial")]
        public IActionResult Updatemovie([FromBody] movies movie)
        {
            if (movie.Id.ToString() != "")
            {

                moviecontext.Entry(movie).State = EntityState.Modified;
                moviecontext.SaveChanges();
                return Ok("movie data updated successfully");
            }
            else
                return BadRequest();
        }
        [HttpDelete("DeleteTutorial")]
        public IActionResult DeleteTutorial(int tutorialId)
        {
           
            var result = moviecontext.movie.Find(tutorialId);
            moviecontext.movie.Remove(result);
            moviecontext.SaveChanges();
            return Ok("movie data deleted successfully");
        }
    }
}

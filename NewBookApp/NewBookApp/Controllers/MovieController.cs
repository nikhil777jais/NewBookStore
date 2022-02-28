using Microsoft.AspNetCore.Mvc;
using NewBookApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace NewBookApp.Controllers
{
    public class MovieController : Controller
    {

        private readonly MovieDbContext _db;
        public MovieController(MovieDbContext db)
        {
            _db = db;
        }

        [Route("movies", Name = "getallmovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movlst = await _db.Movies.ToListAsync();
            return View("Index", movlst);
        }

        [Route("movie/{id}", Name = "getmoviebyid")]
        public async Task<IActionResult> GetAllMovieById(int id)
        {
            Movie movie = await _db.Movies.FindAsync(id);
            return View("MovieDetails", movie);
        }

        [Route("addmovie", Name = "addmovie")]
        public async Task<IActionResult> AddNewMovie()
        {
            return View("AddMovie");
        }

        [HttpPost]
        [Route("addmovie", Name = "addmovie")]
        public async Task<IActionResult> AddNewMovie([Bind("Name", "Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //Movie newmovie = new Movie { Name = movie.Name, Rating = movie.Rating.HasValue ? movie.Rating.Value : 0 };
                if (ModelState.IsValid)
                {
                    await _db.Movies.AddAsync(movie);
                    await _db.SaveChangesAsync();
                    return RedirectToRoute("addmovie");
                }
            }
            return View("AddMovie");
        }

        [Route("deletemoviebyid/{id}", Name = "deletemoviebyid")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            Movie movie = await _db.Movies.FindAsync(id);
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
            return RedirectToRoute("getallmovies");
        }

        [Route("editmoviebyid/{id}", Name = "editmoviebyid")]
        public async Task<IActionResult> EditMovie(int id)
        {
            Movie movie = await _db.Movies.FindAsync(id);
            return View("EditMovie", movie);
        }

        [HttpPost]
        [Route("editmoviebyid/{id}", Name = "editmoviebyid")]
        public async Task<IActionResult> EditMovie(int id, [Bind("Id", "Name", "Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Update(movie);
                await _db.SaveChangesAsync();
                return RedirectToRoute("getallmovies");
            }
            return View("EditMovie", movie);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        [Route("movies/released/{year}/{month}")]

        public ActionResult ByReleaseYear(int year, int month)
        {
            if (year < 1900)
                return Content(year + " is not in a 4 digit format.");
            if (month > 12 || month < 01)
                return Content(month + "is not in a 2 digit format.");
            return Content(year + "/" + month);
        }


        // GET: Movies
        // [Route("movies/random")]
        //
        // public ActionResult Random()
        // {
        //     var shrek = new Movie() { Id = 1, Name = "Shrek" };
        //     var customers = new List<Customer>
        //     {
        //         new Customer {Name = "Cust 1"},
        //         new Customer {Name = "Cust 2"}
        //     };
        //     var viewModel = new RandomMovieViewModel
        //     {
        //         Movie = shrek,
        //         Customers = customers
        //     };
        //     return View(viewModel);
        // }
        
        // GET MOVIE DETAILS
        [Route("movies/details/{id}")]
        public ActionResult MovieDetail(int id)
        {
            var flick = GetMovies().SingleOrDefault(m => m.Id == id);
            if (flick == null)
            {
                return HttpNotFound();
            }
            return Content(flick.Name);
        }
        
        // GET ALL MOVIES
        [Route("movies")]
        public ActionResult Index()
        {
            var movies = GetMovies();

            var viewModel = new AllMoviesViewModel
            {
                Movies = movies
            };
            return View(viewModel);
        }

        private static List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Psycho"},
                new Movie {Id = 2, Name = "The Birds"},
                new Movie {Id = 3, Name = "Vertigo"},
            };
        }
        
        

        

        //public actionresult byreleasedate(int year, int month)
        //{
        //    return content(year + "/" + month);
        //}

    }

}
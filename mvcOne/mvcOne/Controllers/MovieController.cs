using mvcOne.Models;
using mvcOne.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcOne.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movform=new MovieFormViewModel
                {
                    Movie=movie,
                    MovieType=_context.MovieType.ToList()
                };
                return View("MovieForm",movform);
            }
            if(movie.Id==0)
                _context.Movie.Add(movie);
            else
            {
                var mov = _context.Movie.Single(c => c.Id == movie.Id);
                mov.Name = movie.Name;
                mov.IsSubscribedToNewsLatter = movie.IsSubscribedToNewsLatter;
                mov.MovieTypeId = movie.MovieTypeId;
                mov.ReleaseDate = movie.ReleaseDate;
            }
            
                _context.SaveChanges();
         return   RedirectToAction("Index","Movie");
        }
        public ActionResult Index()
        {
            if (User.IsInRole(RoleAuthorizationClass.CanManageMovies))
            {
                return View();
            }
            else
            {
                return View("MovieList");
            }
        }

        public ActionResult MovieForm()
        {
            var movietype = _context.MovieType.ToList();
            var movieViewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                MovieType = movietype
            };
            return View(movieViewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var movieform = new MovieFormViewModel
                {
                    Movie = movie,
                    MovieType = _context.MovieType.ToList()
                };
                return View("MovieForm", movieform);
            }

        }
    }
}
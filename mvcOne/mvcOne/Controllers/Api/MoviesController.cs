using AutoMapper;
using mvcOne.Dtos;
using mvcOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace mvcOne.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpGet]
        public IEnumerable<MovieDto> getMovies()
        {
            var movies = _context.Movie
                           .Include(c => c.MovieType).ToList()
                           .Select(Mapper.Map<Movie,MovieDto>);
            return movies;
        }

        [HttpGet]
        public IHttpActionResult getMovie(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            return BadRequest();

            return  Ok(Mapper.Map<Movie,MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreatMovie(MovieDto mov)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movie = Mapper.Map<MovieDto, Movie>(mov);
                _context.Movie.Add(movie);
                _context.SaveChanges();
                mov.Id = movie.Id;
                return Created(new Uri(Request.RequestUri + "/" + movie.Id), mov);
            }

        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);
                Mapper.Map(movieDto, movieInDb);
                //customerInDb.Name = customerDto.Name;
                //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
                //customerInDb.IsSubscribedToNewsLatter = customerDto.IsSubscribedToNewsLatter;
                //customerInDb.BirthDate = customerDto.BirthDate;
                _context.SaveChanges();
            }

        }

        [HttpDelete]
        public void DeletMovie(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Movie.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}

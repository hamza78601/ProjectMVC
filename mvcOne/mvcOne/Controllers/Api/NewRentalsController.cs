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
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            var customer = _context.Customer.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movie.Where(m => newRental.MovieId.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");
                
                movie.NumberAvailable--;
                
                var rental = new Rental 
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rental.Add(rental);
            }

            throw new NotImplementedException();
        }
    }
}

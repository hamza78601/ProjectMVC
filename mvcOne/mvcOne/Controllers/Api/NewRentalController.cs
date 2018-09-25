using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mvcOne.Models;
using mvcOne.Dtos;
using System.Data.Entity;
namespace mvcOne.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;
        [HttpPost]

        public  IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customer.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movie.Where(m => newRental.MoviesIds.Contains(m.Id));
            
            foreach(var movie in movies)
            {
                if(movie.NumberAvailable ==0)
                    return BadRequest("Movie Is Not Available");
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

using mvcOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcOne.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<MovieType> MovieType { get; set; }
    }
}
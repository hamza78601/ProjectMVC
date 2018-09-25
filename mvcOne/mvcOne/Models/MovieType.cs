using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcOne.Models
{
    public class MovieType
    {
        public byte Id { get; set; }

        [Required]
        public string MovieTypeName { get; set; }
        public short MovieFees { get; set; }
    }
}
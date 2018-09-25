using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcOne.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        public string MembershipTypeNmae { get; set; }
        public byte DiscountRate { get; set; }
        public short SingnUpFee { get; set; }

    }
}
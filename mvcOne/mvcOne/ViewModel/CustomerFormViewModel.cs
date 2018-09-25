using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcOne.Models;

namespace mvcOne.ViewModel
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipType { get; set; }
    }
}
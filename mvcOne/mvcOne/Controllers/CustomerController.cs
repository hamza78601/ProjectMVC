using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using mvcOne.Models;
using mvcOne.ViewModel;

namespace mvcOne.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var custform=new CustomerFormViewModel
                {
                    Customer=customer,
                    MembershipType=_context.MembershipType.ToList()
                };
                return View("CustomerForm",custform);
            }
            if(customer.Id==0)
                _context.Customer.Add(customer);
            else
            {
               var custom= _context.Customer.Single(c => c.Id == customer.Id);
               custom.Name = customer.Name;
               custom.IsSubscribedToNewsLatter = customer.IsSubscribedToNewsLatter;
               custom.MembershipTypeId = customer.MembershipTypeId;
               custom.BirthDate = customer.BirthDate;
            }
            
            
                _context.SaveChanges();
         return   RedirectToAction("Index","Customer");
        }
        public ActionResult Index()
        {
           if(User.IsInRole(RoleAuthorizationClass.CanManageMovies))
           {
               return View();
           }
           else
           {
               return View("CustomerList");
           }
        }
        public ActionResult CustomerForm()
        {
            var membership = _context.MembershipType.ToList();
            var cutomerViewModel = new CustomerFormViewModel 
            {
                Customer=new Customer(),
                MembershipType=membership
            };
            return View(cutomerViewModel);
        }
        public ActionResult Edit(int id)
        {
            var customer=_context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            else
            {
               var customerform= new CustomerFormViewModel {Customer=customer,
                MembershipType=_context.MembershipType.ToList()};
                return View("CustomerForm", customerform);
            }
            
        }
    }
}
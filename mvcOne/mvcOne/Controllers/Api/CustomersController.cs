using mvcOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using mvcOne.Dtos;
namespace mvcOne.Controllers.Api
{
    public class CustomersController : ApiController
    {
          private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpGet]
        public IEnumerable<CustomerDto> getCustomers()
        {
            var customers = _context.Customer
                           .Include(c => c.MembershipType).ToList()
                           .Select(Mapper.Map<Customer,CustomerDto>);
            return customers;
        }

        [HttpGet]
        public IHttpActionResult getCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            return BadRequest();

            return  Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreatCustomer(CustomerDto cust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customer = Mapper.Map<CustomerDto, Customer>(cust);
                _context.Customer.Add(customer);
                _context.SaveChanges();
                cust.Id = customer.Id;
                return Created(new Uri(Request.RequestUri+"/"+customer.Id),cust);
            }

        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);
                Mapper.Map(customerDto, customerInDb);
                //customerInDb.Name = customerDto.Name;
                //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
                //customerInDb.IsSubscribedToNewsLatter = customerDto.IsSubscribedToNewsLatter;
                //customerInDb.BirthDate = customerDto.BirthDate;
                _context.SaveChanges();
            }

        }

        [HttpDelete]
        public void DeletCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Customer.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}

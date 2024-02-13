using System;
using BLL;
using Data;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace Controller
{
    public class CostomerController :ApiController
    {
        // GET: api/Kit
        public List<Customer> Get()
        {
            return Customer.GetAll();
        }

        // GET: api/Kit/5
        public Customer Get(int Id)
        {


            return Customer.GetById(Id);

        }
    }
    
}

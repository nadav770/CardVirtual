using System;
using BLL;
using Data;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;

namespace CardVirtual.Controller
{
    public class CustomerController :ApiController
    {
        // GET: api/Customer
        public object GET()
        {
            List<Customer> LstCustomers = Customer.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstCustomers
            };
            return res;
        }
        // GET: api/Customer/5
        public object GET(int Id)
        {

            Customer tmp = Customer.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Customer
        public object POST(Customer data)
        {


            data.CustomerId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Customer data)
        {

            data.CustomerId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Customer/5
        public object DELETE(int id)
        {
            Customer.DeleteById(id);

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;



        }
    }
    
}

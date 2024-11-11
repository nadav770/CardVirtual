using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CardVirtual.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/User
        public object GET()
        {
            List<Users> LstStockParts = Users.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstStockParts
            };
            return res;
        }
        // GET: api/User/5
        public object GET(int Id)
        {

            Users tmp = Users.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/User
        public object POST(Users data)
        {


            data.UserId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Users data)
        {

            data.UserId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/User/5
        public object DELETE(int id)
        {
            Users.DeleteById(id);

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

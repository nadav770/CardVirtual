using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CardVirtual.Controller
{
    public class LogController : ApiController
    {
        // GET: api/Log
        public object GET()
        {
            List<Log> LstDepartments = Log.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstDepartments
            };
            return res;
        }
        // GET: api/Customer/5
        public object GET(int Id)
        {

            Log tmp = Log.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Department
        public object POST(Log data)
        {


            data.LogId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Log data)
        {

            data.LogId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Log/5
        public object DELETE(int id)
        {
            Log.DeleteById(id);

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

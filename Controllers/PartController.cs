using System;
using DAL;
using Data;

using System.Collections.Generic;
using System.Linq;
using System.Web;

using BLL;
using System.Web.Http;

namespace CardFlow.Controller
{
    public class PartController : ApiController
    {
        // GET: api/Part
        public object GET()
        {
            List<Part> LstParts = Part.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstParts
            };
            return res;
        }
        // GET: api/Part/5
        public object GET(int Id)
        {

            Part tmp = Part.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Part
        public object POST(Part data)
        {


            data.PartId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Part data)
        {

            data.PartId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Part/5
        public object DELETE(int id)
        {
            Part.DeleteById(id);

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

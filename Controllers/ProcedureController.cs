using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using BLL;

namespace CardFlow.Controller
{
    public class ProcedureController :ApiController
    {
        // GET: api/Kit
        public object GET()
        {
            List<Procedure> LstProcedure = Procedure.GetAll();

            var res = new
            {
                status = 200,
                error = "no erors",
                data = LstProcedure
            };
            return res;
        }
        // GET: api/Kit/5
        public object GET(int Id)
        {

            Procedure tmp = Procedure.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Kit
        public object POST(Procedure data)
        {


            data.ActionId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Procedure data)
        {

            data.ActionId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/kit/5
        public object DELETE(int id)
        {
            Procedure.DeleteById(id);

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

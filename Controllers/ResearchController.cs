using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace CardFlow.Controller
{
    public class ResearchController : ApiController
    {
        // GET: api/Research
        public object GET()
        {
            List<Research> LstResearchs = Research.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstResearchs
            };
            return res;
        }
        // GET: api/Research/5
        public object GET(int Id)
        {

            Research tmp = Research.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Research
        public object POST(Research data)
        {


            data.ResearchId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Research data)
        {

            data.ResearchId= Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Research/5
        public object DELETE(int id)
        {
            Research.DeleteById(id);

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

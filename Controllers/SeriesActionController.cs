using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace CardFlow.Controller
{
    public class SeriesActionController : ApiController
    {
        // GET: api/SeriesOfAction
        public object GET()
        {
            List<SeriesAction> LstSeriesOfActions = SeriesAction.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstSeriesOfActions
            };
            return res;
        }
        // GET: api/SeriesOfAction/5
        public object GET(int Id)
        {

            SeriesAction tmp = SeriesAction.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/SeriesOfAction
        public object POST(SeriesAction data)
        {


            data.SeriesActionId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, SeriesAction data)
        {

            data.SeriesActionId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/SeriesOfAction/5
        public object DELETE(int id)
        {
            SeriesAction.DeleteById(id);

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

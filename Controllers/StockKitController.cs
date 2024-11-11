using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CardVirtual.Controllers
{
    public class StockKitController : ApiController
    {
        // GET: api/StockKit
        public object GET()
        {
            List<StockKit> LstStockKits = StockKit.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstStockKits
            };
            return res;
        }
        // GET: api/StockKit/5
        public object GET(int Id)
        {

            StockKit tmp = StockKit.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/StockKit
        public object POST(StockKit data)
        {


            data.StockKitId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, StockKit data)
        {

            data .StockKitId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/StockKit/5
        public object DELETE(int id)
        {
            StockKit.DeleteById(id);

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

using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CardVirtual.Controllers
{
    
    
        public class StockPartController : ApiController
        {
            // GET: api/StockPart
            public object GET()
            {
                List<StockPart> LstStockParts = StockPart.GetAll();

                var res = new
                {
                    status = 200,
                    error = "",
                    data = LstStockParts
                };
                return res;
            }
            // GET: api/StockKit/5
            public object GET(int Id)
            {

                StockPart tmp = StockPart.GetById(Id);

                var res = new
                {
                    status = 200,
                    error = "",
                    data = tmp
                };
                return res;
            }

            // POST: api/v1/StockPart
            public object POST(StockPart data)
            {


                data.StockPartsId = -1;

                data.Save();

                var res = new
                {
                    status = 200,
                    error = "",
                    data = ""
                };

                return res;
            }


            public object PUT(int Id, StockPart data)
            {

                data.StockPartsId = Id;

                data.Save();

                var res = new
                {
                    status = 200,
                    error = "",
                    data = ""
                };
                return res;
            }

            // DELETE: api/StockPart/5
            public object DELETE(int id)
            {
                StockPart.DeleteById(id);

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

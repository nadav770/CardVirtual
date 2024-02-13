using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Controller
{
    public class StockKitController : ApiController
    {
        public List<StockKit> Get()
        {
            return StockKit.GetAll();
        }

        // GET: api/Kit/5
        public StockKit Get(int Id)
        {


            return StockKit.GetById(Id);

        }
    
    }
}

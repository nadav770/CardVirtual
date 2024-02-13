using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Controller
{
    public class SeriesOfActionController : ApiController
    {
        public List<SeriesOfAction> Get()
        {
            return SeriesOfAction.GetAll();
        }

        // GET: api/Kit/5
        public Role Get(int Id)
        {


            return Role.GetById(Id);

        }
    }
}

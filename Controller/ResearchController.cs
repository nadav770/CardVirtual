using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Controller
{
    public class ResearchController : ApiController
    {
        // GET: api/Kit
        public List<Research> Get()
        {
            return Research.GetAll();
        }

        // GET: api/Kit/5
        public Research Get(int Id)
        {


            return Research.GetById(Id);

        }
    }
}

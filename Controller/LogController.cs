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
        // GET: api/Kit
        public List<Log> Get()
        {
            return Log.GetAll();
        }

        // GET: api/Kit/5
        public Log Get(int Id)
        {


            return Log.GetById(Id);

        }

    }
}

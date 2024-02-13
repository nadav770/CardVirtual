using System;
using DAL;
using Data;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Web.Http;

namespace Controller
{
    public class PartController : ApiController
    {
        // GET: api/Kit
        public List<Part> Get()
        {
            return Part.GetAll();
        }

        // GET: api/Kit/5
        public Part Get(int Id)
        {


            return Part.GetById(Id);

        }

    }   
}

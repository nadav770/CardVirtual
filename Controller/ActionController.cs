using BLL;
using DAL;

//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Controller
{
    public class ActionController : ApiController
    {
        // GET: api/Action
        public List<Action> Get()
        {
            return Action.GetAll();
        }

        // GET: api/Action/5
        public Action Get(int Id)
        {


            return Action.GetById(Id);

        }

    }
}

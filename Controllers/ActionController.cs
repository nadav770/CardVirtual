using BLL;
using DAL;

//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace CardVirtual.Controller
{
    public class ActionController : ApiController
    {
        // GET: api/Action
        public object GET()
        {
            List<Action> LstActions = Action.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstActions
            };
            return res;
        }
        // GET: api/Kit/5
        public object GET(int Id)
        {

            Action tmp = Action.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Action
        public object POST(Action data)
        {


            data.ActionId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Action data)
        {

            data.ActionId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Action/5
        public object DELETE(int id)
        {
            Action.DeleteById(id);

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

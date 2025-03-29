using BLL;
using DAL;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace CardFlow.Controller
{
    public class KitController : ApiController
    {
        // GET: api/Kit
        public object GET()
        {
            List<Kit> LstKits = Kit.GetAll();

            var res = new
            {
                status = 200,
                error = "no erors",
                data = LstKits
            };
            return res;
        }
        // GET: api/Kit/5
        public object GET(int Id)
        {

            Kit tmp = Kit.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Kit
        public object POST(Kit data)
        {


            data.KitId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Kit data)
        {

            data.KitId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/kit/5
        public object DELETE(int id)
        {
            Kit.DeleteById(id);

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
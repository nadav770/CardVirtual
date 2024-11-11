using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CardFlow.Controller
{
    public class  RoleController :ApiController
    {
        // GET: api/Role
        public object GET()
        {
            List<Role> LstRoles = Role.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstRoles
            };
            return res;
        }
        // GET: api/Research/5
        public object GET(int Id)
        {

            Role tmp = Role.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Research
        public object POST(Role data)
        {


            data.RoleId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = "the role is insert sucsecfully"
            };

            return res;
        }


        public object PUT(int Id, Role data)
        {

            data.RoleId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Role/5
        public object DELETE(int id)
        {
            Role.DeleteById(id);

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

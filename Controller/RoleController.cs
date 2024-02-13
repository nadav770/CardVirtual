using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controller
{
    public class  RoleController
    {
        // GET: api/Kit
        public List<Role> Get()
        {
            return Role.GetAll();
        }

        // GET: api/Kit/5
        public Role Get(int Id)
        {


            return Role.GetById(Id);

        }
    
    }
}

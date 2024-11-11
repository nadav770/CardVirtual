using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CardVirtual.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET: api/Department
        public object GET()
        {
            List<Department> LstDepartments = Department.GetAll();

            var res = new
            {
                status = 200,
                error = "",
                data = LstDepartments
            };
            return res;
        }
        // GET: api/Customer/5
        public object GET(int Id)
        {

            Department tmp = Department.GetById(Id);

            var res = new
            {
                status = 200,
                error = "",
                data = tmp
            };
            return res;
        }

        // POST: api/v1/Department
        public object POST(Department data)
        {


            data.DepartmentId = -1;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };

            return res;
        }


        public object PUT(int Id, Department data)
        {

            data.DepartmentId = Id;

            data.Save();

            var res = new
            {
                status = 200,
                error = "",
                data = ""
            };
            return res;
        }

        // DELETE: api/Department/5
        public object DELETE(int id)
        {
            Department.DeleteById(id);

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

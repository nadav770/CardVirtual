using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using BLL;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace CardVirtual.backOffice
{
    public partial class Login : System.Web.UI.Page
    {
        public DBcontext db = new DBcontext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LtlMsg.Text = "";
            }
        }

        protected void cliclogin(object sender, EventArgs e)
        {
            string username = textuser.Text.Trim();
            string password = textpas.Text.Trim();
            Users tmp = new Users()
            {
                UserId = -1,
                UserName = username,
                Pass=password

            };
            tmp.CheckLogin();
            if (tmp.UserId != -1)
            {
                Session["UserName"] = username;
                Response.Redirect("BackOffice");
            }
            else
            {
                LtlMsg.Text = "<span style='color:red;'>שם משתמש או סיסמה שגויים.</span>";
            }

        }

        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
            string query = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName AND Pass = @Pass";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserName", username),
                new SqlParameter("@Pass", password)
            };

            object result = db.ExecuteScalar(query, parameters);
            int count = result != null ? Convert.ToInt32(result) : 0;
            isAuthenticated = count > 0;

            return isAuthenticated;
        }
    }
}

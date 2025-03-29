using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class RoleList : System.Web.UI.Page
    {
        protected void fillData()
        {
            RptRole.DataSource = Role.GetAll();
            RptRole.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillData();
            }
        }
    }
}
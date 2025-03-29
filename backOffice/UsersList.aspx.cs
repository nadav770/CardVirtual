using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace CardVirtual.backOffice
{
    public partial class UsersList : System.Web.UI.Page
    {
      protected void  fillData()
        {
            RptUsers.DataSource = Users.GetAll();
            RptUsers.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillData();
            }
        }
    }

}
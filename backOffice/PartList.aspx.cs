using BLL;
using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class PartList : System.Web.UI.Page
    {
        protected void fillData()
        {
            RptPart.DataSource = Part.GetAll();
            RptPart.DataBind();

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
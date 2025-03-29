using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class KitList : System.Web.UI.Page
    {
        protected void fillData()
        {
            var Kits=Kit.GetAll();
            var Customers=Customer.GetAll();
            List<object> LstKits = Kits.Select(k=> new
            {
                KitId = k.KitId,
                KitName = k.KitName,
                KitTag = k.KitTag,
                KitBarcode = k.KitBarcode,
                KitDesc = k.KitDesc,
                KitImage = k.KitImage,
                CustomerName = Customers.Where(c=> c.CustomerId==k.CustomerId).ToList()[0].CustomerName,
                KitNumOfParts = k.KitNumOfParts,
                KitStatus = k.KitStatus? "פעיל":"לא פעיל",
                RegisterDate = k.RegisterDate
            }
                
                ).ToList<object>();
            RptKit.DataSource = LstKits;
            RptKit.DataBind();

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
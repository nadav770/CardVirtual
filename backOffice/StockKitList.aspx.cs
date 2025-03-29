using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class StockKitList : System.Web.UI.Page
    {



        protected void fillData()
        {
            var StockKits = StockKit.GetAll();
            var Kits = Kit.GetAll();
            List<object> LstStockKits = StockKits.Select(k => new
            {
                StockKitId=k.StockKitId,    
                KitName = Kits.Where(c => c.KitId == k.KitId).ToList()[0].KitName, 
                JobId = k.JobId,
                DateIn = k.DateIn,
                DueDate = k.DueDate
               
            }

                ).ToList<object>();
            RptStockKit.DataSource = LstStockKits;
            RptStockKit.DataBind();

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
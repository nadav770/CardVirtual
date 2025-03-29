using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class StockKitAdd : System.Web.UI.Page
    {
        protected void filldata(int StockKitId)
        {
            DDLKitId.DataSource = Kit.GetAll();
            DDLKitId.DataTextField = "KitName";
            DDLKitId.DataValueField = "KitId";
            DDLKitId.DataBind();
            StockKit tmp = null;
            if (StockKitId != -1)
            {
                tmp = StockKit.GetById(StockKitId);

            }
            //יצרתי משתנה מסוג משתמש שמחזיק את הUserId שהזנתי באתר

            //ואני בודק האם המשתנה ריק משמע חדש
            if (tmp == null)
            {
                //אז אני מחיל את מחזרוזת -1 שתקח אותו לdatabase ובמילא תייצר לה אחד חדש
                HIdStockKitId.Value = "-1";
                return;
            }
            //אבל אם זה משתנה ידוע אני מקבל את כל השדות שיהיו זמינים לעדכון
            HIdStockKitId.Value = tmp.StockKitId + "";
            DDLKitId.SelectedValue = tmp.KitId + "";
            TxtJobId.Text = tmp.JobId.ToString();
            TxtDateIn.Text = tmp.DateIn;
            TxtDueDate.Text = tmp.DueDate;
            
          
           





            



        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //פה אנחנו שואלים האם זוהי הטעינה הראשונה
            if (!IsPostBack)
            {
                //יש לנו פה מחרוזת שמחזיקה את המזהה הקיים ועוד מחרוזת ריקה
                string StockKitId = Request["StockKitId"] + "";
                //ואז אנחנו שואלים אם UserId כרגע ריק משמע אנחנו מחזיקים משתשמש חדש
                if (StockKitId == "")
                {
                    StockKitId = "-1";

                }
                //תתן בהידן יוזר איי די ואלוי -1 שזה flag לdatabase שמדובר כאן במשתשמ חדש
                HIdStockKitId.Value = StockKitId;

                filldata(int.Parse(StockKitId));


                //אחרת תמיר את המספר הקיים ממחרוזת למספר שלם ובמילא האובייקט יעבוד 

            }
        }


            protected void BtnSave_Click(object sender, EventArgs e)
    {
        StockKit Tmp = new StockKit()
        {

            StockKitId = int.Parse(HIdStockKitId.Value),
            KitId = int.Parse(DDLKitId.SelectedValue),
            JobId = int.Parse(TxtJobId.Text),
            DateIn = TxtDateIn.Text,
            DueDate = TxtDueDate.Text,
            ExtendedDescription = ""




        };
        Tmp.Save();
        Response.Redirect("StockKitList.aspx");
    }

    }

}   
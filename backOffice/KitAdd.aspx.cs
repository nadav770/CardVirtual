using System;

using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace CardVirtual.backOffice
{
    public partial class KitAdd : System.Web.UI.Page
    {
        protected void filldata(int KitId)
        {
            DDLCustomerId.DataSource = Customer.GetAll();
            DDLCustomerId.DataTextField = "CustomerName";
            DDLCustomerId.DataValueField = "CustomerId";
            DDLCustomerId.DataBind();
            Kit tmp=null;
            if (KitId!=-1)
            {
                tmp = Kit.GetById(KitId);

            }
            //יצרתי משתנה מסוג משתמש שמחזיק את הUserId שהזנתי באתר
            
            //ואני בודק האם המשתנה ריק משמע חדש
            if (tmp == null)
            {
                //אז אני מחיל את מחזרוזת -1 שתקח אותו לdatabase ובמילא תייצר לה אחד חדש
                HIdKitId.Value = "-1";
                return;
            }
            //אבל אם זה משתנה ידוע אני מקבל את כל השדות שיהיו זמינים לעדכון
            HIdKitId.Value = tmp.KitId + "";
            TxtKitName.Text = tmp.KitName;
            TxtKitTag.Text = tmp.KitTag;
            TxtKitBarcode.Text = tmp.KitBarcode;
            TxtKitDesc.Text = tmp.KitDesc;
            TxtKitImage.Text = tmp.KitImage;
            DDLCustomerId.SelectedValue = tmp.CustomerId + "";
            TxtNumOfParts.Text=tmp.KitNumOfParts.ToString();
           


           

            ///  TxtUserStatus.Text =(TextBoxMode) tmp.UserStatus;



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //פה אנחנו שואלים האם זוהי הטעינה הראשונה
            if (!IsPostBack)
            {
                //יש לנו פה מחרוזת שמחזיקה את המזהה הקיים ועוד מחרוזת ריקה
                string KitId = Request["KitId"] + "";
                //ואז אנחנו שואלים אם UserId כרגע ריק משמע אנחנו מחזיקים משתשמש חדש
                if (KitId == "")
                {
                    KitId = "-1";
                    //תתן בהידן יוזר איי די ואלוי -1 שזה flag לdatabase שמדובר כאן במשתשמ חדש
                   
                }
                HIdKitId.Value = KitId;

                //אחרת תמיר את המספר הקיים ממחרוזת למספר שלם ובמילא האובייקט יעבוד 
                filldata(int.Parse(KitId));
               
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Kit Tmp = new Kit()
            {
                KitId = int.Parse(HIdKitId.Value),
                KitName = TxtKitName.Text,
                KitTag = TxtKitTag.Text,

                KitBarcode = TxtKitBarcode.Text,
                KitDesc=TxtKitDesc.Text,
                KitImage=TxtKitImage.Text,
                CustomerId =int.Parse(DDLCustomerId.SelectedValue),
                KitNumOfParts=int.Parse(TxtNumOfParts.Text)


            };
            Tmp.Save();
            Response.Redirect("KitList.aspx");
        }





    }
}
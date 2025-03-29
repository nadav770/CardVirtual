using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class LogAdd : System.Web.UI.Page
    {
        protected void filldata(int KitId)
        {
            //יצרתי משתנה מסוג משתמש שמחזיק את הUserId שהזנתי באתר
            Kit tmp = Kit.GetById(KitId);
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
            TxtCustomerId.Text = tmp.CustomerId.ToString();
            TxtNumOfParts.Text = tmp.KitNumOfParts.ToString();




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
                    //תתן בהידן יוזר איי די ואלוי -1 שזה flag לdatabase שמדובר כאן במשתשמ חדש
                    HIdKitId.Value = "-1";
                }
                else
                {
                    //אחרת תמיר את המספר הקיים ממחרוזת למספר שלם ובמילא האובייקט יעבוד 
                    filldata(int.Parse(KitId));
                }
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
                KitDesc = TxtKitDesc.Text,
                KitImage = TxtKitImage.Text,
                CustomerId = int.Parse(TxtCustomerId.Text),
                KitNumOfParts = int.Parse(TxtNumOfParts.Text)


            };
            Tmp.Save();
            Response.Redirect("KitList.aspx");
        }
    }
}
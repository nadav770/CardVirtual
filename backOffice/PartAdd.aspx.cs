using BLL;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using DAL;

namespace CardVirtual.backOffice
{
    public partial class PartAdd : System.Web.UI.Page
    {
        protected void filldata(int PartId)
        {
            //יצרתי משתנה מסוג משתמש שמחזיק את הUserId שהזנתי באתר
            Part tmp = Part.GetById(PartId);
            //ואני בודק האם המשתנה ריק משמע חדש
            if (tmp == null)
            {
                //אז אני מחיל את מחזרוזת -1 שתקח אותו לdatabase ובמילא תייצר לה אחד חדש
                HIdPartId.Value = "-1";
                return;
            }
            //אבל אם זה משתנה ידוע אני מקבל את כל השדות שיהיו זמינים לעדכון
            HIdPartId.Value = tmp.PartId + "";
            TxtPartName.Text = tmp.PartName;
            TxtPartImiageName.Text = tmp.PartImiageName;
            TxtPartDateReceiving.Text = tmp.PartDateReceiving;
            


            ///  TxtUserStatus.Text =(TextBoxMode) tmp.UserStatus;



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //פה אנחנו שואלים האם זוהי הטעינה הראשונה
            if (!IsPostBack)
            {
                //יש לנו פה מחרוזת שמחזיקה את המזהה הקיים ועוד מחרוזת ריקה
                string PartId = Request["PartId"] + "";
                //ואז אנחנו שואלים אם UserId כרגע ריק משמע אנחנו מחזיקים משתשמש חדש
                if (PartId == "")
                {
                    //תתן בהידן יוזר איי די ואלוי -1 שזה flag לdatabase שמדובר כאן במשתשמ חדש
                    HIdPartId.Value = "-1";
                }
                else
                {
                    //אחרת תמיר את המספר הקיים ממחרוזת למספר שלם ובמילא האובייקט יעבוד 
                    filldata(int.Parse(PartId));
                }
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Part Tmp = new Part()
            {
                PartId = int.Parse(HIdPartId.Value),
                PartName = TxtPartName.Text,
                PartImiageName = TxtPartImiageName.Text,

                PartDateReceiving = TxtPartDateReceiving.Text,
                

            };
            Tmp.Save();
            Response.Redirect("PartList.aspx");
        }

    }
}


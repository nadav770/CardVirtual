using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class SeriesActionAdd : System.Web.UI.Page
    {
        protected void filldata(int RoleId)
        {
            //יצרתי משתנה מסוג משתמש שמחזיק את הUserId שהזנתי באתר
            Role tmp = Role.GetById(RoleId);
            //ואני בודק האם המשתנה ריק משמע חדש
            if (tmp == null)
            {
                //אז אני מחיל את מחזרוזת -1 שתקח אותו לdatabase ובמילא תייצר לה אחד חדש
                HIdRoleId.Value = "-1";
                return;
            }
            //אבל אם זה משתנה ידוע אני מקבל את כל השדות שיהיו זמינים לעדכון
            HIdRoleId.Value = tmp.RoleId + "";
            TxtRoleName.Text = tmp.RoleName;



            ///  TxtUserStatus.Text =(TextBoxMode) tmp.UserStatus;



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //פה אנחנו שואלים האם זוהי הטעינה הראשונה
            if (!IsPostBack)
            {
                //יש לנו פה מחרוזת שמחזיקה את המזהה הקיים ועוד מחרוזת ריקה
                string RoleId = Request["RoleId"] + "";
                //ואז אנחנו שואלים אם UserId כרגע ריק משמע אנחנו מחזיקים משתשמש חדש
                if (RoleId == "")
                {
                    //תתן בהידן יוזר איי די ואלוי -1 שזה flag לdatabase שמדובר כאן במשתשמ חדש
                    HIdRoleId.Value = "-1";
                }
                else
                {
                    //אחרת תמיר את המספר הקיים ממחרוזת למספר שלם ובמילא האובייקט יעבוד 
                    filldata(int.Parse(RoleId));
                }
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Role Tmp = new Role()
            {
                RoleId = int.Parse(HIdRoleId.Value),
                RoleName = TxtRoleName.Text,



            };
            Tmp.Save();
            Response.Redirect("RoleList.aspx");
        }
    }
}
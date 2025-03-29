using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace CardVirtual.backOffice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //פונקציה שמקבלת את הנתונים
        protected void filldata(int UserId)
        {
            //יצרתי משתנה מסוג משתמש שמחזיק את הUserId שהזנתי באתר
            Users tmp = Users.GetById(UserId);
            //ואני בודק האם המשתנה ריק משמע חדש
            if (tmp == null)
            { 
                //אז אני מחיל את מחזרוזת -1 שתקח אותו לdatabase ובמילא תייצר לה אחד חדש
                HIdUserId.Value = "-1";
                return;
            }
            //אבל אם זה משתנה ידוע אני מקבל את כל השדות שיהיו זמינים לעדכון
            HIdUserId.Value = tmp.UserId + "";
            TxtUserName.Text = tmp.UserName;
            TxtPass.Text = tmp.Pass;
            
            
            TxtUserEmail.Text = tmp.UserEmail;


            ///  TxtUserStatus.Text =(TextBoxMode) tmp.UserStatus;



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //פה אנחנו שואלים האם זוהי הטעינה הראשונה
            if(!IsPostBack)
            {
                //יש לנו פה מחרוזת שמחזיקה את המזהה הקיים ועוד מחרוזת ריקה
                string UserId = Request["UserId"] + "";
                //ואז אנחנו שואלים אם UserId כרגע ריק משמע אנחנו מחזיקים משתשמש חדש
                if(UserId=="")
                {
                    //תתן בהידן יוזר איי די ואלוי -1 שזה flag לdatabase שמדובר כאן במשתשמ חדש
                    HIdUserId.Value = "-1";
                }
                else
                {
                    //אחרת תמיר את המספר הקיים ממחרוזת למספר שלם ובמילא האובייקט יעבוד 
                    filldata(int.Parse(UserId));
                }
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Users Tmp = new Users() {
            UserId = int.Parse(HIdUserId.Value),
            UserName=TxtUserName.Text,
            Pass=TxtPass.Text,

            UserEmail = TxtUserEmail.Text


            };
            Tmp.Save();
            Response.Redirect("UsersList.aspx");
        }
    }
}
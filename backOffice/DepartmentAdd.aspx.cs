using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class DepartmentAdd : System.Web.UI.Page
    {
      
        
            protected void filldata(int DepartmentId)
            {
                //יצרתי משתנה מסוג משתמש שמחזיק את הUserId שהזנתי באתר
                Department tmp = Department.GetById(DepartmentId);
                //ואני בודק האם המשתנה ריק משמע חדש
                if (tmp == null)
                {
                    //אז אני מחיל את מחזרוזת -1 שתקח אותו לdatabase ובמילא תייצר לה אחד חדש
                    HIdDepartmentId.Value = "-1";
                    return;
                }
                //אבל אם זה משתנה ידוע אני מקבל את כל השדות שיהיו זמינים לעדכון
                HIdDepartmentId.Value = tmp.DepartmentId + "";
                TxtDepartmentName.Text = tmp.DepartmentName;
               



                ///  TxtUserStatus.Text =(TextBoxMode) tmp.UserStatus;



            }
            protected void Page_Load(object sender, EventArgs e)
            {
                //פה אנחנו שואלים האם זוהי הטעינה הראשונה
                if (!IsPostBack)
                {
                    //יש לנו פה מחרוזת שמחזיקה את המזהה הקיים ועוד מחרוזת ריקה
                    string DepartmentId = Request["DepartmentId"] + "";
                    //ואז אנחנו שואלים אם UserId כרגע ריק משמע אנחנו מחזיקים משתשמש חדש
                    if (DepartmentId == "")
                    {
                        //תתן בהידן יוזר איי די ואלוי -1 שזה flag לdatabase שמדובר כאן במשתשמ חדש
                        HIdDepartmentId.Value = "-1";
                    }
                    else
                    {
                        //אחרת תמיר את המספר הקיים ממחרוזת למספר שלם ובמילא האובייקט יעבוד 
                        filldata(int.Parse(DepartmentId));
                    }
                }

            }

            protected void BtnSave_Click(object sender, EventArgs e)
            {
                Department Tmp = new Department()
                {
                    DepartmentId = int.Parse(HIdDepartmentId.Value),
                    DepartmentName = TxtDepartmentName.Text,
                    

                  

                };
                Tmp.Save();
                Response.Redirect("DepartmentList.aspx");
            }

        
    }
}
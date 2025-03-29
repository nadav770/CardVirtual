using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class ResearchAdd : System.Web.UI.Page
    {
        protected void filldata(int ResearchId)
        {
            //יצרתי משתנה מסוג משתמש שמחזיק את הUserId שהזנתי באתר
            Research tmp = Research.GetById(ResearchId);
            //ואני בודק האם המשתנה ריק משמע חדש
            if (tmp == null)
            {
                //אז אני מחיל את מחזרוזת -1 שתקח אותו לdatabase ובמילא תייצר לה אחד חדש
                HIdResearchId.Value = "-1";
                return;
            }
            //אבל אם זה משתנה ידוע אני מקבל את כל השדות שיהיו זמינים לעדכון
            HIdResearchId.Value = tmp.ResearchId + "";
            TxtResearchName.Text = tmp.ResearchName;
            TxtResearchDesc.Text = tmp.ResearchDesc;
            TxtResearchDateReceiving.Text = tmp.ResearchDateReceiving;
            TxtConclusions.Text = tmp.Conclusions;



            ///  TxtUserStatus.Text =(TextBoxMode) tmp.UserStatus;



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //פה אנחנו שואלים האם זוהי הטעינה הראשונה
            if (!IsPostBack)
            {
                //יש לנו פה מחרוזת שמחזיקה את המזהה הקיים ועוד מחרוזת ריקה
                string ResearchId = Request["ResearchId"] + "";
                //ואז אנחנו שואלים אם UserId כרגע ריק משמע אנחנו מחזיקים משתשמש חדש
                if (ResearchId == "")
                {
                    //תתן בהידן יוזר איי די ואלוי -1 שזה flag לdatabase שמדובר כאן במשתשמ חדש
                    HIdResearchId.Value = "-1";
                }
                else
                {
                    //אחרת תמיר את המספר הקיים ממחרוזת למספר שלם ובמילא האובייקט יעבוד 
                    filldata(int.Parse(ResearchId));
                }
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Research Tmp = new Research()
            {
                ResearchId = int.Parse(HIdResearchId.Value),
                ResearchName = TxtResearchName.Text,
                ResearchDesc = TxtResearchDesc.Text,
                ResearchDateReceiving= TxtResearchDateReceiving.Text,
                Conclusions=TxtConclusions.Text,
                


            };
            Tmp.Save();
            Response.Redirect("ResearchList.aspx");
        }
    }
}
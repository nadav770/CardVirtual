using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardVirtual.backOffice
{
    public partial class CustomerAdd : System.Web.UI.Page
    {
        protected void filldata(int CustomerId)
        {
            //יצרתי משתנה מסוג משתמש שמחזיק את הUserId שהזנתי באתר
            Customer tmp = Customer.GetById(CustomerId);
            //ואני בודק האם המשתנה ריק משמע חדש
            if (tmp == null)
            {
                //אז אני מחיל את מחזרוזת -1 שתקח אותו לdatabase ובמילא תייצר לה אחד חדש
                HIdCustomerId.Value = "-1";
                return;
            }
            //אבל אם זה משתנה ידוע אני מקבל את כל השדות שיהיו זמינים לעדכון
            HIdCustomerId.Value = tmp.CustomerId + "";
            TxtCustomerName.Text = tmp.CustomerName;
            TxtCustomerAdress.Text = tmp.CustomerAdress;
            TxtCustomerPhone.Text = tmp.CustomerPhone;
            TxtCustomerContactPerson.Text = tmp.CustomerContactPerson;
            TxtCustomerContactPersonPhone.Text = tmp.CustomerContactPersonPhone;
            TxtRemarks.Text = tmp.Remarks.ToString();
            TxtCustomerMail.Text = tmp.CustomerMail.ToString();




            ///  TxtUserStatus.Text =(TextBoxMode) tmp.UserStatus;



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //פה אנחנו שואלים האם זוהי הטעינה הראשונה
            if (!IsPostBack)
            {
                //יש לנו פה מחרוזת שמחזיקה את המזהה הקיים ועוד מחרוזת ריקה
                string CustomerId = Request["CustomerId"] + "";
                //ואז אנחנו שואלים אם UserId כרגע ריק משמע אנחנו מחזיקים משתשמש חדש
                if (CustomerId == "")
                {
                    //תתן בהידן יוזר איי די ואלוי -1 שזה flag לdatabase שמדובר כאן במשתשמ חדש
                    HIdCustomerId.Value = "-1";
                }
                else
                {
                    //אחרת תמיר את המספר הקיים ממחרוזת למספר שלם ובמילא האובייקט יעבוד 
                    filldata(int.Parse(CustomerId));
                }
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Customer Tmp = new Customer()
            {
                CustomerId = int.Parse(HIdCustomerId.Value),
                CustomerName = TxtCustomerName.Text,
                CustomerAdress = TxtCustomerAdress.Text,

                CustomerPhone= TxtCustomerPhone.Text,
                CustomerContactPerson = TxtCustomerContactPerson.Text,
                CustomerContactPersonPhone= TxtCustomerContactPersonPhone.Text,
                Remarks = TxtRemarks.Text,
                CustomerMail = TxtCustomerMail.Text,
                


            };
            Tmp.Save();
            Response.Redirect("CustomerList.aspx");
        }

    }
}
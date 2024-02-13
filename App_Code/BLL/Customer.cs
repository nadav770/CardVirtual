using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Customer
    {
        public int CustomerId { get; set; }//מזהה של הלקוח
        public string CustomerName { get; set; }//שם לקוח
        public string CustomerAdress { get; set; }//כתובת לקוח
        public string CustomerPhone { get; set; }//טלפון של הלקוח
        public string CustomerMail { get; set; }//מייל של הלקוח
        public string CustomerContactPerson { get; set; }//איש קשר
        public string CustomerContactPersonPhone { get; set; }//טלפון של איש קשר 
        public string CustomerDateStart { get; set; }//תאריך תחילת עבודה
       public string Remarks { get; set; }
        public int CustomerStatus { get; set; }//סטטוס 
        //שמירת כל הלקוחות
        public void Save()
        {

           CustomerDAL.Save(this);
        }

        // פונקציה לקבלת כל הלקוחות
        public static List<Customer> GetAll()
        {
            return CustomerDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static Customer GetById(int Id)
        {
            return CustomerDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return CustomerDAL.DeleteById(Id);
        }

    }
}
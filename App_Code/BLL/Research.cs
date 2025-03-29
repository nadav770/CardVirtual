using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Research
    {
        public int ResearchId { get; set; }//מזהה

        public string ResearchName { get; set; }//שם תחקיר 

        public DateTime ResearchDate { get; set; }// תאריך
        public string ResearchDesc { get; set; }// תיאור התחקיר
        public string ResearchDateReceiving { get; set; }// תאריך המקרה שכתוצאה ממנו נולד התחקיר
        public string Conclusions { get; set; }// מסקנות
        //שמירת כל התחקירים
        public void Save()
        {

            ResearchDAL.Save(this);
        }

        // פונקציה לקבלת כל התחקירים
        public static List<Research> GetAll()
        {
            return ResearchDAL.GetAll();
        }
        // פונקציה לקבלת תחקיר לפי מזהה
        public static Research GetById(int Id)
        {
            return ResearchDAL.GetById(Id);
        }
        //פונקציה למחיקת תחקיר לפי מזהה
        public static int DeleteById(int Id)
        {
            return ResearchDAL.DeleteById(Id);
        }

    }
}
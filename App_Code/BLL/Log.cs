using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Log
    {
        public int LogId { get; set; }// מזהה
        public string TimeAction { get; set; } //זמן הםעולה
        public string LogTime { get; set; }// זמן התיעוד ביומן
        public string DueIn { get; set; }// הפעם הראשונה של הפעולה
        public string LogRemarks { get; set; }// הערות ביומן
        //שמירת כל הקיטים
        public void Save()
        {

            LogDAL.Save(this);
        }

        // פונקציה לקבלת כל התיעודים
        public static List<Log> GetAll()
        {
            return LogDAL.GetAll();
        }
        // פונקציה לקבלת תיעוד לפי מזהה
        public static Log GetById(int Id)
        {
            return LogDAL.GetById(Id);
        }
        //פונקציה למחיקת תיעוד לפי מזהה
        public static int DeleteById(int Id)
        {
            return LogDAL.DeleteById(Id);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Log
    {
        public int LogId { get; set; }
        public string TimeAction { get; set; }
        public string LogTime { get; set; }
        public string DueIn { get; set; }
        public string LogRemarks { get; set; }
        //שמירת כל הקיטים
        public void Save()
        {

            LogDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<Log> GetAll()
        {
            return LogDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static Log GetById(int Id)
        {
            return LogDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return LogDAL.DeleteById(Id);
        }

    }
}
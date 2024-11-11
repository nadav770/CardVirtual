using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class SeriesAction
    {
        public int SeriesActionId { get; set; }
        public string SeriesActionName { get; set; }
        public string SeriesActionDesc { get; set; }
        public int ChronoloyActions { get; set; }
        //שמירת כל הקיטים
        public void Save()
        {

            SeriesActionDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<SeriesAction> GetAll()
        {
            return SeriesActionDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static SeriesAction GetById(int Id)
        {
            return SeriesActionDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return SeriesActionDAL.DeleteById(Id);
        }
        
    }
}
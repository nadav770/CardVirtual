using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class SeriesOfAction
    {
        public int SereiesId { get; set; }
        public string SereiesName { get; set; }
        public string ActionDesc { get; set; }
        public int ActionOrder { get; set; }
        //שמירת כל הקיטים
        public void Save()
        {

            SeriesOfActionDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<SeriesOfAction> GetAll()
        {
            return SeriesOfActionDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static SeriesOfAction GetById(int Id)
        {
            return SeriesOfActionDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return SeriesOfActionDAL.DeleteById(Id);
        }
        
    }
}
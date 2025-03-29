using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class StockKit
    {
        public int StockKitId { get; set; }
        public int KitId { get; set; }
        public string ExtendedDescription { get; set; }
        public int JobId { get; set; }
        public string DateIn { get; set; }
        public string DueDate { get; set; }
        public bool Status { get; set; }
        //שמירת כל הקיטים
        public void Save()
        {

            StockKitDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<StockKit> GetAll()
        {
            return StockKitDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static StockKit GetById(int Id)
        {
            return StockKitDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return StockKitDAL.DeleteById(Id);
        }

    }
}
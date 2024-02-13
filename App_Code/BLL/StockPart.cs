using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class StockPart
    {
        public int StockPartId { get; set; }
        public string StockPartDateIn { get; set; }
        public string SeriesActionPart { get; set; }
        public bool StockPartStatus { get; set; }
        public string StockPartDateOut { get; set; }
        
        //שמירת כל הקיטים
        public void Save()
        {

            StockPartDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<StockPart> GetAll()
        {
            return StockPartDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static StockPart GetById(int Id)
        {
            return StockPartDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return StockPartDAL.DeleteById(Id);
        }


    }
}
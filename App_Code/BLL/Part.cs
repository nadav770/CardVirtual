using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Part
    {
        public int PartId { get; set; }

        public string PartName { get; set; }

        public string PartImiageName { get; set; }

        public string PartDateReceiving { get; set; }
        

        //שמירת כל הקיטים
        public void Save()
        {

            PartDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<Part> GetAll()
        {
            return PartDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static Part GetById(int Id)
        {
            return PartDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return PartDAL.DeleteById(Id);
        }

    }
}
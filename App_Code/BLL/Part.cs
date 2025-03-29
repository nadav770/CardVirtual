using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Part
    {
        public int PartId { get; set; }//מזהה 

        public string PartName { get; set; }//שם החלק 

        public string PartImiageName { get; set; }//תמונה 

        public string PartDateReceiving { get; set; }// זמן הגעתו
        

      //שמירת כל החלקים
        public void Save()
        {

            PartDAL.Save(this);
        }

        // פונקציה לקבלת כל החלקים
        public static List<Part> GetAll()
        {
            return PartDAL.GetAll();
        }
        // פונקציה לקבלת חלק לפי מזהה
        public static Part GetById(int Id)
        {
            return PartDAL.GetById(Id);
        }
        //פונקציה למחיקת חלק לפי מזהה
        public static int DeleteById(int Id)
        {
            return PartDAL.DeleteById(Id);
        }

    }
}
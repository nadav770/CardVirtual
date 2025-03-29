using DAL;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;





namespace BLL
{
    public class Kit
    {
        public int KitId { get; set; }
        public string KitName { get; set; }
        public string KitTag { get; set; }
        public string KitBarcode { get; set; }
        public string KitDesc { get; set; }
        public string KitImage { get; set; }
        public int CustomerId { get; set; }
        public int KitNumOfParts { get; set; }

        public bool KitStatus { get; set; }
        public DateTime RegisterDate { get; set; }
        //שמירת כל הקיטים
        public void Save()
        {
            
            KitDAL.Save(this);
        }
        
        // פונקציה לקבלת כל הקיטים
        public static List<Kit> GetAll()
        {
            return KitDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static  Kit GetById(int Id)
        {
            return KitDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return KitDAL.DeleteById(Id);
        }
       
    }
}
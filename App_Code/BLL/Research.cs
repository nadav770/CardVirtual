using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Research
    {
        public int ResearchId { get; set; }

        public string ResearchName { get; set; }

        public string ResearchDate { get; set; }
        public string ResearchDesc { get; set; }
        public string ResearchDateReciving { get; set; }
        public string Conclusions { get; set; }
        //שמירת כל הקיטים
        public void Save()
        {

            ResearchDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<Research> GetAll()
        {
            return ResearchDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static Research GetById(int Id)
        {
            return ResearchDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return ResearchDAL.DeleteById(Id);
        }

    }
}
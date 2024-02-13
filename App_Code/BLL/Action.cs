using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Action
    {
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        
        public string ActionDesc { get; set; }
        public int Did { get; set; }
        //שמירת כל הפעולות
        public void Save()
        {
           ActionDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<Action> GetAll()
        {
            return ActionDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static Action GetById(int Id)
        {
            return ActionDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return ActionDAL.DeleteById(Id);
        }
        

    }
}
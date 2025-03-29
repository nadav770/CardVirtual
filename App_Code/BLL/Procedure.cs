using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Procedure
    {
        
        
            public int ActionId { get; set; }
            public string ActionName { get; set; }
            public string ActionDesc { get; set; }
            public int Did { get; set; }
           
            public void Save()
            {

                ProcedureDAL.Save(this);
            }

            // פונקציה לקבלת כל הקיטים
            public static List<Procedure> GetAll()
            {
                return ProcedureDAL.GetAll();
            }
            // פונקציה לקבלת קיט לפי מזהה
            public static Procedure GetById(int Id)
            {
                return ProcedureDAL.GetById(Id);
            }
            //פונקציה למחיקת קיט לפי מזהה
            public static int DeleteById(int Id)
            {
                return ProcedureDAL.DeleteById(Id);
            }

        
    }
}
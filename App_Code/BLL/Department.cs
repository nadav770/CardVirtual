using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Department
    {
        public int DepartmentId { get; set; }// מזהה

        public string DepartmentName { get; set; }// שם מחלקה 
        //שמירת כל הלקוחות
        public void Save()
        {

            DepartmentDAL.Save(this);
        }

        // פונקציה לקבלת כל הלקוחות
        public static List<Department> GetAll()
        {
            return DepartmentDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static Department GetById(int Id)
        {
            return DepartmentDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return DepartmentDAL.DeleteById(Id);
        }

    }
}
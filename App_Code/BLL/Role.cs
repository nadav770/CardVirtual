using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        //שמירת כל הקיטים
        public void Save()
        {

            RoleDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<Role> GetAll()
        {
            return RoleDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static Role GetById(int Id)
        {
            return RoleDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return RoleDAL.DeleteById(Id);
        }

    }
}
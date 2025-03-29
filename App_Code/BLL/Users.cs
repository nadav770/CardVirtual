using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public int AthoUse { get; set; }
        public DateTime RegisterDate { get; set; }
        
        public bool UserStatus { get; set; }
        public string UserEmail { get; set; }
        //שמירת כל הקיטים
        public void Save()
        {

            UsersDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<Users> GetAll()
        {
            return UsersDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static Users GetById(int Id)
        {
            return UsersDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return UsersDAL.DeleteById(Id);
        }
        //כאן נמצאת פונקציית המפתח שדרכה נשען כל הflow של הפרויקט
        public void  CheckLogin()
        {
             UsersDAL.CheckLogin(this);
        }

    }
}
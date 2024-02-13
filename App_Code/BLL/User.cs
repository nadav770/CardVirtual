using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public int AthoUse { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Imaige { get; set; }
        public int UserStatus { get; set; }
        //שמירת כל הקיטים
        public void Save()
        {

            UserDAL.Save(this);
        }

        // פונקציה לקבלת כל הקיטים
        public static List<User> GetAll()
        {
            return UserDAL.GetAll();
        }
        // פונקציה לקבלת קיט לפי מזהה
        public static User GetById(int Id)
        {
            return UserDAL.GetById(Id);
        }
        //פונקציה למחיקת קיט לפי מזהה
        public static int DeleteById(int Id)
        {
            return UserDAL.DeleteById(Id);
        }

    }
}
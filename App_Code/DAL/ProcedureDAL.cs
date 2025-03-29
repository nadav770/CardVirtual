using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class ProcedureDAL
    {
        //פונקציה לשמירת כל הקיטים לתוך המסד נתונים
        public static void Save(Procedure Tmp)
        {
            string sql;
            //וקודם אנחנו שואלים האם הid שלו ==-1 משמע שאין לו id סידורי
            if (Tmp.ActionId == -1)
            {//אז בעצם מדובר באובייקט חדש שלא קיים בטבלה אז אני פשוט מייצר אותו ע''י שאילתת sql
                sql = $"insert into Action(ActionName,ActionDesc,Did) " +
                         $"values(@ActionName,@ActionDesc,@Did)";
            }
            else
            {
                sql = $"Update Action set " +

                    $"ActionName=@ActionName," +
                    $"ActionDesc=@ActionDesc," +
                   
                     "$Did=@Did WHERE       ActionId = @ActionId";



            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                ActionId = Tmp.ActionId,
                ActionName = Tmp.ActionName,
                ActionDesc = Tmp.ActionDesc,
                Did = Tmp.Did,
               
            };
            //לאחר כל זאת יצרנו משתנה בשם פרמיטר שיחזיק את כל האובייקט
            var parameters = DBcontext.CreateParameters(obj);




            Db.ExecuteNonQuery(sql, parameters);


            if (Tmp.ActionId == -1)
            {
                sql = $"Select max(ActionId) from Action where ActionName=N'{Tmp.ActionId}'";
                Tmp.ActionId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Procedure> GetAll()
        {
            List<Procedure> ProcedureList = new List<Procedure>();
            string Sql = "Select * from Action";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Procedure tmp = new Procedure()
                {

                    ActionId = int.Parse(Dt.Rows[i]["ActionId"].ToString()),
                    ActionName = Dt.Rows[i]["ActionName"].ToString(),
                    ActionDesc = Dt.Rows[i]["ActionDesc"].ToString(),
                    Did = int.Parse(Dt.Rows[i]["Did"].ToString())
                    
                  



                };

                ProcedureList.Add(tmp);
            }
            Db.Close();
            return ProcedureList;
        }
        public static Procedure GetById(int Id)
        {
            Procedure tmp = null;
            string Sql = $"Select * from Action Where ActionId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Procedure()
                {
                    ActionId = int.Parse(Dt.Rows[0]["ActionId"].ToString()),
                    ActionName = Dt.Rows[0]["ActionName"].ToString(),
                    ActionDesc = Dt.Rows[0]["ActionDesc"].ToString(),
                    Did = int.Parse(Dt.Rows[0]["Did"].ToString())
                    
                    


                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Action Where ActionId = {Id}";
            DBcontext Db = new DBcontext();
            int Total = Db.ExecuteNonQuery(Sql);
            Db.Close();
            if (Total > 0)
                return 1;
            else
                return -1;
        }

    }
}
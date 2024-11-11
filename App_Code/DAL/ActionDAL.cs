//using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class ActionDAL
    {
        public static void Save(Action Tmp)
        {
            string sql;
            if (Tmp.ActionId == -1)
            {
                sql = $"insert into Action(ActionName,ActionDesc,Did) " +
                         $"values(@ActionName,@ActionDesc,@Did)";
            }
            else
            {
                sql = $"Update Action set " +
                  
                    $"ActionName=@ActionName," +
                     $"ActionDesc=@ActionDesc," +
                     $"Did=@Did Where ActionId = @ActionId";






            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                ActionId = Tmp.ActionId,
                ActionName = Tmp.ActionName,
               
                ActionDesc = Tmp.ActionDesc,
                Did=Tmp.Did,
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.ActionId == -1)
            {
                sql = $"Select max(ActionId) from Action where ActionName=N'{Tmp.ActionName}'";
                Tmp.ActionId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Action> GetAll()
        {
            List<Action> ActionList = new List<Action>();
            string Sql = "Select * from Action";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Action tmp = new Action()
                {
                    ActionId = int.Parse(Dt.Rows[i]["ActionId"].ToString()),
                    ActionName = Dt.Rows[i]["ActionName"].ToString(),
                    ActionDesc = Dt.Rows[i]["ActionDesc"].ToString(),
                    Did = int.Parse(Dt.Rows[i]["Did"].ToString())
                    
                    


                };
                ActionList.Add(tmp);
            }
            Db.Close();
            return ActionList;
        }
        public static Action GetById(int Id)
        {
            Action tmp = null;
            string Sql = $"Select * from Action Where ActionId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Action()
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
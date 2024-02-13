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
                sql = $"insert into Kits(A_id,A_name,ExtendedDescription,D_id) " +
                         $"values(@A_id,@A_name,@ExtendedDescription,@D_id)";
            }
            else
            {
                sql = $"Update ActionBild set " +
                    $"A_id=@A_id," +
                    $"A_name=@A_name," +
                     $"ExtendedDescription=@ExtendedDescription" +
                     $"D_id=@D_id ,  Where A_id = @A_id";





            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                A_id = Tmp.ActionId,
                A_name = Tmp.ActionName,
               
                ExtendedDescription = Tmp.ActionDesc,
                D_id=Tmp.Did,
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.ActionId == -1)
            {
                sql = "$=Select max(A_id) from ActionBild where A_name=N'{A_name}'";
                Tmp.ActionId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Action> GetAll()
        {
            List<Action> ActionList = new List<Action>();
            string Sql = "Select * from ActionBild";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Action tmp = new Action()
                {
                    ActionId = int.Parse(Dt.Rows[i]["A_id"].ToString()),
                    ActionName = Dt.Rows[i]["A_name"].ToString(),
                    ActionDesc = Dt.Rows[i]["ExtendedDescription"].ToString(),
                    Did = int.Parse(Dt.Rows[i]["D_id"].ToString())
                    
                    


                };
                ActionList.Add(tmp);
            }
            Db.Close();
            return ActionList;
        }
        public static Action GetById(int Id)
        {
            Action tmp = null;
            string Sql = $"Select * from ActionBild Where A_id = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Action()
                {
                    ActionId = int.Parse(Dt.Rows[0]["A_id"].ToString()),
                    ActionName = Dt.Rows[0]["A_name"].ToString(),
                    ActionDesc = Dt.Rows[0]["ExtendedDescription"].ToString(),
                    Did = int.Parse(Dt.Rows[0]["D_id"].ToString())

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  ActionBild Where A_id = {Id}";
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class SeriesActionDAL
    {
        public static void Save(SeriesAction Tmp)
        {
            string sql;
            if (Tmp.SeriesActionId == -1)
            {
                sql = $"insert into SeriesActions(SeriesActionName,SeriesActionDesc,ChronoloyActions) " +
                         $"values(@SeriesActionName,@SeriesActionDesc,@ChronoloyActions)";
            }
            else
            {
                sql = $"Update SeriesActions set " +
                    
                    $"SeriesActionName=@SeriesActionName," +
                    $"SeriesActionDesc=@SeriesActionDesc," +
                    $"ChronoloyActions=@ChronoloyActions  Where SeriesActionId = @SeriesActionId";



            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                SeriesActionId = Tmp.SeriesActionId,
                SeriesActionName = Tmp.SeriesActionName,
                SeriesActionDesc = Tmp.SeriesActionDesc,
                ChronoloyActions = Tmp.ChronoloyActions ,
               
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.SeriesActionId == -1)
            {
                sql = $"Select max(SeriesActionId) from SeriesActions where SeriesActionName=N'{Tmp.SeriesActionName}'";
                Tmp.SeriesActionId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<SeriesAction> GetAll()
        {
            List<SeriesAction> SeriesOfActionList = new List<SeriesAction>();
            string Sql = "Select * from SeriesActions";
            
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
               SeriesAction tmp = new SeriesAction()
                {
                    SeriesActionId = int.Parse(Dt.Rows[i]["SeriesActionId"].ToString()),
                    SeriesActionName = Dt.Rows[i]["SeriesActionName"].ToString(),
                    SeriesActionDesc = Dt.Rows[i]["SeriesActionDesc"].ToString(),
                    ChronoloyActions  =int.Parse( Dt.Rows[i]["Chronoloyactions"].ToString()),
                   


                };
                SeriesOfActionList.Add(tmp);
            }
            Db.Close();
            return SeriesOfActionList;
        }
        public static SeriesAction GetById(int Id)
        {
            SeriesAction tmp = null;
            string Sql = $"Select * from SeriesActions Where SeriesActionId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new SeriesAction()
                {
                    SeriesActionId = int.Parse(Dt.Rows[0]["SeriesActionId"].ToString()),
                    SeriesActionName = Dt.Rows[0]["SeriesActionName"].ToString(),
                    SeriesActionDesc = Dt.Rows[0]["SeriesActionDesc"].ToString(),
                    ChronoloyActions  = int.Parse(Dt.Rows[0]["Chronoloyactions"].ToString()),
                    
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  SeriesActions Where SeriesActionId = {Id}";
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class SeriesOfActionDAL
    {
        public static void Save(SeriesOfAction Tmp)
        {
            string sql;
            if (Tmp.SereiesId == -1)
            {
                sql = $"insert into SeriesActions(SeriesActionId,SeriesActionsName,SeriesActionsDesc,Chronoloyactions) " +
                         $"values(@SeriesActionId,@SeriesActionsName,@SeriesActionsDesc,@Chronoloyactions)";
            }
            else
            {
                sql = $"Update SeriesActions set " +
                    $"SeriesActionId=@SeriesActionId," +
                    $"SeriesActionsName=@SeriesActionsName," +
                    $"SeriesActionsDesc=@SeriesActionsDesc," +
                    $"Chronoloyactions=@Chronoloyactions,  Where SeriesActionId = @SeriesActionId";



            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                SeriesActionId = Tmp.SereiesId,
                SeriesActionsName = Tmp.SereiesName,
                SeriesActionsDescg = Tmp.ActionDesc,
                Chronoloyactions = Tmp.ActionOrder,
               
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.SereiesId == -1)
            {
                sql = "$=Select max(SeriesActionId) from SeriesActions where SeriesActionId=N'{SeriesActionId}'";
                Tmp.SereiesId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<SeriesOfAction> GetAll()
        {
            List<SeriesOfAction> SeriesOfActionList = new List<SeriesOfAction>();
            string Sql = "Select * from SeriesActions";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
               SeriesOfAction tmp = new SeriesOfAction()
                {
                    SereiesId = int.Parse(Dt.Rows[i]["SeriesActionId"].ToString()),
                    SereiesName = Dt.Rows[i]["SeriesActionsName"].ToString(),
                    ActionDesc = Dt.Rows[i]["SeriesActionsDesce"].ToString(),
                    ActionOrder =int.Parse( Dt.Rows[i]["Chronoloyactions"].ToString()),
                   


                };
                SeriesOfActionList.Add(tmp);
            }
            Db.Close();
            return SeriesOfActionList;
        }
        public static SeriesOfAction GetById(int Id)
        {
            SeriesOfAction tmp = null;
            string Sql = $"Select * from SeriesActions Where SeriesActionId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new SeriesOfAction()
                {
                    SereiesId = int.Parse(Dt.Rows[0]["SeriesActionId"].ToString()),
                    SereiesName = Dt.Rows[0]["SeriesActionsName"].ToString(),
                    ActionDesc = Dt.Rows[0]["SeriesActionsDesc"].ToString(),
                    ActionOrder = int.Parse(Dt.Rows[0]["Chronoloyactions"].ToString()),
                    
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
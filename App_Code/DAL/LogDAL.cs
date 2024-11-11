using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class LogDAL
    {
        public static void Save(Log Tmp)
        {
            string sql;
            if (Tmp.LogId == -1)
            {
                sql = $"insert into Log (TimeAction,LogTime,DueIn,LogRemarks) " +
                         $"values(@TimeAction,@LogTime,@DueIn,@LogRemarks)";
            }
            else
            {
                sql = $"Update LogRemarks set " +

                    $"TimeAction=@TimeAction," +
                    $"LogTime=@LogTime," +
                    $"DueIn=@DueIn," +
                    $"LogRemarks=@LogRemarks  Where LogId = @LogId";



            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                LogId = Tmp.LogId,
                TimeAction = Tmp.TimeAction,
                LogTime = Tmp.LogTime,
                DueIn = Tmp.DueIn,
                LogRemarks = Tmp.LogRemarks,
                
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.LogId == -1)
            {
                sql = $"Select max(LogId) from Log where TimeAction =N'{Tmp.TimeAction}'";
                Tmp.LogId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Log> GetAll()
        {
            List<Log> LogList = new List<Log>();
            string Sql = "Select * from Log";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Log tmp = new Log()
                {
                    LogId = int.Parse(Dt.Rows[i]["LogId"].ToString()),
                    TimeAction =  Dt.Rows[i]["TimeAction"].ToString(),
                    LogTime = Dt.Rows[i]["LogTime"].ToString(),
                    DueIn = Dt.Rows[i]["DueIn"].ToString(),
                    LogRemarks = Dt.Rows[i]["LogRemarks"].ToString(),
                   


                };
                LogList.Add(tmp);
            }
            Db.Close();
            return LogList;
        }
        public static Log GetById(int Id)
        {
            Log tmp = null;
            string Sql = $"Select * from Log Where LogId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Log()
                {
                    LogId = int.Parse(Dt.Rows[0]["LogId"].ToString()),
                    TimeAction =  Dt.Rows[0]["TimeAction"].ToString(),
                    LogTime = Dt.Rows[0]["LogTime"].ToString(),
                    DueIn = Dt.Rows[0]["DueIn"].ToString(),
                    LogRemarks = Dt.Rows[0]["LogRemarks"].ToString(),
                    

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Log Where LogId = {Id}";
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
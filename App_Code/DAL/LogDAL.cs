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
                sql = $"insert into Diary(DiaryId,TimeAction,DiaryTime,DueIn,Diary) " +
                         $"values(@DiaryId,@TimeAction,@DiaryTime,@DueIn,@Diary)";
            }
            else
            {
                sql = $"Update Diary set " +
                    $"DiaryId=@DiaryId," +
                    $"TimeAction=@TimeAction," +
                    $"DiaryTime=@DiaryTime," +
                    $"DueIn=@DueIn," +
                   
                    $"Diary=@Diary,  Where DiaryId = @DiaryId";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                DiaryId = Tmp.LogId,
                TimeAction = Tmp.TimeAction,
                DiaryTime = Tmp.LogTime,
                DueIn = Tmp.DueIn,
                Diary = Tmp.DiaryRemarks,
                
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.LogId == -1)
            {
                sql = "$=Select max(DiaryId) from Diary where DiaryTime=N'{DiaryTime}'";
                Tmp.LogId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Log> GetAll()
        {
            List<Log> LogList = new List<Log>();
            string Sql = "Select * from Diary";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Log tmp = new Log()
                {
                    LogId = int.Parse(Dt.Rows[i]["DiaryId"].ToString()),
                    TimeAction = DateTime.Parse( Dt.Rows[i]["TimeAction"].ToString()),
                    LogTime = Dt.Rows[i]["DiaryTime"].ToString(),
                    DueIn = Dt.Rows[i]["DueIn"].ToString(),
                    DiaryRemarks = Dt.Rows[i]["Diary"].ToString(),
                   


                };
                LogList.Add(tmp);
            }
            Db.Close();
            return LogList;
        }
        public static Log GetById(int Id)
        {
            Log tmp = null;
            string Sql = $"Select * from Diary Where DiaryId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Log()
                {
                    LogId = int.Parse(Dt.Rows[0]["DiaryId"].ToString()),
                    TimeAction = DateTime.Parse( Dt.Rows[0]["TimeAction"].ToString()),
                    LogTime = Dt.Rows[0]["DiaryTime"].ToString(),
                    DueIn = Dt.Rows[0]["DueIn"].ToString(),
                    DiaryRemarks = Dt.Rows[0]["Diary"].ToString(),
                    

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Diary Where DiaryId = {Id}";
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using CardVirtual.backOffice;
using Data;

namespace DAL
{
    public class StockKitDAL
    {
        public static void Save(StockKit Tmp)
        {
            string sql;
            if (Tmp.StockKitId == -1)
            {
                sql = $"insert into StockKits(ExtendedDescription,KitId,JobId,DateIn,DueDate,Status) " +
                         $"values(@ExtendedDescription,@KitId,@JobId,@DateIn,@DueDate,@Status)";
            }
            else
            {
                sql = $"Update StockKits set " +
                      $"ExtendedDescription=@ExtendedDescription," +
                      $"KitId=@KitId,"+
                      $"JobId=@JobId," +
                      $"DateIn=@DateIn," +
                      $"DueDate=@DueDate," +
                      $"Status=@Status  Where StockKitId=@StockKitId";
                 



            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                StockKitId = Tmp.StockKitId,
                ExtendedDescription = Tmp.ExtendedDescription,
                KitId=Tmp.KitId,    
                JobId = Tmp.JobId,
                DateIn = Tmp.DateIn,
                DueDate = Tmp.DueDate,
                Status = Tmp.Status,


            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.StockKitId == -1)
            {
                sql = $"Select max(StockKitId) from StockKits where ExtendedDescription=N'{Tmp.ExtendedDescription}'";
                Tmp.StockKitId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<StockKit> GetAll()
        {
            List<StockKit> StockKitList = new List<StockKit>();
            string Sql = "Select * from StockKits";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                StockKit tmp = new StockKit()
                {
                    StockKitId = int.Parse(Dt.Rows[i]["StockKitId"].ToString()),
                    ExtendedDescription = Dt.Rows[i]["ExtendedDescription"].ToString(),
                    KitId = int.Parse(Dt.Rows[i]["KitId"].ToString()),
                    JobId = int.Parse(Dt.Rows[i]["JobId"].ToString()),
                    DateIn = Dt.Rows[i]["DateIn"].ToString(),
                    DueDate = Dt.Rows[i]["DueDate"].ToString(),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    

                };
               StockKitList.Add(tmp);
            }
            Db.Close();
            return StockKitList;
        }
        public static StockKit GetById(int Id)
        {
            StockKit tmp = null;
            string Sql = $"Select * from StockKits Where StockKitId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new StockKit()
                {
                    StockKitId = int.Parse(Dt.Rows[0]["StockKitId"].ToString()),
                    ExtendedDescription = Dt.Rows[0]["ExtendedDescription"].ToString(),
                    KitId = int.Parse(Dt.Rows[0]["KitId"].ToString()),
                    JobId = int.Parse(Dt.Rows[0]["JobId"].ToString()),
                    DateIn = Dt.Rows[0]["DateIn"].ToString(),
                    DueDate = Dt.Rows[0]["DueDate"].ToString(),
                    Status = bool.Parse( Dt.Rows[0]["Status"].ToString()),
                    
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  StockKits Where StockKitId = {Id}";
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
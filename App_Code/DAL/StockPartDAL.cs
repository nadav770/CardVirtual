using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;
namespace DAL
{
    public class StockPartDAL
    {
        public static void Save(StockPart Tmp)
        {
            string sql;
            if (Tmp.StockPartsId == -1)
            {
                sql = $"insert into StockParts(StockPartsDateReiciving,SeriesActionPart,StockPartsStatus,StockPartsDateEnd) " +
                         $"values(@StockPartsDateReiciving,@SeriesActionPart,@StockPartsStatus,@StockPartsDateEnd)";
            }
            else
            {
                sql = $"Update StockParts set " +
                   
                    $"StockPartsDateReiciving=@StockPartsDateReiciving," +
                    $"SeriesActionPart=@SeriesActionPart," +
                    $"StockPartsStatus=@StockPartsStatus," +

                    $"StockPartsDateEnd=@StockPartsDateEnd   Where StockPartsId = @StockPartsId";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                StockPartsId = Tmp.StockPartsId,
                StockPartsDateReiciving = Tmp.StockPartsDateReiciving,
                SeriesActionPart = Tmp.SeriesActionPart,
                StockPartsStatus = Tmp.StockPartsStatus ,
                StockPartsDateEnd = Tmp.StockPartsDateEnd,
                
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.StockPartsId == -1)
            {
                sql = $"Select max(StockPartsId) from StockParts where StockPartsDateReiciving=N'{Tmp.StockPartsDateReiciving}'";
                Tmp.StockPartsId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<StockPart> GetAll()
        {
            List<StockPart> StockPartList = new List<StockPart>();
            string Sql = "Select * from StockParts";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                StockPart tmp = new StockPart()
                {
                    StockPartsId = int.Parse(Dt.Rows[i]["StockPartsId"].ToString()),
                    StockPartsDateReiciving = Dt.Rows[i]["StockPartsDateReiciving"].ToString(),
                    SeriesActionPart = Dt.Rows[i]["SeriesActionPart"].ToString(),
                    StockPartsStatus  = int.Parse(Dt.Rows[i]["StockPartsStatus"].ToString()),
                    StockPartsDateEnd = Dt.Rows[i]["StockPartsDateEnd"].ToString(),
                   


                };
                StockPartList.Add(tmp);
            }
            Db.Close();
            return StockPartList;
        }
        public static StockPart GetById(int Id)
        {
            StockPart tmp = null;
            string Sql = $"Select * from StockParts Where StockPartsId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new StockPart()
                {
                    StockPartsId = int.Parse(Dt.Rows[0]["StockPartsId"].ToString()),
                    StockPartsDateReiciving = Dt.Rows[0]["StockPartsDateReiciving"].ToString(),
                    SeriesActionPart = Dt.Rows[0]["SeriesActionPart"].ToString(),
                    StockPartsStatus  = int.Parse(Dt.Rows[0]["StockPartsStatus"].ToString()),
                    StockPartsDateEnd = Dt.Rows[0]["StockPartsDateEnd"].ToString(),
                    

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  StockParts Where StockPartsId = {Id}";
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
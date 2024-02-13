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
            if (Tmp.StockPartId == -1)
            {
                sql = $"insert into Kits(StockPartId,StockPartsDateReiciving,SeriesActionPart,StockPartsStatus,StockPartsDateEnd) " +
                         $"values(@StockPartId,@StockPartsDateReiciving,@SeriesActionPart,@StockPartsStatus,@StockPartsDateEnd)";
            }
            else
            {
                sql = $"Update StockParts set " +
                    $"StockPartId=@StockPartId," +
                    $"StockPartsDateReiciving=@StockPartsDateReiciving," +
                    $"SeriesActionPart=@SeriesActionPart," +
                    $"StockPartsStatus=@StockPartsStatus," +

                    $"StockPartsDateEnd=@StockPartsDateEnd,   Where StockPartId = @StockPartId";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                StockPartId = Tmp.StockPartId,
                StockPartsDateReiciving = Tmp.StockPartDateIn,
                SeriesActionPart = Tmp.SeriesActionPart,
                StockPartsStatus = Tmp.StockPartStatus,
                StockPartsDateEnd = Tmp.StockPartDateOut,
                
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.StockPartId == -1)
            {
                sql = "$=Select max(StockPartId) from StockParts where StockPartsDateReiciving=N'{StockPartDateReiciving}'";
                Tmp.StockPartId = (int)Db.ExecuteScalar(sql);
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
                    StockPartId = int.Parse(Dt.Rows[i]["StockPartId"].ToString()),
                    StockPartDateIn = Dt.Rows[i]["StockPartsDateReiciving"].ToString(),
                    SeriesActionPart = Dt.Rows[i]["SeriesActionPart"].ToString(),
                    StockPartStatus = bool.Parse(Dt.Rows[i]["StockPartsStatus"].ToString()),
                    StockPartDateOut = Dt.Rows[i]["StockPartsDateEnd"].ToString(),
                   


                };
                StockPartList.Add(tmp);
            }
            Db.Close();
            return StockPartList;
        }
        public static StockPart GetById(int Id)
        {
            StockPart tmp = null;
            string Sql = $"Select * from StockParts Where StockPartId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new StockPart()
                {
                    StockPartId = int.Parse(Dt.Rows[0]["StockPartId"].ToString()),
                    StockPartDateIn = Dt.Rows[0]["StockPartsDateReiciving"].ToString(),
                    SeriesActionPart = Dt.Rows[0]["SeriesActionPart"].ToString(),
                    StockPartStatus = bool.Parse(Dt.Rows[0]["StockPartsStatus"].ToString()),
                    StockPartDateOut = Dt.Rows[0]["StockPartsDateEnd"].ToString(),
                    

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  StockParts Where StockPartId = {Id}";
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class PartDAL
    {
        public static void Save(Part Tmp)
        {
            string sql;
            if (Tmp.PartId == -1)
            {
                sql = $"insert into Parts(PartId,PartName,PartImiageName,PartDateReceiving) " +
                         $"values(@PartId,@PartName,@PartImiageName,@PartDateReceiving)";
            }
            else
            {
                sql = $"Update Parts set " +
                    $"PartId=@PartId," +
                    $"PartName=@PartName," +
                    $"PartImiageName=@PartImiageName," +
                    
                    $"PartDateReceiving=@PartDateReceiving,Where PartId = @PartId";                                                


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                PartId = Tmp.PartId,
                PartName = Tmp.PartName,
                PartImiageName = Tmp.PartImagieName,
                PartDateReceiving = Tmp.PartDate,
                
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.PartId == -1)
            {
                sql = "$=Select max(PartId) from Parts where PartName=N'{PartName}'";
                Tmp.PartId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Part> GetAll()
        {
            List<Part> PartList = new List<Part>();
            string Sql = "Select * from Parts";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Part tmp = new Part()
                {
                    PartId = int.Parse(Dt.Rows[i]["PartId"].ToString()),
                    PartName = Dt.Rows[i]["PartName"].ToString(),
                    PartImagieName = Dt.Rows[i]["PartImiageName"].ToString(),
                    PartDate = Dt.Rows[i]["PartDateReceiving"].ToString(),
                    

                };
                PartList.Add(tmp);
            }
            Db.Close();
            return PartList;
        }
        public static Part GetById(int Id)
        {
            Part tmp = null;
            string Sql = $"Select * from Parts Where PartId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Part()
                {
                    PartId = int.Parse(Dt.Rows[0]["PartId"].ToString()),
                    PartName = Dt.Rows[0]["PartName"].ToString(),
                    PartImagieName = Dt.Rows[0]["PartImiageName"].ToString(),
                    PartDate = Dt.Rows[0]["PartDateReceiving"].ToString(),
                   

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Parts Where PartId = {Id}";
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
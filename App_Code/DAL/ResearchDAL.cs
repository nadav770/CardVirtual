using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class ResearchDAL
    {
        public static void Save(Research Tmp)
        {
            string sql;
            if (Tmp.ResearchId == -1)
            {
                sql = $"insert into Researchs(ResearchName,ResearchDate,ResearchDesc,ResearchDateReciving,Conclusions) " +
                         $"values(@ResearchName,@ResearchDate,@ResearchDesc,@ResearchDateReciving,@Conclusions)";
            }
            else
            {
                sql = $"Update Researchs set " +
                    
                    $"ResearchName=@ResearchName," +
                    $"ResearchDate=@ResearchDate," +
                    $"ResearchDesc=@ResearchDesc," +
                    $"ResearchDateReciving=@ResearchDateReciving," +
                
                   $"Conclusions=@Conclusions  Where ResearchId = @ResearchId";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                ResearchId = Tmp.ResearchId,
                ResearchName = Tmp.ResearchName,
                
                ResearchDate = Tmp.ResearchDate,
                ResearchDesc = Tmp.ResearchDesc,
                ResearchDateReciving = Tmp.ResearchDateReciving,
                Conclusions = Tmp.Conclusions,



            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.ResearchId == -1)
            {
                sql = $"Select max(ResearchId) from Researchs where ResearchName=N'{Tmp.ResearchName}'";
                Tmp.ResearchId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Research> GetAll()
        {
            List<Research> ResearchList = new List<Research>();
            string Sql = "Select * from Researchs";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
               Research tmp = new Research()
                {
                   ResearchId = int.Parse(Dt.Rows[i]["ResearchId"].ToString()),
                   ResearchName = Dt.Rows[i]["ResearchName"].ToString(),
                   ResearchDate = Dt.Rows[i]["ResearchDate"].ToString(),
                   ResearchDesc = Dt.Rows[i]["ResearchDesc"].ToString(),
                   ResearchDateReciving = Dt.Rows[i]["ResearchDateReciving"].ToString(),
                   Conclusions = Dt.Rows[i]["Conclusions"].ToString(),
                    
                   


                };
                ResearchList.Add(tmp);
            }
            Db.Close();
            return ResearchList;
        }
        public static Research GetById(int Id)
        {
            Research tmp = null;
            string Sql = $"Select * from Researchs Where ResearchId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Research()
                {
                    ResearchId = int.Parse(Dt.Rows[0]["ResearchId"].ToString()),
                    ResearchName = Dt.Rows[0]["ResearchName"].ToString(),
                    ResearchDate = Dt.Rows[0]["ResearchDate"].ToString(),
                    ResearchDesc = Dt.Rows[0]["ResearchDesc"].ToString(),
                   ResearchDateReciving = Dt.Rows[0]["ResearchDateReciving"].ToString(),
                    Conclusions = Dt.Rows[0]["Conclusions"].ToString(),
                    

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Researchs Where ResearchId = {Id}";
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
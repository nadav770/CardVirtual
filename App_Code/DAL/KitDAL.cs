using BLL;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using System.Net.Http;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using DataCollectorTasks;
using Data;

namespace DAL
{
    public class KitDAL
    {
        //פונקציה לשמירת כל הקיטים לתוך המסד נתונים
        public static void Save(Kit Tmp)
        {
            string sql;
            if (Tmp.KitId == -1)                
            {
                sql = $"insert into Kits(K_Id,K_name,K_tag,K_BarCode,K_desk,K_imageName,C_id,K_quantityPart) " +
                         $"values(@K_Id,@K_name,@K_tag,@K_BarCode,@K_desk,@K_imageName,@C_id,@K_quantityPart)";
            }
            else
            {
                sql = $"Update Kits set " +
                    $"K_Id=@K_Id," +
                    $"K_name=@K_name," +
                    $"K_tag=@K_tag," +
                    $"K_BarCode=@K_BarCode," +
                    $"K_desc=@K_desc," +
                    $"K_imageName=@K_imageName," +
                    $"C_id=@C_id," +
                    $"K_quantityPart=@K_quantityPart,  Where K_Id = @K_Id";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new
            
            {
                K_Id = Tmp.KitId,
                K_name = Tmp.KitName,
                K_tag = Tmp.KitTag,
                K_BarCode = Tmp.KitBarcode,
                K_desc = Tmp.KitDesc,
                K_imageName = Tmp.KitImage,
                C_id = Tmp.Cid,
                K_quantityPart = Tmp.KitNumOfParts,
            };

            var parameters = DBcontext.CreateParameters(obj);


          

                Db.ExecuteNonQuery(sql,parameters);


            if (Tmp.KitId == -1)
            {
                sql = "$=Select max(K_Id) from Kits where K_name=N'{K_name}'";
                Tmp.KitId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Kit> GetAll()
        {
            List<Kit> KitList = new List<Kit>();
            string Sql = "Select * from Kits";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Kit tmp = new Kit()
                {
                   KitId = int.Parse(Dt.Rows[i]["K_Id"].ToString()),
                    KitName = Dt.Rows[i]["K_name"].ToString(),
                    KitImage = Dt.Rows[i]["K_imageName"].ToString(),
                    KitBarcode= Dt.Rows[i]["K_BarCode"].ToString(),
                    KitDesc = Dt.Rows[i]["K_desc"].ToString(),
                    KitNumOfParts = int.Parse(Dt.Rows[i]["K_quantityPart"].ToString()),
                    KitTag = Dt.Rows[i]["K_tag"].ToString(),
                    Cid = int.Parse(Dt.Rows[i]["C_id"].ToString()),


                };
                KitList.Add(tmp);
            }
            Db.Close();
            return KitList;
        }
        public static Kit GetById(int Id)
        {
           Kit tmp = null; 
            string Sql = $"Select * from Kits Where K_id = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Kit()
                {
                   KitId = int.Parse(Dt.Rows[0]["K_Id"].ToString()),
                    KitName = Dt.Rows[0]["K_name"].ToString(),
                   KitImage = Dt.Rows[0]["K_imageName"].ToString(),
                    KitDesc = Dt.Rows[0]["K_desc"].ToString(),
                   KitBarcode = Dt.Rows[0]["K_BarCode"].ToString(),
                    KitTag = Dt.Rows[0]["K_tag"].ToString(),
                    KitNumOfParts = int.Parse(Dt.Rows[0]["K_quantityPart"].ToString()),
                    Cid = int.Parse(Dt.Rows[0]["Cid"].ToString()),
                    
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Kits Where K_Id = {Id}";
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


   





    

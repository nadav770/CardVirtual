using BLL;

using System;
using System.Collections.Generic;
using System.Data;
//using System.Linq;
//using System.Net.Http;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

using Data;

namespace DAL
{
    public class KitDAL
    {
        //פונקציה לשמירת כל הקיטים לתוך המסד נתונים
        public static void Save(Kit Tmp)
        {
            string sql;
            //וקודם אנחנו שואלים האם הid שלו ==-1 משמע שאין לו id סידורי
            if (Tmp.KitId == -1)                
            {//אז בעצם מדובר באובייקט חדש שלא קיים בטבלה אז אני פשוט מייצר אותו ע''י שאילתת sql
                sql = $"insert into Kits(KitName,KitTag,KitBarcode,KitDesc,KitImage,CustomerId,KitNumOfParts,KitStatus,RegisterDate ) " +
                         $"values(@KitName,@KitTag,@KitBarcode,@KitDesc,@KitImage,@CustomerId,@KitNumOfParts,@KitStatus,@RegisterDate)";
            }
            else
            {
                sql = $"Update Kits set " +
                   
                    $"KitName=@KitName," +
                    $"KitTag=@KitTag," +
                    $"KitBarcode=@KitBarcode," +
                    $"KitDesc=@KitDesc," +
                    $"KitImage=@KitImage," +
                    $"CustomerId=@CustomerId," +
                    $"KitNumOfParts=@KitNumOfParts," +
                     $"KitStatus=@KitStatus," +
                     $"RegisterDate=@RegisterDate WHERE       KitId = @KitId";



            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new
            
            {
                KitId = Tmp.KitId,
                KitName = Tmp.KitName,
                KitTag = Tmp.KitTag,
                KitBarcode = Tmp.KitBarcode,
                KitDesc = Tmp.KitDesc,
                KitImage = Tmp.KitImage,
                CustomerId = Tmp.CustomerId,
                KitNumOfParts = Tmp.KitNumOfParts,
                KitStatus = Tmp.KitStatus,
                RegisterDate=DateTime.Now,
            };
            //לאחר כל זאת יצרנו משתנה בשם פרמיטר שיחזיק את כל האובייקט
            var parameters = DBcontext.CreateParameters(obj);


          

                Db.ExecuteNonQuery(sql,parameters);


            if (Tmp.KitId == -1)
            {
                sql = $"Select max(KitId) from Kits where KitName=N'{  Tmp.KitName}'";
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

                    KitId = int.Parse(Dt.Rows[i]["KitId"].ToString()),
                    KitName = Dt.Rows[i]["KitName"].ToString(),
                    KitTag = Dt.Rows[i]["KitTag"].ToString(),
                    KitBarcode = Dt.Rows[i]["KitBarcode"].ToString(),
                    KitDesc = Dt.Rows[i]["KitDesc"].ToString(),
                    KitImage = Dt.Rows[i]["KitImage"].ToString(),
                    CustomerId = int.Parse(Dt.Rows[i]["CustomerId"].ToString()),
                    KitNumOfParts = int.Parse(Dt.Rows[i]["KitNumOfParts"].ToString()),
                    KitStatus = bool.Parse(Dt.Rows[i]["KitStatus"].ToString()),
                    RegisterDate = DateTime.Parse(Dt.Rows[i]["RegisterDate"].ToString())



                };

                KitList.Add(tmp);
            }
            Db.Close();
            return KitList;
        }
        public static Kit GetById(int Id)
        {
           Kit tmp = null; 
            string Sql = $"Select * from Kits Where KitId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Kit()
                {
                    KitId = int.Parse(Dt.Rows[0]["KitId"].ToString()),
                    KitName = Dt.Rows[0]["KitName"].ToString(),
                    KitTag = Dt.Rows[0]["KitTag"].ToString(),
                    KitBarcode = Dt.Rows[0]["KitBarcode"].ToString(),
                    KitDesc = Dt.Rows[0]["KitDesc"].ToString(),
                    KitImage = Dt.Rows[0]["KitImage"].ToString(),
                    CustomerId = int.Parse(Dt.Rows[0]["CustomerId"].ToString()),
                    KitNumOfParts = int.Parse(Dt.Rows[0]["KitNumOfParts"].ToString()),
                    KitStatus = bool.Parse(Dt.Rows[0]["KitStatus"].ToString()),
                    RegisterDate = DateTime.Parse(Dt.Rows[0]["RegisterDate"].ToString())



                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Kits Where KitId = {Id}";
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


   





    

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class RoleDAL
    {
        public static void Save(Role Tmp)
        {
            string sql;
            if (Tmp.RoleId == -1)
            {
                sql = $"insert into Roles(RoleName) " +
                         $"values(@RoleName)";
            }
            else
            {
                sql = $"Update Roles set " +
                    
                    
                   
                    $"RoleName=@RoleName  Where RoleId = @RoleId";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                RoleId = Tmp.RoleId,
               RoleName = Tmp.RoleName,
               
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.RoleId == -1)
            {
                sql = $"Select max(RoleId) from Roles where RoleName=N'{Tmp.RoleName}'";
                Tmp.RoleId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Role> GetAll()
        {
            List<Role> RoleList = new List<Role>();
            string Sql = "Select * from Roles";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Role tmp = new Role()
                {
                    RoleId = int.Parse(Dt.Rows[i]["RoleId"].ToString()),
                    RoleName = Dt.Rows[i]["RoleName"].ToString(),
                    


                };
                RoleList.Add(tmp);
            }
            Db.Close();
            return RoleList;
        }
        public static Role GetById(int Id)
        {
            Role tmp = null;
            string Sql = $"Select * from Roles Where RoleId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Role()
                {
                    RoleId = int.Parse(Dt.Rows[0]["RoleId"].ToString()),
                    RoleName = Dt.Rows[0]["RoleName"].ToString(),
                    

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Roles Where RoleId = {Id}";
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
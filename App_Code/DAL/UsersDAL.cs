using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class UsersDAL
    {
        public static void Save(Users Tmp)
        {
            string sql;
            if (Tmp.UserId == -1)
            {
                sql = $"insert into Users(UserName,Pass,AthoUse,RegisterDate,Imaige,UserStatus,UserEmail) " +
                         $"values(@UserName,@Pass,@AthoUse,@RegisterDate,@Imaige,@UserStatus,@UserEmail)";
            }
            else
            {
                sql = $"Update Users set " +
                    
                    $"UserName=@UserName," +
                    $"Pass=@Pass," +
                    $"AthoUse=@AthoUse," +
                    $"RegisterDate=@RegisterDate," +
                    $"Imaige=@Imaige," +
                    
                    $"UserStatus=@UserStatus, " +
                    $"UserEmail=@UserEmail Where UserId = @UserId";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                UserId = Tmp.UserId,
                UserName = Tmp.UserName,
                Pass = Tmp.Pass,
                AthoUse = Tmp.AthoUse,
                RegisterDate = Tmp.RegisterDate,
                Imaige = Tmp.Imaige,
                UserStatus = Tmp.UserStatus,
                UserEmail=Tmp.UserEmail,

            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.UserId == -1)
            {
                sql = $"Select max(UserId) from Users where UserName=N'{Tmp.UserName}'";
                Tmp.UserId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Users> GetAll()
        {
            List<Users> userList = new List<Users>();
            string Sql = "Select * from Users";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Users tmp = new Users()
                {
                    UserId = int.Parse(Dt.Rows[i]["UserId"].ToString()),
                    UserName = Dt.Rows[i]["UserName"].ToString(),
                    Pass = Dt.Rows[i]["Pass"].ToString(),
                    AthoUse = int.Parse(Dt.Rows[i]["AthoUse"].ToString()),
                    RegisterDate = Dt.Rows[i]["RegisterDate"].ToString(),
                    Imaige =int.Parse( Dt.Rows[i]["Imaige"].ToString()),
                    UserStatus =int.Parse( Dt.Rows[i]["UserStatus"].ToString()),
                    UserEmail = Dt.Rows[i]["UserEmail"].ToString(),



                };
                userList.Add(tmp);
            }
            Db.Close();
            return userList;
        }
        public static Users GetById(int Id)
        {
            Users tmp = null;
            string Sql = $"Select * from Users Where UserId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Users()
                {
                    UserId = int.Parse(Dt.Rows[0]["UserId"].ToString()),
                    UserName = Dt.Rows[0]["UserName"].ToString(),
                    Pass = Dt.Rows[0]["Pass"].ToString(),
                    AthoUse =int.Parse( Dt.Rows[0]["AthoUse"].ToString()),
                   
                    Imaige = int.Parse(Dt.Rows[0]["Imaige"].ToString()),
                    UserStatus = int.Parse(Dt.Rows[0]["UserStatus"].ToString()),
                    UserEmail = Dt.Rows[0]["UserEmail"].ToString(),


                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Users Where UserId = {Id}";
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
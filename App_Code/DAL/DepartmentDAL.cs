using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class DepartmentDAL
    {
        public static void Save(Department Tmp)
        {
            string sql;
            if (Tmp.DepartmentId == -1)
            {
                sql = $"insert into Department(DepartmentId,DepartmentName,K_tag,K_BarCode,K_desk,K_imageName,C_id,K_quantityPart) " +
                         $"values(@DepartmentId,@DepartmentName,@K_tag,@K_BarCode,@K_desk,@K_imageName,@C_id,@K_quantityPart)";
            }
            else
            {
                sql = $"Update Department set " +
                    $"DepartmentId=@DepartmentId," +
                    
                    $"DepartmentName=@DepartmentName,  Where DepartmentId = @DepartmentId";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                DepartmentId = Tmp.DepartmentId,
                DepartmentName = Tmp.DepartmentName,
               
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.DepartmentId == -1)
            {
                sql = "$=Select max(DepartmentId) from Department where DepartmentName=N'{DepartmentName}'";
                Tmp.DepartmentId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Department> GetAll()
        {
            List<Department> DepartmentList = new List<Department>();
            string Sql = "Select * from Kits";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Department tmp = new Department()
                {
                    DepartmentId = int.Parse(Dt.Rows[i]["DepartmentId"].ToString()),
                    DepartmentName = Dt.Rows[i]["DepartmentName"].ToString(),
                    


                };
                DepartmentList.Add(tmp);
            }
            Db.Close();
            return DepartmentList;
        }
        public static Department GetById(int Id)
        {
            Department tmp = null;
            string Sql = $"Select * from Department Where DepartmentId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Department()
                {
                    DepartmentId = int.Parse(Dt.Rows[0]["DepartmentId"].ToString()),
                    DepartmentName = Dt.Rows[0]["DepartmentName"].ToString(),
                   

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Department Where DepartmentId = {Id}";
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
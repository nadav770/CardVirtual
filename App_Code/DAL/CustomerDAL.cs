using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using BLL;
using Data;

namespace DAL
{
    public class CustomerDAL
    {
        public static void Save(Customer Tmp)
        {
            string sql;
            if (Tmp.CustomerId == -1)
            {
                sql = $"insert into Customers(C_id,C_name,C_Adress,C_phone,ContactPersonName,ContactPersonPhone,C_date,Remarks,C_status,C_mail) " +
                         $"values(@C_id,@C_name,@C_Adress,@C_phone,@ContactPersonName,@ContactPersonPhone,@C_date,@Remarks,@C_status,@C_mail)";
            }
            else
            {
                sql = $"Update Customers set " +
                    $"C_id=@C_id," +
                    $"C_name=@C_name," +
                    $"C_Adress=@C_Adress," +
                    $"C_phone=@C_phone," +
                    $"ContactPersonName=@ContactPersonName," +
                    $"ContactPersonPhone=@ContactPersonPhone," +
                    $"C_date=@C_date," +
                    $"C_status=@C_status,"+
                    $"C_mail=@C_mail"+
                    $"Remarks=@Remarks,  Where C_id = @C_id";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                C_id = Tmp.CustomerId,
                C_name = Tmp.CustomerName,
                C_Adress = Tmp.CustomerAdress,
                C_phone = Tmp.CustomerPhone,
                ContactPersonName = Tmp.CustomerContactPerson,
                ContactPersonPhone = Tmp.CustomerContactPersonPhone,
                C_date = Tmp.CustomerDateStart,
                Remarks = Tmp.Remarks,
                C_status=Tmp.CustomerStatus,
                C_mail=Tmp.CustomerMail
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.CustomerId == -1)
            {
                sql = "$=Select max(C_id) from Customers where C_name=N'{C_name}'";
                Tmp.CustomerId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Customer> GetAll()
        {
            List<Customer> CustomerList = new List<Customer>();
            string Sql = "Select * from Customers";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Customer tmp = new Customer()
                {
                    CustomerId = int.Parse(Dt.Rows[i]["C_id"].ToString()),
                    CustomerName= Dt.Rows[i][" C_name"].ToString(),
                    CustomerAdress = Dt.Rows[i]["C_Adress"].ToString(),
                    CustomerPhone = Dt.Rows[i]["C_phone"].ToString(),
                    CustomerContactPerson = Dt.Rows[i]["ContactPersonName"].ToString(),
                    CustomerContactPersonPhone = Dt.Rows[i]["ContactPersonPhone"].ToString(),
                    CustomerDateStart = Dt.Rows[i]["C_date"].ToString(),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    CustomerStatus = int.Parse(Dt.Rows[i]["C_status"].ToString()),
                    CustomerMail = Dt.Rows[i]["C_mail"].ToString()

                };
                CustomerList.Add(tmp);
            }
            Db.Close();
            return CustomerList;
        }
        public static Customer GetById(int Id)
        {
            Customer tmp = null;
            string Sql = $"Select * from Customers Where C_id = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Customer()
                {
                    CustomerId = int.Parse(Dt.Rows[0]["C_id"].ToString()),
                    CustomerName = Dt.Rows[0][" C_name"].ToString(),
                    CustomerAdress = Dt.Rows[0]["C_Adress"].ToString(),
                    CustomerPhone = Dt.Rows[0]["C_phone"].ToString(),
                    CustomerContactPerson= Dt.Rows[0]["ContactPersonName"].ToString(),
                    CustomerContactPersonPhone = Dt.Rows[0]["ContactPersonPhone"].ToString(),
                    CustomerDateStart = Dt.Rows[0]["C_date"].ToString(),
                    CustomerStatus = int.Parse(Dt.Rows[0]["C_status"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    CustomerMail = Dt.Rows[0]["C_mail"].ToString()

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Customers Where C_id = {Id}";
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
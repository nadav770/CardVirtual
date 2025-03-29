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
                sql = $"insert into Customer(CustomerName,CustomerAdress,CustomerPhone,CustomerContactPerson,CustomerContactPersonPhone,CustomerDateStart,Remarks,CustomerStatus,CustomerMail) " +
                         $"values(@CustomerName,@CustomerAdress,@CustomerPhone,@CustomerContactPerson,@CustomerContactPersonPhone,@CustomerDateStart,@Remarks,@CustomerStatus,@CustomerMail)";
            }
            else
            {

                sql = $"Update Customer set " +
                $"CustomerName=@CustomerName," +
                    $"CustomerAdress=@CustomerAdress," +
                    $"CustomerPhone=@CustomerPhone," +
                    $"CustomerContactPerson=@CustomerContactPerson," +
                    $"CustomerContactPersonPhone=@CustomerContactPersonPhone," +
                    $"CustomerDateStart=@CustomerDateStart," +
                    $"CustomerStatus=@CustomerStatus,"+
                    $"CustomerMail=@CustomerMail,"+
                    $"Remarks=@Remarks   Where CustomerId = @CustomerId";


            }

            //קריאת מסד הנתונים ע''י מחרוזת ומשתנה יחוס מוסג var
            DBcontext Db = new DBcontext();
            var obj = new

            {
                CustomerId = Tmp.CustomerId,
                CustomerName = Tmp.CustomerName,
                CustomerAdress = Tmp.CustomerAdress,
                CustomerPhone = Tmp.CustomerPhone,
                CustomerContactPerson = Tmp.CustomerContactPerson,
                CustomerContactPersonPhone = Tmp.CustomerContactPersonPhone,
                CustomerDateStart = DateTime.Now,
                Remarks = Tmp.Remarks,
                CustomerStatus=Tmp.CustomerStatus,
                CustomerMail=Tmp.CustomerMail
            };




            var lstParam = DBcontext.CreateParameters(obj);

            Db.ExecuteNonQuery(sql, lstParam);


            if (Tmp.CustomerId == -1)
            {
                sql = $"Select max(CustomerId) from Customer where CustomerName=N'{Tmp.CustomerName}'";
                Tmp.CustomerId = (int)Db.ExecuteScalar(sql);
            }
            Db.Close();



        }
        public static List<Customer> GetAll()
        {
            List<Customer> CustomerList = new List<Customer>();
            string Sql = "Select * from Customer";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Customer tmp = new Customer()
                {
                    CustomerId = int.Parse(Dt.Rows[i]["CustomerId"].ToString()),
                    CustomerName= Dt.Rows[i]["CustomerName"].ToString(),
                    CustomerAdress = Dt.Rows[i]["CustomerAdress"].ToString(),
                    CustomerPhone = Dt.Rows[i]["CustomerPhone"].ToString(),
                    CustomerContactPerson = Dt.Rows[i]["CustomerContactPerson"].ToString(),
                    CustomerContactPersonPhone = Dt.Rows[i]["CustomerContactPersonPhone"].ToString(),
                    CustomerDateStart = DateTime.Parse(Dt.Rows[i]["CustomerDateStart"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    CustomerStatus = bool.Parse(Dt.Rows[i]["CustomerStatus"].ToString()),
                    CustomerMail = Dt.Rows[i]["CustomerMail"].ToString()

                };
                CustomerList.Add(tmp);
            }
            Db.Close();
            return CustomerList;
        }
        public static Customer GetById(int Id)
        {
            Customer tmp = null;
            string Sql = $"Select * from Customer Where CustomerId = {Id}";
            DBcontext Db = new DBcontext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Customer()
                {
                    CustomerId = int.Parse(Dt.Rows[0]["CustomerId"].ToString()),
                    CustomerName = Dt.Rows[0]["CustomerName"].ToString(),
                    CustomerAdress = Dt.Rows[0]["CustomerAdress"].ToString(),
                    CustomerPhone = Dt.Rows[0]["CustomerPhone"].ToString(),
                    CustomerContactPerson= Dt.Rows[0]["CustomerContactPerson"].ToString(),
                    CustomerContactPersonPhone = Dt.Rows[0]["CustomerContactPersonPhone"].ToString(),
                    CustomerDateStart = DateTime.Parse(Dt.Rows[0]["CustomerDateStart"].ToString()),
                    CustomerStatus = bool.Parse(Dt.Rows[0]["CustomerStatus"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    CustomerMail = Dt.Rows[0]["CustomerMail"].ToString()

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  Customer Where CustomerId = {Id}";
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
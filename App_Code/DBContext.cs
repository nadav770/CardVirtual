using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;

//using DataCollectorTasks;

namespace Data
{
    public class DBcontext
    {
        //הגדרת משתנה שיחזיק את המחרוזת התחברות למסד נתונים
        public string ConnStr { get; set; }
        //הגדרת משתנה מסוג sqlConnection שיחזיק בצורה פיזית את המחרוזת התחברות
        public SqlConnection Conn { get; set; }
        //הגדרת פקד מסוג sql 
        public SqlCommand Cmd { get; set; }
        // קונסטרקור מסוג המחלקה שיקמפל את החיבור
        public DBcontext()
        {
            //קבלת מחרוזת ההתחברות המקורית ע''י מנהל ההגדרות
            ConnStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TestDb.mdf;Integrated Security=True;Connect Timeout=30";
          //  Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "C:\Users\nadav\OneDrive\שולחן העבודה\עבודות שנה ב'\פרויקט גמר\CardFlow\CardFlow\App_Data\CardFlowDB.mdf"; Integrated Security = True; Connect Timeout = 30
            Conn = new SqlConnection();
            Conn.ConnectionString = ConnStr;
            Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            

        }
        public int ExecuteNonQuery(string Sql,List <SqlParameter> Lst=null)
        {
            int RecCount = 0;

            Cmd.CommandText = Sql;
            if(Lst!=null)
            {
                for(int i=0;i<Lst.Count;i++)
                {
                    Cmd.Parameters.Add(Lst[i]);
                }
            }

            RecCount = Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            return RecCount;

        }
        public DataTable ExecuteParam(string Sql, List<SqlParameter> Lst = null)
        {
            DataTable Dt = new DataTable();
            SqlDataAdapter Da=new SqlDataAdapter();

            Cmd.CommandText = Sql;
            if (Lst != null)
            {
                for (int i = 0; i < Lst.Count; i++)
                {
                    Cmd.Parameters.Add(Lst[i]);
                }
            }
            Da.SelectCommand = Cmd;
            Da.Fill(Dt);
                
            
           
            return Dt;

        }
        public static List<SqlParameter> CreateParameters(object parametersObject)
        {
            var parameters = new List<SqlParameter>();

            foreach (PropertyInfo property in parametersObject
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                parameters.Add(new SqlParameter($"@{property.Name}", property.GetValue(parametersObject, null)));
            }

            return parameters;
        }
        public DataTable Execute(string Sql, int CmdType = 1)
        {

            Cmd.CommandText = Sql;
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            if (CmdType == 2)
                Cmd.CommandType = CommandType.StoredProcedure;

            Da.SelectCommand = Cmd;
            Da.Fill(Dt);
            Cmd.Dispose();
            return Dt;
        }
        //שאילתא שמחזירה שדה אחד
        public object ExecuteScalar(string Sql)
        {

            Cmd.CommandText = Sql;
            return Cmd.ExecuteScalar();

        }
        
        
      

        public void Open()
        {
            Conn.Open();
        }
        public void Close()
        {
            Conn.Close();





        }

        internal object ExecuteScalar(string query, List<SqlParameter> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
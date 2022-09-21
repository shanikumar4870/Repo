using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;

namespace ShaniTest_Project.Models
{
    public class CommonMethod
    {
        public static DataTable ExecuteQuery(string procname, string[,] Param)
        {
             try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                SqlCommand cmd = new SqlCommand(procname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Param.Length / 2; i++)
                {
                    cmd.Parameters.AddWithValue(Param[i, 0], Param[i, 1]);
                }
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlData.Fill(dt);
                return dt;
            }
          catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ExecuteQuery(string procname)
        {

            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                SqlCommand cmd = new SqlCommand(procname, connection);
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlData.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static  string DataBind (DataTable dt)
        {
              StringBuilder sb = new StringBuilder();
            try
            {

                sb.Append("<table border='1' class='table table-active table-hover table-bordered'>");
                sb.Append("<tr>");
                sb.Append("<th>Name</th>");
                sb.Append("<th>Mobile</th>");
                sb.Append("<th>Email</th>");
                sb.Append("<th>DOB</th>");
                sb.Append("<th>Password</th>");
                sb.Append("<th>Designation</th>");
                sb.Append("<th colspan='2'>Action</th>");
                sb.Append("</tr>");
            
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + dt.Rows[i]["Name"].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["Email"].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["DOB"].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["Password"].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["Designation"].ToString() + "</td>");
                    sb.Append("<td><button onclick='DeleteRecord(" + dt.Rows[i]["ID"].ToString() + ")'>Delete</td>");
                    sb.Append("<td><button onclick='EditRecord(" + dt.Rows[i]["ID"].ToString() + ")'>Edit</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table");
                return sb.ToString();       
            }

            catch(Exception ex)
            {
                throw ex;

            }
        }
     
    }
}
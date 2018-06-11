using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Default6 : System.Web.UI.Page
    {
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Uploaded Folder/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(path);
                    // Connection String to Excel Workbook
                    string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = excelConnectionString;
                    OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                    connection.Open();
                    // Create DbDataReader to Data Worksheet
                    DbDataReader dr = command.ExecuteReader();
                    // SQL Server Connection String
                    string sqlConnectionString = @"Data Source=MYPC;Initial Catalog=Student;User ID=sa;Password=wintellect";
                    // Bulk Copy to SQL Server 
                    SqlBulkCopy bulkInsert = new SqlBulkCopy(sqlConnectionString);
                    bulkInsert.DestinationTableName = "Student_Record";
                    bulkInsert.WriteToServer(dr);
                    Label1.Text = "Ho Gaya";
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                }
            }
        }
    }
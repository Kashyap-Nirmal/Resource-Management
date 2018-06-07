using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Resource_Book : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
         DropDownList2.Items.Clear();
         DropDownList2.Items.Insert(0, "ALL");
        }            
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedIndex == 0)
        {
            /*SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            //SqlCommand cmd = new SqlCommand("insert into Resource_Allocation values ('" + txtdate.Text + "','" + txtfromtime.Text + "','" + txttotime.Text + "'," + int.Parse(DropDownList1.SelectedValue) + ")",cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();*/
            GridView1.DataSource = null;
            GridView1.DataBind();
            SqlDataAdapter da_alloc = new SqlDataAdapter("select resource_id,allocation_s_time,allocation_e_time,allocation_s_date,purpose from Resource_Allocation where  room_type=" + int.Parse(DropDownList1.SelectedValue) + " and allocation_s_date='" + txtdate.Text + "' and NOT((allocation_s_time>='" + txttotime.Text + "') or (allocation_e_time<='" + txtfromtime.Text + "')) ", cn);
            DataSet ds_alloc = new DataSet();
            da_alloc.Fill(ds_alloc);
            SqlDataAdapter da_rooms = new SqlDataAdapter("select Rooms.*,Resource_Details.*,Authorised_user.Name,Authorised_user.Department,Authorised_user.Extension from Rooms inner join Resource_Details on Rooms.building=Resource_Details.Id inner join Authorised_user on Rooms.authorised_user= Authorised_user.Id where Rooms.Type=" + int.Parse(DropDownList1.SelectedValue) + " ", cn);
            //select * from Rooms inner join Resource_Details on Rooms.building=Resource_Details.Id where Rooms.Type=;
            DataSet ds_rooms = new DataSet();
            da_rooms.Fill(ds_rooms);
            //where Type=" + int.Parse(DropDownList1.SelectedValue) +"
            ds_rooms.Tables[0].Columns.Add("Availability");
            ds_rooms.Tables[0].Columns.Add("From");
            ds_rooms.Tables[0].Columns.Add("To");
            ds_rooms.Tables[0].Columns.Add("Date");
            ds_rooms.Tables[0].Columns.Add("Purpose");
            if (ds_alloc.Tables[0].Rows.Count == 0)
            {
                for (int i = 0; i < ds_rooms.Tables[0].Rows.Count; i++)
                {
                    ds_rooms.Tables[0].Rows[i]["Availability"] = "Available";
                }
            }
            else
            {
                for (int i = 0; i < ds_rooms.Tables[0].Rows.Count; i++)
                {
                    ds_rooms.Tables[0].Rows[i]["Availability"] = "Available";
                    ds_rooms.Tables[0].Rows[i]["From"] = "None";
                    ds_rooms.Tables[0].Rows[i]["To"] = "None";
                    ds_rooms.Tables[0].Rows[i]["Date"] = "None";
                    ds_rooms.Tables[0].Rows[i]["Purpose"] = "None";
                    for (int j = 0; j < ds_alloc.Tables[0].Rows.Count; j++)
                    {
                        if (int.Parse(ds_alloc.Tables[0].Rows[j][0].ToString()) == int.Parse(ds_rooms.Tables[0].Rows[i]["Id"].ToString()))
                        {
                            ds_rooms.Tables[0].Rows[i]["Availability"] = "Not Available";
                            ds_rooms.Tables[0].Rows[i]["From"] = ds_alloc.Tables[0].Rows[j][1].ToString();
                            ds_rooms.Tables[0].Rows[i]["To"] = ds_alloc.Tables[0].Rows[j][2].ToString();
                            ds_rooms.Tables[0].Rows[i]["Date"] = ((DateTime)ds_alloc.Tables[0].Rows[j][3]).ToShortDateString();
                            ds_rooms.Tables[0].Rows[i]["Purpose"] = ds_alloc.Tables[0].Rows[j][4].ToString();
                            break;
                            //ds_rooms.Tables[0].Rows[i]["Availability"] = "Not Available";
                        }
                    }
                }
            }
            GridView1.DataSource = ds_rooms;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            SqlDataAdapter da_alloc = new SqlDataAdapter("select resource_id,allocation_s_time,allocation_e_time,allocation_s_date,purpose from Resource_Allocation where resource_id=" + int.Parse(DropDownList2.SelectedValue.ToString()) + " and room_type=" + int.Parse(DropDownList1.SelectedValue) + " and allocation_s_date='" + txtdate.Text + "' and NOT((allocation_s_time>='" + txttotime.Text + "') or (allocation_e_time<='" + txtfromtime.Text + "')) ", cn);
            DataSet ds_alloc = new DataSet();
            da_alloc.Fill(ds_alloc);
            SqlDataAdapter da_rooms = new SqlDataAdapter("select Rooms.*,Resource_Details.*,Authorised_user.Name,Authorised_user.Department,Authorised_user.Extension from Rooms inner join Resource_Details on Rooms.building=Resource_Details.Id inner join Authorised_user on Rooms.authorised_user= Authorised_user.Id where Rooms.Type=" + int.Parse(DropDownList1.SelectedValue) + " and Rooms.Id=" + int.Parse(DropDownList2.SelectedValue.ToString()) + " ", cn);
            //select * from Rooms inner join Resource_Details on Rooms.building=Resource_Details.Id where Rooms.Type=;
            DataSet ds_rooms = new DataSet();
            da_rooms.Fill(ds_rooms);
            //where Type=" + int.Parse(DropDownList1.SelectedValue) +"
            ds_rooms.Tables[0].Columns.Add("Availability");
            ds_rooms.Tables[0].Columns.Add("From");
            ds_rooms.Tables[0].Columns.Add("To");
            ds_rooms.Tables[0].Columns.Add("Date");
            ds_rooms.Tables[0].Columns.Add("Purpose");
            if (ds_alloc.Tables[0].Rows.Count == 0)
            {
                for (int i = 0; i < ds_rooms.Tables[0].Rows.Count; i++)
                {
                    ds_rooms.Tables[0].Rows[i]["Availability"] = "Available";
                }
            }
            else
            {
                for (int i = 0; i < ds_rooms.Tables[0].Rows.Count; i++)
                {
                    ds_rooms.Tables[0].Rows[i]["Availability"] = "Available";
                    ds_rooms.Tables[0].Rows[i]["From"] = "None";
                    ds_rooms.Tables[0].Rows[i]["To"] = "None";
                    ds_rooms.Tables[0].Rows[i]["Date"] = "None";
                    ds_rooms.Tables[0].Rows[i]["Purpose"] = "None";
                    for (int j = 0; j < ds_alloc.Tables[0].Rows.Count; j++)
                    {
                        if (int.Parse(ds_alloc.Tables[0].Rows[j][0].ToString()) == int.Parse(ds_rooms.Tables[0].Rows[i]["Id"].ToString()))
                        {
                            ds_rooms.Tables[0].Rows[i]["Availability"] = "Not Available";
                            ds_rooms.Tables[0].Rows[i]["From"] = ds_alloc.Tables[0].Rows[j][1].ToString();
                            ds_rooms.Tables[0].Rows[i]["To"] = ds_alloc.Tables[0].Rows[j][2].ToString();
                            ds_rooms.Tables[0].Rows[i]["Date"] = ((DateTime)ds_alloc.Tables[0].Rows[j][3]).ToShortDateString();
                            ds_rooms.Tables[0].Rows[i]["Purpose"] = ds_alloc.Tables[0].Rows[j][4].ToString();
                            break;
                            //ds_rooms.Tables[0].Rows[i]["Availability"] = "Not Available";
                        }
                    }
                }
            }
            GridView1.DataSource = ds_rooms;
            GridView1.DataBind();
        }
       
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       Response.Write(e.CommandArgument.ToString());
      // Response.Write(GridView1.SelectedRow.RowIndex.ToString());
       SqlCommand cmd = new SqlCommand(insert into Resource_Allocation values ('" + txtsdate.Text + "','" + txtfromtime.Text + "','" + txttotime.Text + "'," + int.Parse(e.CommandArgument.ToString()) + ",'" + txtpurpose.Text + "',0," + int.Parse(DropDownList1.SelectedValue) + ",'" + txtedate.Text + "')",cn);
       cn.Open();
       cmd.ExecuteNonQuery();
       cn.Close();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btnbook_Command(object sender, CommandEventArgs e)
    {
        //Response.Write(e.CommandArgument.ToString());
       //SqlCommand cmd=new SqlCommand("insert into Resource_Allocation ")
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((Label)GridView1.Rows[i].Cells[1].FindControl("lblavailability")).Text == "Available")
            {
                //((Button)GridView1.Rows[i].Cells[0].FindControl("btnbook")).Enabled = true;
                GridView1.Rows[i].Enabled = true;
            }
            else
            {
                //((Button)GridView1.Rows[i].Cells[0].FindControl("btnbook")).Enabled = false;
                GridView1.Rows[i].Enabled = false;
            }
        }
    }
}

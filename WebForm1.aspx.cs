using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace cimcom
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button1.CommandName = "Insert";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                string empid = TextBox1.Text;
                string empname = TextBox2.Text;
                string email = TextBox3.Text;

                string gender = male.Checked ? "M" : female.Checked ? "F" : "";
                string doj = TextBox4.Text;

                if (Button1.CommandName == "Insert")
                {
                    cmd.CommandText = $"INSERT INTO Emp (EmpID, EmpName, EmailID, Gender, DOJ) VALUES ({empid}, '{empname}', '{email}', '{gender}', '{doj}')";
                    cmd.ExecuteNonQuery();
                    Label1.Text = "DATA INSERTED";
                }
                else if (Button1.CommandName == "Save")
                {
                    string updatingEmpID = ViewState["UpdatingEmpID"].ToString();

                    cmd.CommandText = $"UPDATE Emp SET EmpName = '{empname}', EmailID = '{email}', Gender = '{gender}', DOJ = '{doj}' WHERE EmpID = {updatingEmpID}";
                    cmd.ExecuteNonQuery();
                    Label1.Text = "DATA UPDATED SUCCESSFULLY";

                    // Reset the form
                    Button1.Text = "Insert";
                    Button1.CommandName = "Insert";
                    ViewState["UpdatingEmpID"] = null;
                }

                con.Close();
                ClearForm();
                Button4_Click(null, null); // Refresh the GridView
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Emp";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            if (e.CommandName == "Delete")
            {
                try
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    string empid = e.CommandArgument.ToString();
                    cmd.CommandText = "DELETE FROM Emp WHERE EmpID = " + empid;
                    cmd.ExecuteNonQuery();

                    Label1.Text = "DATA DELETED SUCCESSFULLY";
                    con.Close();
                    Button4_Click(null, null); // Refresh the GridView
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                }
            }
            else if (e.CommandName == "Update")
            {
                try
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    string empid = e.CommandArgument.ToString();
                    cmd.CommandText = "SELECT * FROM Emp WHERE EmpID = " + empid;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        TextBox1.Text = row["EmpID"].ToString();
                        TextBox2.Text = row["EmpName"].ToString();
                        TextBox3.Text = row["EmailID"].ToString();
                        if (row["Gender"].ToString() == "M")
                        {
                            male.Checked = true;
                        }
                        else if (row["Gender"].ToString() == "F")
                        {
                            female.Checked = true;
                        }
                        TextBox4.Text = row["DOJ"].ToString();
                    }

                    Button1.Text = "Save";
                    Button1.CommandName = "Save";
                    ViewState["UpdatingEmpID"] = empid;
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                }
            }
        }

        private void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            male.Checked = false;
            female.Checked = false;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }
    }
}
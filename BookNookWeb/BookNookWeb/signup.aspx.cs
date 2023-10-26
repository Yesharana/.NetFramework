using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookNookWeb
{

    public partial class signup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //sign up button click event
        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con1= new SqlConnection(strcon);

                con1.Open();

                SqlCommand cmd = new SqlCommand("insert into Users(UserId,UserName,DOB,ContactNo,EmailId,State,City,PinCode,Address,Password,AccountStatus) values(@UserId,@UserName,@DOB,@ContactNo,@EmailId,@State,@City,@PinCode,@Address,@Password,@AccountStatus) ", con1);

                cmd.Parameters.AddWithValue("@UserId", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@UserName", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@EmailId",TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@State",DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@City",TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@PinCode", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Address",TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@AccountStatus", "Pending");

                cmd.ExecuteNonQuery();
                con1.Close();

                Response.Write("<script>alert('Sign up successful!! Go to login page to Login');</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }

        }
    }
}
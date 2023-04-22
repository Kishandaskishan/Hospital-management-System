using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Hospital_management_System.Users
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forgotpass.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btn_login_b_Click(object sender, EventArgs e)
        {
            string server = "localhost";
            string database = "hms";
            string uid = "root";
            string password = "root";
            string con;


            con = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PWD=" + password + ";";
            MySqlConnection db = new MySqlConnection(con);
            try
            {
                db.Open();

            }
            catch (Exception error)
            {
                Response.Write("<script>alert('Database connection error !" + error.Message + "')</script>");
            }



            string insert = "insert into registration(Uname,Pass) values('" + txt_signup_username.Text + "','" + txt_signup_pass.Text + "')";

            MySqlCommand cmd1 = new MySqlCommand(insert, db);
            int noOfExecute = cmd1.ExecuteNonQuery();

            if (noOfExecute > 0)
            {
                Response.Write("<script>alert('Data inserted successfully');window.location.href = 'Loginpage.aspx';</script>");

                txt_signup_username.Text = "";
                txt_signup_pass.Text = "";


            }
            else
            {
                Response.Write("<script>alert('Data inserted error contact to admin')</script>");
            }
            db.Close();
        }
    }
}
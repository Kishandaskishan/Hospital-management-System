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
    public partial class WebForm9 : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string server = "localhost";
            string database = "hms";
            string uid = "root";
            string password = "root";
            string con;


            con = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PWD=" + password + ";";
            MySqlCommand cmd;

            
        }

        protected void btn_main_appointment_Submit_Click(object sender, EventArgs e)
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



                string insert = "insert into apponttab(Section,Name,Gender,Mobile,Email,Date) values(' " + DropDownList_Section.Text + "','" + txt_Appoint_name.Text + "','" + DropDownList_gender.Text + "'," + txt_Apoint_Mobile.Text + ",'" + txt_Apoint_Email.Text + "','" + datepicke.Text + "')";

                MySqlCommand cmd1 = new MySqlCommand(insert, db);
                int noOfExecute = cmd1.ExecuteNonQuery();

                if (noOfExecute > 0)
                {
                    Response.Write("<script>alert('Data inserted successfully')</script>");

                    DropDownList_Section.Text = "";
                    txt_Appoint_name.Text = "";
                    DropDownList_gender.Text = "";
                    txt_Apoint_Mobile.Text = "";
                    txt_Apoint_Email.Text = "";
                    datepicke.Text = "";


                }
                else
                {
                    Response.Write("<script>alert('Data inserted error contact to admin')</script>");
                }
                db.Close();

            
        }
    }
}
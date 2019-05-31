using System.Data.SqlClient;

namespace POS_System
{
    class UsersClass
    {
        static string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["Data Source=DESKTOP-TDJD3P5/MSSQLSERVER14;Initial Catalog=pos_system;Integrated Security=True"].ConnectionString;
        SqlConnection con = new SqlConnection(conStr);

        public void userRegister(string _un, string _pass, string _secQu, string _ans)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO tbl_Users VALUES('" + _un + "','" + _pass + "','" + _secQu + "','" + _ans + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public SqlDataReader userLogin(string _userName, string _password)
        {
            con.Close();
            SqlCommand com = new SqlCommand("SELECT * FROM tbl_Users WHERE UserName='" + _userName + "' AND Password='" + _password + "'", con);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            return dr;
        }
    }
}

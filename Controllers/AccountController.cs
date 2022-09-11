using Login_MVC_.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_MVC_.Models;
using System.Data;

namespace Login_MVC_.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();

        SqlDataReader dr;

        public object Application_settting { get; private set; }

        // GET: Account

       [HttpGet]

        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {

            con.ConnectionString = @"Data Source=DESKTOP-89T23RQ\SQLEXPRESS;Initial Catalog = MVC_Login_DB; User ID = sa; Password=abdullah123";
        }

        [HttpPost]

        public ActionResult Verify (Account acc)
        {

            using (SqlConnection con = new SqlConnection(ApplicationSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[login_Verifyingdetails]", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", acc.Name);
                    cmd.Parameters.AddWithValue("@Password", acc.Password);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        return View("Create");
                    }
                    else
                    {
                        return View("Error");
                    }

                }
            }


















            //connectionString();
            //con.Open();
            //com.Connection = con;
            //com.CommandText = "select * from tbl_login where Username='" + acc.Name + "' and Password='" + acc.Password + "'";
            //dr = com.ExecuteReader();

            //if (dr.Read())
            //{
            //    con.Close();
            //    return View("Create");
            //}
            //else
            //{
            //    con.Close();
            //    return View("Error");
            //}

        }
        
    }
}
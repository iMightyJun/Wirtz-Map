using FreeTime.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;

namespace FreeTime.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            // set up domain context
            return View();
        }

        [HttpGet]
        public JsonResult findPerson(string searchTerm)
        {
            string path = "LDAP://WBGAD.WIRTZBEV.COM/OU=WBGIL,DC=wbgad,DC=wirtzbev,DC=com";
            List<Person> retList = new List<Person>();
            try
            {
                using (HostingEnvironment.Impersonate())
                {
                    DirectoryEntry rootEntry = new DirectoryEntry(path);
                    rootEntry.Username = null;
                    rootEntry.Password = null;
                    rootEntry.AuthenticationType = AuthenticationTypes.Secure;
                    DirectorySearcher search = new DirectorySearcher(rootEntry);
                    search.Filter = ("(&(objectCategory=Person)(objectClass=user)(displayName=*" + searchTerm + "*))");
                    search.PageSize = 250;
                    foreach (SearchResult res in search.FindAll())
                    {
                        DirectoryEntry de = res.GetDirectoryEntry();
                        //de.Properties["sAMAccountName"].Value != null && de.Properties["givenName"].Value != null && de.Properties["sn"].Value != null && de.Properties["telephoneNumber"].Value != null && de.Properties["title"].Value != null)
                        if (de.Properties["sAMAccountName"].Value != null && de.Properties["displayName"].Value != null)
                        {
                            //Debug.WriteLine("First Name " + de.Properties["givenName"].Value.ToString());
                            //Debug.WriteLine("Last Name " + de.Properties["sn"].Value.ToString());
                            //Debug.WriteLine("Telephone " + de.Properties["telephoneNumber"].Value.ToString());
                            //Debug.WriteLine("Title " + de.Properties["title"].Value.ToString());

                            string fName = de.Properties["givenName"].Value == null ? "N/A" : de.Properties["givenName"].Value.ToString();
                            string lName = de.Properties["sn"].Value == null ? "N/A" : de.Properties["sn"].Value.ToString();
                            string telephone = de.Properties["telephoneNumber"].Value == null ? "N/A" : de.Properties["telephoneNumber"].Value.ToString();
                            string title = de.Properties["title"].Value == null ? "N/A" : de.Properties["title"].Value.ToString();
                            string email = de.Properties["mail"].Value == null ? "N/A" : de.Properties["mail"].Value.ToString();

                            retList.Add(new Person(fName, lName, "", "", telephone, title, email));
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + ex.StackTrace);
            }

            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(retList);
            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public string getDeskInfo(string fName, string lName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WirtzMap"].ConnectionString;
            string query = "Select * FROM Person WHERE fName = @FNAME AND lName = @LNAME";
            string retDesk = "";
            string retDesc = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FNAME", fName);
                command.Parameters.AddWithValue("@LNAME", lName);
                try
                {

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        retDesk = reader["deskNo"].ToString();
                        retDesc = reader["description"].ToString();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {

                }
            }
            var info = new { deskNumber = retDesk, desc = retDesc };
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(info);

        }

        [HttpGet]
        public string checkIfDeskAssigned(string deskNo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WirtzMap"].ConnectionString;
            string query = "SELECT * FROM Person WHERE deskNo = @DESKNO";
            string retVal = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DESKNO", deskNo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["lName"].ToString() == "OPEN")
                            retVal = "OPEN";
                        else
                            retVal = reader["fName"].ToString() + " " + reader["lName"].ToString();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {

                }
            }
            return retVal;
        }

        [HttpPut]
        public string updateDeskNumber(string fname, string lname, string deskNo, string internalPhone, string description)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WirtzMap"].ConnectionString;
            string query = "UPDATE Person SET fName = @FNAME, lName = @LNAME, internalPhone = @PHONE, phoneNo = '', description = @DESCR WHERE deskNo = @DESKNO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FNAME", fname);
                command.Parameters.AddWithValue("@LNAME", lname);
                command.Parameters.AddWithValue("@DESKNO", deskNo);
                command.Parameters.AddWithValue("@PHONE", internalPhone);
                command.Parameters.AddWithValue("@DESCR", description);
                try
                {

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                }
            }

            return fname + " " + lname + " has been added at desk " + deskNo;
        }

        [HttpDelete]
        public string removeFromMap(string fname, string lname, string deskNo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WirtzMap"].ConnectionString;
            string query = "UPDATE Person SET fName = '', lName = 'OPEN', phoneNo = '', internalPhone = '', description = ''  WHERE fName = @FNAME AND lName = @LNAME AND deskNo = @DESKNO";
            int rows = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FNAME", fname);
                command.Parameters.AddWithValue("@LNAME", lname);
                command.Parameters.AddWithValue("@DESKNO", deskNo);
                try
                {
                    connection.Open();
                    rows = command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                }
            }
            if (rows == 1)
                return fname + " " + lname + " has been removed";
            return "Employee was not found";
        }

        [HttpDelete]
        public string clearDesk(string deskNo)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["WirtzMap"].ConnectionString;
            string query = "UPDATE Person SET fName = '', lName = 'OPEN', phoneNo = '', internalPhone = '', description = ''  WHERE deskNo = @DESKNO";
            int rows = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DESKNO", deskNo);
                try
                {
                    connection.Open();
                    rows = command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                }
            }
            if (rows == 1)
                return deskNo + " has been cleared.";
            return "Desk was not found.";
        }
    }
}

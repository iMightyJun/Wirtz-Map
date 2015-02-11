using FreeTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using System.DirectoryServices;
using System.Diagnostics;

namespace FreeTime.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //string pathToData = "C:\\Users\\JCheng\\Documents\\Visual Studio 2012\\Projects\\FreeTime\\FreeTime\\Content\\MapData\\mapData.json";
         List<Person> mapData;
         Graph mainGraph = new Graph();
        public ActionResult Index()
        {
            getMapData();
            System.Diagnostics.Debug.WriteLine("finished");
            return View();
        }

        
         
        [HttpGet]
        public void getMapData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WirtzMap"].ConnectionString;
            string query = "SELECT * FROM Person";
            mapData = new List<Person>();
            string fName, lName, deskNo, phoneNo, internalPhone, description;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        fName = reader["fName"].ToString();
                        lName = reader["lName"].ToString();
                        deskNo = reader["deskNo"].ToString();
                        phoneNo = reader["phoneNo"].ToString();
                        internalPhone = reader["internalPhone"].ToString();
                        description = reader["description"].ToString();
                        mapData.Add(new Person(fName, lName, deskNo, phoneNo, internalPhone, description));

                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                }
            }


           

            mapData = mapData.OrderBy(x => x.deskNo).ToList();


            mainGraph.makeNodes();
            mainGraph.addData(mapData);
        }

        [HttpPost]
        public string insertPerson(string fname, string lname, string deskNo, string phoneNo, string internalPhone, string description)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WirtzMap"].ConnectionString;
            string queryString = "INSERT INTO Person(fName, lName, deskNo, internalPhone, description) values(@ifName, @ilName, @ideskNo, @iinternalPhone, @idescription)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ifName", fname);
                command.Parameters.AddWithValue("@ilName", lname);
                command.Parameters.AddWithValue("@ideskNo", deskNo);
                command.Parameters.AddWithValue("@iinternalPhone", internalPhone);
                command.Parameters.AddWithValue("@idescription", description);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception ex)
                {

                }
            }
            return "Insert done";
        }

        [HttpDelete]
        public string deletePerson(string deskNo)
        {
            string query = "DELETE FROM Person WHERE deskNo = @ideskNo";
            string connectionString = ConfigurationManager.ConnectionStrings["WirtzMap"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ideskNo", deskNo);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception ex)
                {

                }
            }
            return "Done";
            
        }



        [HttpGet]
        public string getMapJSON()
        {
            getMapData();
            mainGraph.nodes.Reverse();
            Graph jsonready = mainGraph.readyForJSON();
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(jsonready);
            return json;
        }



        [HttpGet]
        public string getPath(string start, string end, string floor)
        {
            getMapData();
            System.Diagnostics.Debug.WriteLine("Start is " + start);
            System.Diagnostics.Debug.WriteLine("End is " + end);
            string path = mainGraph.FSP(start, end);
            return path;
        }


        
    }
}

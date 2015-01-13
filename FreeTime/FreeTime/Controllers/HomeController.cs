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
        string pathToData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\mapData.json";
        List<Person> mapData;
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Person>));
        Graph mainGraph = new Graph();
        public ActionResult Index()
        {
            getMapData(false);
            System.Diagnostics.Debug.WriteLine("finished");
            return View();
        }

        
         
        [HttpGet]
        public void getMapData(bool search)
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
            //if (!search)
            //    convertToJson(mainGraph);
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

        public void convertToJson(Graph data)
        {
            Graph jsonready = data.readyForJSON();
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(jsonready);
            writeJsonToFile(json); 
        }

        public void convertFromJson() {
            StreamReader sr = new StreamReader(pathToData);
            string json = sr.ReadToEnd();

            mainGraph = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Graph>(json);
        
        }

        private void releaseObject(Object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        [HttpGet]
        public string getJson()
        {
            //StreamReader sr = new StreamReader(pathToData);
            //StringBuilder sb = new StringBuilder();
            //sb.Append(sr.ReadToEnd());
            //return sb.ToString();
            getMapData(false);
            mainGraph.nodes.Reverse();
            Graph jsonready = mainGraph.readyForJSON();
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(jsonready);
            return json;
        }

        public void writeJsonToFile(string json)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(json);
            using (StreamWriter outfile = new StreamWriter(pathToData))
            {
                outfile.Write(sb.ToString());
            }
        }

        [HttpGet]
        public string getPath(string start, string end, string floor)
        {
            getMapData(true);
            System.Diagnostics.Debug.WriteLine("Start is " + start);
            System.Diagnostics.Debug.WriteLine("End is " + end);
            string path = mainGraph.FSP(start, end);
            return path;
        }

        [HttpPost]
        public string shortestPaths(string start, string end, string floor)
        {
            System.Diagnostics.Debug.WriteLine(start);
            System.Diagnostics.Debug.WriteLine(end);
            System.Diagnostics.Debug.WriteLine(floor);

            Graph map = new Graph();
            map.buildGraph();
            string path = map.FSP(start, end);

            return path;
        }

        
    }
}

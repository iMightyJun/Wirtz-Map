using FreeTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.IO;
using Newtonsoft.Json;

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
            //System.Diagnostics.Debug.WriteLine(pathToData);
            //if (!System.IO.File.Exists(pathToData))
            //{
            //    System.Diagnostics.Debug.WriteLine("Getting excel");
            //    getExcel();
            //}
            //else
            //{
            //    System.Diagnostics.Debug.WriteLine("Converting json");
            //    convertFromJson();
            //}

            getExcel(false);
            System.Diagnostics.Debug.WriteLine("finished");
            return View();
        }

        public ActionResult Browse()
        {
            return View();
        }
        /*
        public string testAjax()
        {
            return "Hey What is Up Dawg";
        }

        public int testParam(string data, int data2)
        {
            return data2;
        }

         */
        [HttpGet]
        public void getExcel(bool search)
        {
            //C:\Users\JCheng\Documents\GitHub\Wirtz-Map\FreeTime\FreeTime\Scripts\custom\WBI Center - Seating Assignments - Updated AUG 2014.xlsx
            string url = "C:\\Users\\JCheng\\Documents\\GitHub\\Wirtz-Map\\FreeTime\\FreeTime\\Scripts\\custom\\WBI Center - Seating Assignments - Updated AUG 2014.xlsx";
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@url);
            Excel._Worksheet xlWorksheet = xlWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
             /*
                col 1 = location number
                col 2 = descriptoin
                col 3 = Last name
                col 4 = first name
                col 5 = external phone 
                col 6 = internal phone
                col 7 = access card
                col 8 = lock plug
                excel is not 0 based
              * */

            mapData = new List<Person>();


            for (int i = 2; i <= rowCount; i++)
            {

                string deskNo = (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null) ? xlRange.Cells[i, 1].Value2.ToString() as string : "";
                string lName = (xlRange.Cells[i, 3] != null && xlRange.Cells[i, 3].Value2 != null) ? xlRange.Cells[i, 3].Value2.ToString() as string : "";
                string fName = (xlRange.Cells[i, 4] != null && xlRange.Cells[i, 4].Value2 != null) ? xlRange.Cells[i, 4].Value2.ToString() as string : xlRange.Cells[i, 2].Value2.ToString();
                string phoneNo = (xlRange.Cells[i, 7] != null && xlRange.Cells[i, 7].Value2 != null) ? xlRange.Cells[i, 7].Value2.ToString() as string : "";
                string internalPhone = (xlRange.Cells[i, 8] != null && xlRange.Cells[i, 8].Value2 != null) ? xlRange.Cells[i, 8].Value2.ToString() as string : "";
                string des = (xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null) ? xlRange.Cells[i, 2].Value2.ToString() as string : "";
                
                mapData.Add(new Person(fName, lName, deskNo, phoneNo, internalPhone, des));

            }

            mapData = mapData.OrderBy(x => x.deskNo).ToList();


            mainGraph.makeNodes();
            mainGraph.addData(mapData);
            if(!search)
                convertToJson(mainGraph);

            //release objects and collect garbage
            releaseObject(xlRange);
            releaseObject(xlWorksheet);
            
            xlWorkBook.Close();
            releaseObject(xlWorkBook);

            xlApp.Quit();
            releaseObject(xlApp);


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
            StreamReader sr = new StreamReader(pathToData);
            StringBuilder sb = new StringBuilder();
            sb.Append(sr.ReadToEnd());
            return sb.ToString();
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
            getExcel(true);
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

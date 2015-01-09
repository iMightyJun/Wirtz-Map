using FreeTime.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace FreeTime.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult testLDAP()
        {
            string path = "LDAP://WBGAD.WIRTZBEV.COM/OU=WBGIL,DC=wbgad,DC=wirtzbev,DC=com";
            string retStr = "";
            List<Person> retList = new List<Person>();
            DirectoryEntry rootEntry = new DirectoryEntry(path);
            DirectorySearcher mySearcher = new DirectorySearcher(rootEntry);
            mySearcher.Filter = ("(&(objectCategory=Person)(objectClass=user))");
            mySearcher.PageSize = 250;
            foreach (SearchResult res in mySearcher.FindAll())
            {
                DirectoryEntry de = res.GetDirectoryEntry();

                if (de.Properties["sAMAccountName"].Value != null && de.Properties["givenName"].Value != null && de.Properties["sn"].Value != null && de.Properties["telephoneNumber"].Value != null && de.Properties["title"].Value != null)
                {
                    //Debug.WriteLine("First Name " + de.Properties["givenName"].Value.ToString());
                    //Debug.WriteLine("Last Name " + de.Properties["sn"].Value.ToString());
                    //Debug.WriteLine("Telephone " + de.Properties["telephoneNumber"].Value.ToString());
                    //Debug.WriteLine("Title " + de.Properties["title"].Value.ToString());

                    retList.Add(new Person(de.Properties["givenName"].Value.ToString(), de.Properties["sn"].Value.ToString(), "", "", de.Properties["telephoneNumber"].Value.ToString(), de.Properties["title"].Value.ToString()));
                }
            }
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(retList);
            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult findPerson(string searchTerm)
        {
            string path = "LDAP://WBGAD.WIRTZBEV.COM/OU=WBGIL,DC=wbgad,DC=wirtzbev,DC=com";
            DirectoryEntry rootEntry = new DirectoryEntry(path);
            DirectorySearcher search = new DirectorySearcher(rootEntry);
            search.Filter = ("(&(objectCategory=Person)(objectClass=user)(displayName=*"+ searchTerm +"*))");
            search.PageSize = 250;
            List<Person> retList = new List<Person>();
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
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(retList);
            return Json(retList, JsonRequestBehavior.AllowGet);


        }

    }
}

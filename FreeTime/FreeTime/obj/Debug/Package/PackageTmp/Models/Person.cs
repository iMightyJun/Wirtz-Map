using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeTime.Models
{
    public class Person
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string deskNo { get; set; }
        public string phoneNo { get; set; }
        public string internalPhone { get; set; }
        public string description { get; set; }
        public string email { get; set; }

        public Person()
        {
            this.fName = "";
            this.lName = "";
            this.deskNo = "";
            this.phoneNo = "";
            this.internalPhone = "";
        }

        public Person(string f, string l, string d, string p, string i, string des, string mail = "N/A")
        {
            this.fName = f;
            this.lName = l;
            this.deskNo = d;
            this.phoneNo = p;
            this.internalPhone = i;
            this.description = des;
            this.email = mail;
        }


    }
}
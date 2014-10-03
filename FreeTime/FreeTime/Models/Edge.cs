using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeTime.Models
{
    public class Edge
    {
        public Vertex neighbor { get; set; }
        public int weight { get; set; }

        public Edge()
        {

        }

        public Edge(ref Vertex n, int w)
        {
            neighbor = n;
            weight = w;
        }
    }
}
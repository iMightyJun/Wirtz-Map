using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeTime.Models
{
    public class Vertex
    {
        public int distance { get; set; }
        public string name { get; set; }
        public bool visited { get; set; }
        public Vertex previous { get; set; }
        public List<Edge> neighbors { get; set; }
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public int mWidth { get; set; }
        public int mHeight { get; set; }
        public int midX { get; set; }
        public int midY { get; set; }
        public Person info { get; set; }
        public string ListOfNeighbors { get; set; }

        public Vertex()
        {

        }

        public Vertex(int d, string n, int x, int y)
        {
            this.distance = d;
            this.name = n;
            this.visited = false;
            this.previous = null;
            this.neighbors = new List<Edge>();
            this.xCoord = x;
            this.yCoord = y;
        }

        public Vertex(int d, string n, int x, int y, int w, int h)
        {
            this.distance = d;
            this.name = n;
            this.visited = false;
            this.previous = null;
            this.neighbors = new List<Edge>();
            this.xCoord = x;
            this.yCoord = y;
            this.mWidth = w;
            this.mHeight = h;
            this.midX = this.mWidth / 2 + this.xCoord;
            this.midY = this.mHeight / 2 + this.yCoord;
        }

        public Vertex(int d, string n, int x, int y, int w, int h, int midx, int midy)
        {
            this.distance = d;
            this.name = n;
            this.visited = false;
            this.previous = null;
            this.neighbors = new List<Edge>();
            this.xCoord = x;
            this.yCoord = y;
            this.mWidth = w;
            this.mHeight = h;
            this.midX = midx;
            this.midY = midy;
        }

        public Vertex(int d, string n, List<Edge> neigh)
        {
            this.distance = d;
            this.name = n;
            this.neighbors = neigh;
        }

        public static Vertex makeAdjacent(ref Vertex v, string n, int floor, string dir, int distance, int weight = 1, bool isStairs = false)
        {
            Vertex newV = null;
            if (floor == 1)
                n = "1travel" + n;
            else
                n = "2travel" + n;
            switch (dir)
            {
                case "up":
                    newV = new Vertex(v.distance, n , v.xCoord, v.yCoord - distance, v.mWidth, v.mHeight);
                    break;
                case "down":
                    newV = new Vertex(v.distance, n, v.xCoord, v.yCoord + distance, v.mWidth, v.mHeight);
                    break;
                case "left":
                    newV = new Vertex(v.distance, n, v.xCoord - distance, v.yCoord, v.mWidth, v.mHeight);
                    break;
                case "right":
                    newV = new Vertex(v.distance, n, v.xCoord + distance, v.yCoord, v.mWidth, v.mHeight);
                    break;

            }
            weight = getWeight(newV, v);

            if (isStairs)
                weight = 10000;
            connectVertex(ref newV, ref v, weight);

            return newV;
            
        }

        public static Vertex makeConnect(ref Vertex v, string n, int floor, int x, int y, int weight = 1, bool isStairs = false)
        {
            Vertex newV = null;
            if (floor == 1)
                n = "1travel" + n;
            else
                n = "2travel" + n;
            newV = new Vertex(v.distance, n, 1 , 1 , 1, 1, x, y);

            weight = getWeight(v, newV);
            if (isStairs)
                weight = 10000;
            connectVertex(ref newV, ref v, weight);

            return newV;
        }


        public static void connectVertex(ref Vertex a, ref Vertex b, int weight = 1, bool isStairs = false) {
            weight = getWeight(a, b);

            if (isStairs)
                weight = 10000;

            Edge to = new Edge(ref a, weight);
            b.addNeighbors(ref to);
            Edge from = new Edge(ref b, weight);
            a.addNeighbors(ref from);
        }

        public void addNeighbors(ref Edge edge)
        {
            foreach (Edge e in this.neighbors)
            {
                if (e.neighbor.name == edge.neighbor.name)
                    return;
            }
            this.neighbors.Add(edge);
        }

        public static int getWeight(Vertex a, Vertex b)
        {
            int diffX = (int)Math.Pow(a.midX - b.midX, 2);
            int diffY = (int)Math.Pow(a.midY - b.midY, 2);
            int distance = (int)Math.Sqrt(diffX + diffY);

            return distance;



        }

    }
}
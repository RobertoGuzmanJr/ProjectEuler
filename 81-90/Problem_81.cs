using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PE81
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();

            //read in the file
            var fileContents = System.IO.File.ReadAllLines(@"C:\Users\RobertoGuzmanJr\Desktop\matrix.txt");
            var matrix = new int[80,80];
            for(var i = 0; i < 80; i++)
            {
                var r = fileContents[i].Split(',');
                for(var j = 0; j < r.Length; j++)
                {
                    matrix[i,j] = Convert.ToInt32(r[j]);
                }
            }

            var nodeArray = new Node[6400];
            var currentIndex = 0;
            for (var row = 0; row < 80; row++)
            {
                for(var col = 0; col < 80; col++)
                {
                    var node = new Node(matrix[row, col]);
                    nodeArray[currentIndex] = node;
                    currentIndex++;
                }
            }

            for (var i = 0; i < nodeArray.Length; i++)
            {
                //has a bottom way to go
                if(i < 6320)    
                {
                    nodeArray[i].AdjacentNodes.Add(nodeArray[i + 80]);
                }
                //has a right way to go
                if(i % 79 != 0 || i == 0)
                {
                    nodeArray[i].AdjacentNodes.Add(nodeArray[i + 1]);
                }
                g.Nodes.Add(nodeArray[i]);
            }

            var results = g.DijkstrasAlgorithm(g.Nodes[0]);
            var s = "";
            foreach (var pair in results)
            {
                s += pair.Key.value + ":" + pair.Value + ";";
                //s += pair.Value + ";";
            }
            
            //Console.WriteLine("This is the start!");
            Console.WriteLine(s);
            Console.WriteLine(g.Nodes[0].value);

                //create the nodes
                //var n11 = new Node(131);
                //var n12 = new Node(673);
                //var n13 = new Node(234);
                //var n14 = new Node(103);
                //var n15 = new Node(18);
                //var n21 = new Node(201);
                //var n22 = new Node(96);
                //var n23 = new Node(342);
                //var n24 = new Node(965);
                //var n25 = new Node(150);
                //var n31 = new Node(630);
                //var n32 = new Node(803);
                //var n33 = new Node(746);
                //var n34 = new Node(422);
                //var n35 = new Node(111);
                //var n41 = new Node(537);
                //var n42 = new Node(699);
                //var n43 = new Node(497);
                //var n44 = new Node(121);
                //var n45 = new Node(956);
                //var n51 = new Node(805);
                //var n52 = new Node(732);
                //var n53 = new Node(524);
                //var n54 = new Node(37);
                //var n55 = new Node(331);

                //create the adjacency nodes
                //n11.AdjacentNodes.Add(n12);
                //n11.AdjacentNodes.Add(n21);
                //n12.AdjacentNodes.Add(n13);
                //n12.AdjacentNodes.Add(n22);
                //n13.AdjacentNodes.Add(n14);
                //n13.AdjacentNodes.Add(n23);
                //n14.AdjacentNodes.Add(n15);
                //n14.AdjacentNodes.Add(n24);
                //n15.AdjacentNodes.Add(n25);

                //n21.AdjacentNodes.Add(n22);
                //n21.AdjacentNodes.Add(n31);
                //n22.AdjacentNodes.Add(n23);
                //n22.AdjacentNodes.Add(n32);
                //n23.AdjacentNodes.Add(n24);
                //n23.AdjacentNodes.Add(n33);
                //n24.AdjacentNodes.Add(n25);
                //n24.AdjacentNodes.Add(n34);
                //n25.AdjacentNodes.Add(n35);

                //n31.AdjacentNodes.Add(n32);
                //n31.AdjacentNodes.Add(n41);
                //n32.AdjacentNodes.Add(n33);
                //n32.AdjacentNodes.Add(n42);
                //n33.AdjacentNodes.Add(n34);
                //n33.AdjacentNodes.Add(n43);
                //n34.AdjacentNodes.Add(n35);
                //n34.AdjacentNodes.Add(n44);
                //n35.AdjacentNodes.Add(n45);

                //n41.AdjacentNodes.Add(n42);
                //n41.AdjacentNodes.Add(n11);
                //n42.AdjacentNodes.Add(n43);
                //n42.AdjacentNodes.Add(n52);
                //n43.AdjacentNodes.Add(n44);
                //n43.AdjacentNodes.Add(n53);
                //n44.AdjacentNodes.Add(n45);
                //n44.AdjacentNodes.Add(n54);
                //n45.AdjacentNodes.Add(n55);

                //n51.AdjacentNodes.Add(n52);
                //n52.AdjacentNodes.Add(n53);
                //n53.AdjacentNodes.Add(n54);
                //n54.AdjacentNodes.Add(n55);

                //g.Nodes.Add(n11);
                //g.Nodes.Add(n12);
                //g.Nodes.Add(n13);
                //g.Nodes.Add(n14);
                //g.Nodes.Add(n15);
                //g.Nodes.Add(n21);
                //g.Nodes.Add(n22);
                //g.Nodes.Add(n23);
                //g.Nodes.Add(n24);
                //g.Nodes.Add(n25);
                //g.Nodes.Add(n31);
                //g.Nodes.Add(n32);
                //g.Nodes.Add(n33);
                //g.Nodes.Add(n34);
                //g.Nodes.Add(n35);
                //g.Nodes.Add(n41);
                //g.Nodes.Add(n42);
                //g.Nodes.Add(n43);
                //g.Nodes.Add(n44);
                //g.Nodes.Add(n45);
                //g.Nodes.Add(n51);
                //g.Nodes.Add(n52);
                //g.Nodes.Add(n53);
                //g.Nodes.Add(n54);
                //g.Nodes.Add(n55);

                //var results = g.DijkstrasAlgorithm(n11);
                //var s = "";
                //foreach(var pair in results)
                //{
                //    s += pair.Key.value + ":" + pair.Value + ";";
                //    //Console.WriteLine("{0} --> {1}", pair.Key.value, pair.Value);
                //}
                //Console.WriteLine(s);

                //Console.WriteLine("Done");
            Console.ReadLine();
        }
    }

    class Node
    {
        public int value;
        public List<Node> AdjacentNodes;
        public Node(int i)
        {
            value = i;
            AdjacentNodes = new List<Node>();
        }
        public void PrintValue()
        {
            Console.WriteLine(value);
        }

        public void PrintAdjacencyList()
        {
            foreach(var i in AdjacentNodes)
            {
                i.PrintValue();
            }
        }
    }

    class Graph
    {
        public List<Node> Nodes;
        
        public Graph()
        {
            Nodes = new List<Node>();
        }

        public int NumNodes()
        {
            return Nodes.Count();
        }

        public Node FindMinDistance(List<Node> unvisitedNodes,Dictionary<Node,int> distances)
        {
            var minDistance = Int32.MaxValue;
            Node minDistanceNode = null;
            foreach(var node in unvisitedNodes)
            {
                if(distances[node] <= minDistance)
                {
                    minDistance = distances[node];
                    minDistanceNode = node;
                }
            }
            return minDistanceNode;
        }

        public Dictionary<Node,int> DijkstrasAlgorithm(Node startingNode)
        {
            var unvisitedNodes = new List<Node>();
            var visitedNodes = new List<Node>();
            var distances = new Dictionary<Node,int>();
            var predecessors = new Dictionary<Node, Node>();
            var alt = 0;

            foreach(var node in Nodes)
            {
                predecessors.Add(node, null);   //initialize the predecessors
                unvisitedNodes.Add(node);       //initialize the unvisited nodes

                //initialize the distances
                if(node == startingNode)
                {
                    distances.Add(node, 0);
                }
                else
                {
                    distances.Add(node, Int32.MaxValue);
                }
            }

            while(unvisitedNodes.Count > 0)
            {
                Node u = FindMinDistance(unvisitedNodes,distances);
                unvisitedNodes.Remove(u);

                foreach(var neighbor in u.AdjacentNodes)
                {
                    if(!unvisitedNodes.Contains(neighbor))
                    {
                        continue;
                    }
                    alt = distances[neighbor] == Int32.MaxValue ? neighbor.value + distances[u] : distances[neighbor] + neighbor.value + distances[u];
                    if(alt < distances[neighbor])
                    {
                        distances[neighbor] = alt;
                        predecessors[u] = neighbor;
                    }
                }
            }
            return distances;
        }
    }
}

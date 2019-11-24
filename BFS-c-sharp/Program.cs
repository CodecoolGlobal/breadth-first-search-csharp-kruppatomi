using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS_c_sharp
{
    class Program
    {
        public static int allVertices;
        // public static Tuple<int, int>[] myEdges;
        public static List<Tuple<int, int>> myEdges = new List<Tuple<int, int>>();

        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            //here is my edge array
            foreach (var user in users)
            {
                Console.WriteLine(user);
                foreach (var friend in user.Friends)
                {

                    myEdges.Add(Tuple.Create(user.Id, friend.Id));
                }
            }
            allVertices = users.Count;

            Console.WriteLine("\n" + "Hit enter to see the distance between to people: ");
            Console.ReadLine();

            //THE SHORTEST DISTANCE------------------------------------------------------------------------------

            //my addition
            //my vertices
            var myVertices = Enumerable.Range(1, allVertices).ToArray();

            //my edges list is on the top and i add the info in the first for loop
            //here i convert this list to an array
            var Edges = myEdges.ToArray();

            var graph = new Graph<int>(myVertices, Edges);
            var algorithms = new Algorithms();

            var startVertex = 2;
            var shortestPath = algorithms.ShortestPathFunction(graph, startVertex);

            //write out the shortest distance between two people, start vertex - end vertex (one vertex means 1)
            var endVertex = 10;
            Console.WriteLine(shortestPath(myVertices[endVertex]).Count());

            //write out the "way to the porson"
            Console.WriteLine("shortest path to {0}: {1}",
                    myVertices[endVertex], string.Join(", ", shortestPath(myVertices[endVertex])));

            Console.ReadLine();

            //THE FRIENDS NEARBY---------------------------------------------------------------------------------
            var distance = 3;

            foreach (var vertex in myVertices)
            {
                if (shortestPath(vertex).Count() == distance)
                {
                    Console.WriteLine("path in DISTANCE 3 {0,2}: {1}",
                                vertex, string.Join(", ", shortestPath(vertex)));
                }
                Console.WriteLine("all shortest path to {0,2}: {1}",
                        vertex, string.Join(", ", shortestPath(vertex)));
            }
            Console.ReadLine();

            //FRIEND CHAIN---------------------------------------------------------------------------------------
            if (shortestPath(myVertices[endVertex]).Count() == distance)
            {
                Console.WriteLine("{0} {1}'s Friends in Distance 3: " + "\n",
                    users[myVertices[endVertex]].FirstName, users[myVertices[endVertex]].LastName);

                foreach (var ver in shortestPath(myVertices[endVertex]))
                {
                    Console.WriteLine("{0} {1}", users[ver].FirstName, users[ver].LastName);
                }
            }
        }
    }
}


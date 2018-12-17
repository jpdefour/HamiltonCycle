using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonPath
{
    public static class HamiltonCycle
    {
        static readonly Random random = new Random();
        public static bool IsThereAHamiltonPath(Graph graph, Vertex start, Vertex end, Graph path)
        {
            Vertex point = start;
            while(!path.HasAllVertices(12))
            {
                if (path.ContainsAllButFinalVertex(12, end))
                {
                    path.Reconnect(point, end);
                    path.Reconnect(start, end);
                    Console.WriteLine("Finished!");
                    Console.WriteLine(path.ToString());
                    return true;
                }
                if (!graph.VertexHasConnections(point)) return false;
                graph.connections.TryGetValue(point, out List<Vertex> vertexConnections);
                var randomSelection = random.Next(0, vertexConnections.Count);

                var chosenVertex = vertexConnections[randomSelection];
                graph.RemoveConnection(point, chosenVertex);

                if (!graph.VertexHasConnections(chosenVertex)) return false;

                if (!chosenVertex.isFinalVertex && !path.Contains(chosenVertex))
                {
                    path.Reconnect(point, chosenVertex);
                    point = chosenVertex;
                }
                else if (!chosenVertex.isFinalVertex && path.Contains(chosenVertex))
                {
                    Vertex neighbor = path.Neighbor(chosenVertex, point);
                    path.RemoveConnection(neighbor, chosenVertex);
                    path.Reconnect(point, chosenVertex);
                    point = neighbor;

                }

            }
            Console.WriteLine("Something weird happened.");
            return false;
        }
    }
}

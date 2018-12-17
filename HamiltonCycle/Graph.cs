using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonPath
{
    public class Graph
    {
        public Dictionary<Vertex, List<Vertex>> connections;

        public Graph()
        {
            connections = new Dictionary<Vertex, List<Vertex>>();
        }

        internal bool HasAllVertices(int count)
        {
            return connections.Count == count;
        }

        public void Connect(Vertex x, Vertex y)
        {
            if (connections.TryGetValue(x, out List<Vertex> vertexConnections))
            {
                vertexConnections.Add(y);
            }
            else
            {
                vertexConnections = new List<Vertex> { y };
                connections.Add(x, vertexConnections);
            }
        }

        internal bool ContainsAllButFinalVertex(int verticesCount, Vertex finalVertex)
        {
            if (connections.Count == verticesCount - 1
                && !connections.ContainsKey(finalVertex)) return true;
            return false;
        }

        public void RemoveConnection(Vertex point, Vertex chosenVertex)
        {
            connections.TryGetValue(point, out List<Vertex> firstVertexConnections);
            connections[point].Remove(chosenVertex);

            connections.TryGetValue(chosenVertex, out List<Vertex> secondVertexConnections);
            connections[chosenVertex].Remove(point);
        }

        public void Reconnect(Vertex point, Vertex chosenVertex)
        {
            AddReconnection(connections, point, chosenVertex);
            AddReconnection(connections, chosenVertex, point);
        }

        private void AddReconnection(Dictionary<Vertex, List<Vertex>> connections, Vertex firstPoint, Vertex secondPoint)
        {
            connections.TryGetValue(firstPoint, out List<Vertex> firstVertexConnections);
            if (firstVertexConnections == null) firstVertexConnections = new List<Vertex>();
            firstVertexConnections.Add(secondPoint);
            if (!connections.ContainsKey(firstPoint)) connections.Add(firstPoint, firstVertexConnections);
            else connections[firstPoint] = firstVertexConnections;
        }

        public void Connect(Vertex x, List<Vertex> vertices)
        {
            foreach(var y in vertices)
            {
                Connect(x, y);
            }
        }

        public bool VertexHasConnections(Vertex x)
        {
            connections.TryGetValue(x, out List<Vertex> vertexConnections);
            if (vertexConnections.Count > 0) return true;
            else return false;
        }

        internal Vertex Neighbor(Vertex chosenVertex, Vertex point)
        {
            var possibleNeighbors = connections[chosenVertex];
            return FindWhichIsCloserToVertex(point, possibleNeighbors);
            //TODO: come back to this. Not truly finding a neighbor.

        }

        private Vertex FindWhichIsCloserToVertex(Vertex point, List<Vertex> possibleNeighbors)
        {
            Random random = new Random();
            return possibleNeighbors[random.Next(possibleNeighbors.Count)];
        }

        public bool Contains(Vertex vertex)
        {
            return connections.ContainsKey(vertex);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var connection in connections)
            {
                stringBuilder.AppendLine("Vertex " + connection.Key.Number + " has the following connections:");
                foreach (var vertex in connection.Value)
                {
                    stringBuilder.AppendLine("Vertex " + vertex.Number);
                }
            }
            return stringBuilder.ToString();
        }

    }
}

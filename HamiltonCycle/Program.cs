using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            int numberOfVertices = 12;
            Vertex[] vertices = new Vertex[numberOfVertices];
            for(int i = 0; i < numberOfVertices; i++)
            {
                vertices[i] = new Vertex();
                vertices[i].Number = i + 1;
            }
            graph.Connect(vertices[0], new List<Vertex> {
                vertices[1], vertices[2], vertices[3], vertices[4], vertices[8]});
            graph.Connect(vertices[1], new List<Vertex> {
                vertices[0], vertices[2], vertices[6], vertices[7], vertices[8]});
            graph.Connect(vertices[2], new List<Vertex> {
                vertices[0], vertices[1], vertices[4], vertices[5], vertices[6]});
            graph.Connect(vertices[3], new List<Vertex> {
                vertices[0], vertices[4], vertices[8], vertices[9], vertices[11]});
            graph.Connect(vertices[4], new List<Vertex> {
                vertices[0], vertices[2], vertices[3], vertices[5], vertices[11]});
            graph.Connect(vertices[5], new List<Vertex> {
                vertices[2], vertices[4], vertices[6], vertices[10], vertices[11]});
            graph.Connect(vertices[6], new List<Vertex> {
                vertices[1], vertices[2], vertices[5], vertices[7], vertices[10]});
            graph.Connect(vertices[7], new List<Vertex> {
                vertices[1], vertices[6], vertices[8], vertices[9], vertices[10]});
            graph.Connect(vertices[8], new List<Vertex> {
                vertices[0], vertices[1], vertices[3], vertices[7], vertices[9]});
            graph.Connect(vertices[9], new List<Vertex> {
                vertices[3], vertices[7], vertices[8], vertices[10], vertices[11]});
            graph.Connect(vertices[10], new List<Vertex> {
                vertices[5], vertices[6], vertices[7], vertices[9], vertices[11]});
            graph.Connect(vertices[11], new List<Vertex> {
                vertices[3], vertices[4], vertices[5], vertices[9], vertices[10]});

            vertices[0].IsStartingVertex = true;
            vertices[1].isFinalVertex = true;

            var path = HamiltonCycle.IsThereAHamiltonPath(graph, vertices[0], vertices[1], new Graph());

            Console.WriteLine("Did we find a hamilton path?: " + path);
            Console.ReadLine();
        }
    }
}

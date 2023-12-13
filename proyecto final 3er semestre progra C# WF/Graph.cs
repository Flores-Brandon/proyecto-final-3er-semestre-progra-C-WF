using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class Graph
    {
        public List<Vertex> Vertices { get; } = new List<Vertex>();
        public List<Edge> Edges { get; } = new List<Edge>();

        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public void DrawGraph(Graphics g)
        {
            g.Clear(Color.White);

            // Dibujar vértices
            foreach (var vertex in Vertices)
            {
                g.FillEllipse(Brushes.Blue, vertex.Location.X, vertex.Location.Y, 30, 30);
                g.DrawString(vertex.Label, new Font("Arial", 8), Brushes.Black, vertex.Location.X, vertex.Location.Y);
            }

            // Dibujar bordes
            foreach (var edge in Edges)
            {
                Point origin = edge.Origin.Location;
                Point destination = edge.Destination.Location;
                g.DrawLine(Pens.Red, origin.X + 15, origin.Y + 15, destination.X + 15, destination.Y + 15);
            }
        }
    }
}

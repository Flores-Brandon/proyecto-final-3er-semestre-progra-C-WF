using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class Edge
    {
        public Vertex Origin { get; }
        public Vertex Destination { get; }

        public Edge(Vertex origin, Vertex destination)
        {
            Origin = origin;
            Destination = destination;
        }
    }
}

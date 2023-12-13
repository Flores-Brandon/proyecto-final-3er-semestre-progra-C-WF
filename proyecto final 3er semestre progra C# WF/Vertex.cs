using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class Vertex
    {
        public string Label { get; set; }
        public Point Location { get; set; }

        public Vertex(string label, Point location)
        {
            Label = label;
            Location = location;
        }
    }
}

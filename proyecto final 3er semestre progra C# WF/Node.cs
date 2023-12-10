using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class Node
    {
        public Node Next{ get; set; }
        public int Data { get; set; }

        public Node(int d) 
        {
            Data = d;
            Next = null;
        }
    }
}

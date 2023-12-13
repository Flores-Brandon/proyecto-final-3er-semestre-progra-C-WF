using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class TreeNode
    {
        public string Name { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(string name)
        {
            Name = name;
            Children = new List<TreeNode>();
        }
    }
}

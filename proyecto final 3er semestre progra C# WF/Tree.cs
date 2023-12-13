using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    public class Tree
    {
        private TreeNode rootNode;

        public void AddNode(string parentNodeName, string newNodeName, TextBox textBox)
        {
            if (rootNode == null)
            {
                rootNode = new TreeNode(parentNodeName);
            }

            TreeNode parentNode = FindNode(rootNode, parentNodeName);

            if (parentNode != null)
            {
                TreeNode newNode = new TreeNode(newNodeName);
                parentNode.Children.Add(newNode);

                // No limpiar todo el contenido, solo actualizar el nuevo nodo
                UpdateTreeText(rootNode, textBox);

                textBox.AppendText(Environment.NewLine); // Agregar un salto de línea al final

                textBox.ScrollToCaret(); // Desplazar al final del cuadro de texto
            }
            else
            {
                MessageBox.Show("Nodo padre no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void DeleteNode(string nodeName, TextBox textBox)
        {
            var nodeToDelete = FindNode(rootNode, nodeName);
            if (nodeToDelete != null)
            {
                var parent = FindParentNode(rootNode, nodeName);

                if (nodeToDelete == rootNode)
                {
                    if (nodeToDelete.Children.Count > 0)
                    {
                        rootNode = nodeToDelete.Children[0];
                        textBox.Text = ($"El nodo raíz '{nodeName}' se eliminó, y el primer hijo se convirtió en el nuevo raíz.");
                    }
                    else
                    {
                        rootNode = null;
                        textBox.Text = ($"El nodo raíz '{nodeName}' se eliminó.");
                    }
                }
                else if (parent != null)
                {
                    if (nodeToDelete.Children.Count > 0)
                    {
                        var firstChild = nodeToDelete.Children[0];
                        firstChild.Children.AddRange(nodeToDelete.Children.Skip(1));
                        parent.Children.Insert(parent.Children.IndexOf(nodeToDelete), firstChild);
                    }
                    parent.Children.Remove(nodeToDelete);
                    textBox.Text = ($"El nodo '{nodeName}' se eliminó, y el primer hijo se convirtió en el nuevo padre sin cambiar la posición de la rama.");
                }
                await Task.Delay(2000);
                textBox.Text = string.Empty;
                UpdateTreeText(rootNode, textBox);
            }
            else
            {
                textBox.Text = ($"No se encontró el nodo '{nodeName}'.");
            }
        }

        private void UpdateTreeText(TreeNode rootNode, TextBox textBox)
        {
            if (rootNode == null)
            {
                textBox.Text = string.Empty;
                return;
            }

            var stack = new Stack<Tuple<TreeNode, string>>();
            stack.Push(new Tuple<TreeNode, string>(rootNode, ""));

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                var node = current.Item1;
                var indent = current.Item2;

                textBox.AppendText(indent + "└─ " + node.Name + Environment.NewLine);

                foreach (var childNode in node.Children)
                {
                    stack.Push(new Tuple<TreeNode, string>(childNode, indent + "    "));
                }
            }
        }

        private TreeNode FindNode(TreeNode parentNode, string nodeName)
        {
            if (parentNode.Name == nodeName)
            {
                return parentNode;
            }

            foreach (var childNode in parentNode.Children)
            {
                TreeNode foundNode = FindNode(childNode, nodeName);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null;
        }

        private TreeNode FindParentNode(TreeNode parentNode, string nodeName)
        {
            foreach (var childNode in parentNode.Children)
            {
                if (childNode.Name == nodeName)
                {
                    return parentNode;
                }

                TreeNode foundNode = FindParentNode(childNode, nodeName);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null;
        }
    }
}


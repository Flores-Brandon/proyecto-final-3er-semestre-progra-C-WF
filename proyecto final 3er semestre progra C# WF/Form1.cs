using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.Security;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Windows.Forms.VisualStyles;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    public partial class Form1 : Form
    {
        Random random;
        Auto auto;
        private MiPila<string> stringStack;
        private Queue<string> cola;
        private LinkedList<string> bicola;
        private SortedDictionary<int, Queue<string>> colaPrioridad;
        private Tree tree = new Tree();
        private Graph graph = new Graph();

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            auto = new Auto();
            stringStack = new MiPila<string>();
            cola = new Queue<string>();
            colaPrioridad = new SortedDictionary<int, Queue<string>>();
            bicola = new LinkedList<string>();

        }

        private int[] ArrayReset(int[] arr)
        {
            arr[0] = 9;
            arr[1] = 1;
            arr[2] = 8;
            arr[3] = 2;
            arr[4] = 7;
            return arr;
        }
        //Inicio Codigo Pila
        private void ActualizarStackListBox()
        {
            listBoxPila.Items.Clear();
            for (int i = stringStack.Count - 1; i >= 0; i--)
            {
                string item = stringStack[i];
                listBoxPila.Items.Add(item);
            }
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            string item = txtInput.Text;
            stringStack.Push(item);
            ActualizarStackListBox();
            txtInput.Clear();
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            try
            {
                string poppedItem = stringStack.Pop();
                MessageBox.Show("Elemento desapilado: " + poppedItem);
                ActualizarStackListBox();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("La pila está vacía. No se pueden desapilar elementos.");
            }
        }

        private void btnPeek_Click_1(object sender, EventArgs e)
        {
            try
            {
                string topItem = stringStack.Peek();
                MessageBox.Show("Elemento en la cima de la pila: " + topItem);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("La pila está vacía. No hay elementos para ver.");
            }
        }

        //Final Codigo Pila

        //Inicia Codigo Cola
        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            //Agregar Elementos a la Cola
            string elemento = txtCola.Text;
            cola.Enqueue(elemento);
            ActualizarListaCola();
        }

        private void ActualizarListaCola()
        { 
            listBoxCola.Items.Clear();
            foreach (string elemento in cola)
            {
                listBoxCola.Items.Add(elemento);
            }
        }
        private void btnDequeue_Click(object sender, EventArgs e)
        {
            //Verificar si la cola esta vacia
            if (cola.Count > 0)
            {
                //Eliminamos el elemento de la cola
                string ElementoEliminar = cola.Dequeue();
                MessageBox.Show($" Se Elimino el elemento: {ElementoEliminar}");
                ActualizarListaCola();
            }
            else
            {
                MessageBox.Show("La cola esta vacia. No se puede eliminar elementos");
            }
        }

        private void ActualizarListaColaDoble()
        {
            //Mostrar Cola Doble en la listBox
            listBoxColaDoble.Items.Clear();
            foreach (string elemento in bicola)
            {
                listBoxColaDoble.Items.Add((elemento));
            }
        }

        private void btnEnqueueInicio_Click(object sender, EventArgs e)
        {
            //Agregar el elemento al inico de la Cola Doble
            string elemento = txtColaDoble.Text;
            bicola.AddFirst(elemento);

            //Actualizamos ListBox
            ActualizarListaColaDoble();
        }

        private void btnDequeueInicio_Click(object sender, EventArgs e)
        {
            //Verificamos si la Cola Doble est vacia.
            if(bicola.Count > 0)
            {
                //Eliminamos elemento de inicio de la Cola Doble
                string ElementoEliminar = bicola.First.Value;
                bicola.RemoveFirst();
                MessageBox.Show($"Se elimino el primer elemento: {ElementoEliminar}");

                //Actuliza la lista de los elementos de la Cola Doble
                ActualizarListaColaDoble();
            }
            else
            {
                MessageBox.Show("La Cola Doble esta vacia. No se pueden eliminar elementos al inicio.");
            }
        }

        private void btnEnqueueFinal_Click(object sender, EventArgs e)
        {
            // Agregar un elemento al final de la bicola
            string elemento = txtColaDoble.Text;
            bicola.AddLast(elemento);

            // Actualizar la lista de elementos en la bicola
            ActualizarListaColaDoble();
        }

        private void btnDequeueFinal_Click(object sender, EventArgs e)
        {
            //Verificamos si la Cola Doble est vacia.
            if (bicola.Count > 0)
            {
                //Eliminamos elemento de inicio de la Cola Doble
                string ElementoEliminar = bicola.First.Value;
                bicola.RemoveLast();
                MessageBox.Show($"Se elimino el Ultimo elemento: {ElementoEliminar}");

                //Actuliza la lista de los elementos de la Cola Doble
                ActualizarListaColaDoble();
            }
            else
            {
                MessageBox.Show("La Cola Doble esta vacia. No se pueden eliminar elementos al final.");
            }
        }
        private void btnEnqueuePrioridad_Click(object sender, EventArgs e)
        {
            string  elemento = txtColaPrioridad.Text;
            int prioridad;

            if (int.TryParse(txtColaPrioridad.Text, out prioridad))
            {
                if(!colaPrioridad.ContainsKey(prioridad))
                {
                    colaPrioridad[prioridad] = new Queue<string>();
                }
                colaPrioridad[prioridad].Enqueue(elemento);
                //Actualizar la lista de elementos de Cola Prioridaad
                ActualizarListaColaPrioridad();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una prioridad válida (número entero).");
            }
        }
        private void ActualizarListaColaPrioridad()
        {
            //Mostrar la cola de prioridad en ListBox
            listBoxColaPrioridad.Items.Clear();
            foreach(var kvp in colaPrioridad)
            {
                foreach(var elemento in kvp.Value)
                {
                    listBoxColaPrioridad.Items.Add($"{elemento} - Prioridad: {kvp.Key}");
                }
            }
        }

        private void btnDequeuePrioridad_Click(object sender, EventArgs e)
        {
            // Verificamos si la cola de prioridad está vacía.
            if (colaPrioridad.Count > 0)
            {
                // Encontrar la cola con la prioridad más baja
                var primeraCola = colaPrioridad.Keys.Min();
                var elementoEliminado = colaPrioridad[primeraCola].Dequeue();

                // Si la cola está vacía, eliminarla de la cola de prioridad
                if (colaPrioridad[primeraCola].Count == 0)
                {
                    colaPrioridad.Remove(primeraCola);
                }

                // Mostrar un mensaje con el elemento eliminado
                MessageBox.Show($"Se eliminó el elemento: {elementoEliminado}");

                // Actualizar la lista de elementos en la cola de prioridad
                ActualizarListaColaPrioridad();
            }
            else
            {
                MessageBox.Show("La cola de prioridad está vacía. No se pueden eliminar elementos.");
            }
        }
        //Final Codigo Cola
        
        //Inicio Codigo Listas
        private async void btnListaSimple_Click(object sender, EventArgs e)
        {
            ListaSimple<int> Lista_Simple = new ListaSimple<int>();
            auto.Auto_Add_SimpleList(Lista_Simple, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Delete_SimpleList(Lista_Simple, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Search_SimpleList(Lista_Simple, random, textBox2, int.Parse(textBox1.Text));
        }

        private async void btnListaCircular_Click(object sender, EventArgs e)
        {
            ListaCircular<int> Circular_List = new ListaCircular<int>();

            auto.Auto_Add_CircularList(Circular_List, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Delete_CircularList(Circular_List, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Search_CircularList(Circular_List, random, textBox2, int.Parse(textBox1.Text));
        }

        private async void btnListaDobleEnlazada_Click(object sender, EventArgs e)
        {
            ListaDobleEnlazada<int> Doubly_List_Linked = new ListaDobleEnlazada<int>();
            auto.Auto_Add_DoublyListLinked(Doubly_List_Linked, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Delete_DoublyListLinked(Doubly_List_Linked, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Search_DoublyListLinked(Doubly_List_Linked, random, textBox2, int.Parse(textBox1.Text));
        }

        private async void btnListaCircularDobleEnlazada_Click(object sender, EventArgs e)
        {
            ListaCircularDobleEnlazada<int> Circular_Doubly_Linked_List = new ListaCircularDobleEnlazada<int>();
            auto.Auto_Add_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Delete_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, textBox2, int.Parse(textBox1.Text));
            await Task.Delay(2000);
            auto.Auto_Search_CircularDoublyLinkedList(Circular_Doubly_Linked_List, random, textBox2, int.Parse(textBox1.Text));
        }
        //Final Codigo Listas

        //Inicio Codigo Artbol
        private void btnDeleteTree_Click(object sender, EventArgs e)
        {
            string nodeNameToDelete = txtFather.Text;
            tree.DeleteNode(nodeNameToDelete, txtTree);
        }

        private void btnAddTree_Click(object sender, EventArgs e)
        {
            string parentNodeName = txtFather.Text;
            string newNodeName = txtNewNodeTree.Text;
            tree.AddNode(parentNodeName, newNodeName, txtTree);
        }
        //Final Codigo Artbol


        //Inicio Codigo Grapho
        private void btnAgregarVertice_Click(object sender, EventArgs e)
        {
            string verticeLabel = txtVertice.Text;

            if (!string.IsNullOrEmpty(verticeLabel))
            {
                Point location = new Point(graph.Vertices.Count * 50, graph.Vertices.Count * 50);
                Vertex vertex = new Vertex(verticeLabel, location);
                graph.AddVertex(vertex);

                // Dibujar el grafo
                DibujarGrafo();
            }
            else
            {
                MessageBox.Show("Ingrese un vértice válido.");
            }
        }

        private void btnAgregarBorde_Click(object sender, EventArgs e)
        {
            string origenLabel = txtOrigen.Text;
            string destinoLabel = txtDestino.Text;

            Vertex origen = graph.Vertices.Find(v => v.Label == origenLabel);
            Vertex destino = graph.Vertices.Find(v => v.Label == destinoLabel);

            if (origen != null && destino != null)
            {
                Edge edge = new Edge(origen, destino);
                graph.AddEdge(edge);

                // Dibujar el grafo
                DibujarGrafo();
            }
            else
            {
                MessageBox.Show("Ingrese un origen y destino válidos.");
            }
        }
        private void DibujarGrafo()
        {
            using (Graphics g = PTBGraphos.CreateGraphics())
            {
                graph.DrawGraph(g);
            }
        }
        //Final Codigo Grapho
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}

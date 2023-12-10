using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class ListaSimple <T>
    {
        private Node Head { get; set; }

        public ListaSimple()
        {
            Clear();
        }

        public void Agregar(int data)
        {
            //caso 0: Creamos nodo nuevo
            Node NewNode = new Node(data);
            //caso 1: Se inserta al inicio
            if (IsEmpty())
            {
                Head = NewNode;
                return;
            }
            //caso 2: Se impide repetir datos
            if (Exist(NewNode.Data))
            {
                return;
            }
            //caso 3: Se inserta el dato al inicio de la lista 
            if (NewNode.Data < Head.Data)
            {
                Head.Next = Head;
                Head = NewNode;
                return;
            }
            //caso 4: Se recorre la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data < NewNode.Data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //caso 5: Se inserta en X posicion o al final de la lista 
            NewNode.Next = CurrentNode.Next;
            CurrentNode.Next = NewNode;
        }

        public void Borrar(int data, System.Windows.Forms.TextBox textBox)
        {
            textBox.Text = string.Empty;
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Caso 2: Si el dato esta al inicio
            if (Head.Data == data)
            {
                Head = Head.Next;
                textBox.Text = ($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 3: Recorremos la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data < data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: Si el dato esta en X posicion
            if (CurrentNode.Next != null && CurrentNode.Next.Data == data)
            {
                CurrentNode.Next = CurrentNode.Next.Next;
                textBox.Text = ($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 5: No se encontro el dato
            textBox.Text = ($"- Dato[{data}] No encontrado/eliminado de la lista");
        }

        public void Search(int data, System.Windows.Forms.TextBox textBox)
        {
            textBox.Text = string.Empty;
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Case 2: Si el dato esta al inicio
            if (Head.Data == data)
            {
                textBox.Text = ($"- Dato[{data}] Existe en la lista");
                return;
            }
            //Caso 3: Recorremos la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data <= data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: Si el dato esta en X posicion
            if (CurrentNode.Data == data)
            {
                textBox.Text = ($"- Dato[{data}] Existe en la lista");
                return;
            }
            //Caso 5: No existe el dato
            textBox.Text = ($"- Dato[{data}] No Existe en la lista ");
        }

        public void Show(TextBox textBox)
        {
            textBox.Text = string.Empty;
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                textBox.Text = "Lista vacia";
                return;
            }
            //Caso 2: Recorremos la lista
            int i = 0;
            Node CurrentNode = Head;
            while (CurrentNode != null)
            {
                textBox.Text += $"- Nodo[{i}] y dato: {CurrentNode.Data}\r\n";
                CurrentNode = CurrentNode.Next;
                i++;
            }
        }

        public bool Exist(int data)
        {

            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return false;
            }
            //Caso 2: Si el primer nodo contiene el dato
            if (Head.Data == data)
            {
                return true;
            }
            //Caso 3: Empezamos a recorrer la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data <= data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: El dato existe en el ultimo elemento
            if (CurrentNode.Data == data)
            {
                return true;
            }
            //Caso 5: El dato no existe en la lista
            return false;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Clear()
        {
            Head = null;
        }
    }
}

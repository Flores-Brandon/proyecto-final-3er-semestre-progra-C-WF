using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class ListaDobleEnlazada <T>
    {
        private DoubleNode Head { get; set; }
        private DoubleNode LastNode { get; set; }

        public ListaDobleEnlazada()
        {
            Clear();
        }

        public void Add(int data)
        {
            //Caso 0: Creamos un nuevo nodo
            DoubleNode NewNode = new DoubleNode(data);
            //Caso 1: Insertamso al inicio
            if (IsEmpty())
            {
                Head = NewNode;
                LastNode = NewNode;
                return;
            }
            //Caso 2: Impedimos datos repetidos
            if (Exist(NewNode.Data))
            {
                return;
            }
            //Caso 3: El dato nuevo se inserta al inicio
            if (NewNode.Data < Head.Data)
            {
                Head.Back = NewNode;
                NewNode.Next = Head;
                Head = NewNode;
                return;
            }
            //Caso 4: El dato nuevo se inserta al final
            if (NewNode.Data > LastNode.Data)
            {
                LastNode.Next = NewNode;
                NewNode.Back = LastNode;
                LastNode = NewNode;
                return;
            }
            //Caso 5: Recorrermos la lista
            DoubleNode CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data < NewNode.Data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 6: Insertamso en X posicion
            NewNode.Next = CurrentNode.Next;
            NewNode.Back = CurrentNode;
            CurrentNode.Next.Back = NewNode;
            CurrentNode.Next = NewNode;
        }

        public void Delete(int data, System.Windows.Forms.TextBox textBox)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Caso 2: El dato a eliminar esta al inicio de la lista
            if (Head.Data == data)
            {
                Head = Head.Next;
                Head.Back = null;
                textBox.Text = ($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 3: El dato a eliminar esta al final de la lista
            if (LastNode.Data == data)
            {
                LastNode = LastNode.Back;
                LastNode.Next = null;
                textBox.Text = ($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 4: Recorremos la lista
            DoubleNode CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data < data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 5: El dato esta en X posicion de la lista
            if (CurrentNode.Next != null && CurrentNode.Next.Data == data)
            {
                CurrentNode.Next.Next.Back = CurrentNode;
                CurrentNode.Next = CurrentNode.Next.Next;
                textBox.Text = ($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 6: No se encontro el dato
            textBox.Text = ($"- Dato[{data}] No existe/eliminado de la lista");
        }

        public void Search(int data, System.Windows.Forms.TextBox textBox)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Caso 2: Si es dato esta al inicio
            if (Head.Data == data)
            {
                textBox.Text = ($"- Dato[{data}] Existe en la lista");
                return;
            }
            //Caso 3: Si es dato esta al final
            if (LastNode.Data == data)
            {
                textBox.Text = ($"- Dato[{data}] Existe en la lista");
                return;
            }
            //Caso 4: Recorremos la lista
            DoubleNode CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data <= data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 5: Si existe el dato en X posicion
            if (CurrentNode.Data == data)
            {
                textBox.Text = ($"- Dato[{data}] Existe en la lista");
                return;
            }
            //Caso 6: No existe el dato en la lista
            textBox.Text = ($"- Dato[{data}] No Existe en la lista ");
        }

        public void Show(System.Windows.Forms.TextBox textBox)
        {
            textBox.Text = string.Empty;
            //Caso 1: Si al lista esta vacia
            if (IsEmpty())
            {
                textBox.Text = ("Lista vacia");
                return;
            }
            //Caso 2: Recorremos la lista
            DoubleNode CurrentNode = Head;
            int i = 0;
            while (CurrentNode != null)
            {
                textBox.Text += ($"- Nodo[{i}] y dato: {CurrentNode.Data}\r\n");
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
            //Caso 2: Si el primer elemento ya existe
            if (Head.Data == data)
            {
                return true;
            }
            //Caso 3: Si es dato esta al final
            if (LastNode.Data == data)
            {
                return true;
            }
            //Caso 4: Recorremos la lista
            DoubleNode CurrentNode = Head;
            while (CurrentNode.Next != null && CurrentNode.Next.Data <= data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 5: El dato ingresado existe en X posicion
            if (CurrentNode.Data == data)
            {
                return true;
            }
            //Caso 6: El dato no existe en la lista
            return false;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Clear()
        {
            Head = null;
            LastNode = null;
        }

    }
}

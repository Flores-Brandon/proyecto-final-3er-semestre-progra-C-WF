using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class ListaCircular <T>
    {
        private Node Head { get ; set; }
        private Node LastNode { get ; set; }

        public ListaCircular()
        {
            Clear();
        }
        public void Agregar(int data)
        {
            //Caso 0: Creamos un nuevo nodo
            Node NewNode = new Node(data);
            //Caso 1: Insertamso al inicio
            if (IsEmpty())
            {
                Head = NewNode;
                Head.Next = Head;
                LastNode = NewNode;
                return;
            }
            //Caso 2: Impedimos datos repetidos
            if (Exist(NewNode.Data))
            {
                return;
            }
            //Caso 3: Colocamos el dato despues del primero
            if (NewNode.Data < Head.Data)
            {
                NewNode.Next = Head;
                Head = NewNode;
                LastNode.Next = Head;
                return;
            }
            //Caso 4: Recorremos la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != Head && CurrentNode.Next.Data <= NewNode.Data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 5: Insertamos en X posicion
            if (NewNode.Data < CurrentNode.Next.Data)
            {
                NewNode.Next = CurrentNode.Next;
                CurrentNode.Next = NewNode;
                return;
            }
            //Caso 6: Insertamos al ultimo
            NewNode.Next = CurrentNode.Next;
            CurrentNode.Next = NewNode;
            LastNode = NewNode;
        }

        public void Borrar(int data, System.Windows.Forms.TextBox textBox)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Caso 2: El dato esta al inicio de la lista
            if (Head.Data == data)
            {
                Head = Head.Next;
                LastNode.Next = Head;
                textBox.Text = ($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 3: Recorremos la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != Head && CurrentNode.Next.Data < data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: El dato esta al Final de la lista
            if (CurrentNode.Next == LastNode && CurrentNode.Next.Data == data)
            {
                CurrentNode.Next = CurrentNode.Next.Next;
                LastNode = CurrentNode;
                LastNode.Next = Head;
                textBox.Text = ($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 5: El dato esta en X posicion de la lista
            if (CurrentNode.Next.Data == data)
            {
                CurrentNode.Next = CurrentNode.Next.Next;
                textBox.Text = ($"- Dato[{data}] Eliminado de la lista");
                return;
            }
            //Caso 6: No se encontro el dato
            textBox.Text = ($"- Dato[{data}] No encontrado/eliminado de la lista");
        }

        public void Search(int data, System.Windows.Forms.TextBox textBox)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return;
            }
            //Case 2: Si el dato esta al inicio de la lista
            if (Head.Data == data)
            {
                textBox.Text = ($"- Dato[{data}] Existe en la lista");
                return;
            }
            //Caso 3: Recorremos la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != Head && CurrentNode.Next.Data <= data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: El dato ingresado existe X posicion
            if (CurrentNode.Data == data)
            {
                textBox.Text = ($"- Dato[{data}] Existe en la lista");
                return;
            }
            //Caso 5: No existe el dato
            textBox.Text = ($"- Dato[{data}] No Existe en la lista ");
        }

        public void Show(System.Windows.Forms.TextBox textBox)
        {
            //Caso 1: Comprobamos si al lista esta vacia
            if (IsEmpty())
            {
                textBox.Text = ("Lista vacia");
                return;
            }
            //Caso 2: Recorremos la lista
            Node CurrentNode = Head;
            int i = 0;
            do
            {
                textBox.Text += ($"- Nodo[{i}] y dato: {CurrentNode.Data}\r\n");
                CurrentNode = CurrentNode.Next;
                i++;
            } while (CurrentNode != Head);
        }

        public bool Exist(int data)
        {
            //Caso 1: Si la lista esta vacia
            if (IsEmpty())
            {
                return false;
            }
            //Caso 2: Si dato ya existe al inicio
            if (Head.Data == data)
            {
                return true;
            }
            //Caso 3: Recorremos la lista
            Node CurrentNode = Head;
            while (CurrentNode.Next != Head && CurrentNode.Next.Data <= data)
            {
                CurrentNode = CurrentNode.Next;
            }
            //Caso 4: Si dato ya existe al en X posicion/ o al final
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class Auto
    {
        public void Auto_Add_SimpleList(ListaSimple<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Agregar(R.Next(25));
            }
            lista.Show(textBox);
        }

        public void Auto_Delete_SimpleList(ListaSimple<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Borrar(R.Next(25), textBox);
            }
        }

        public void Auto_Search_SimpleList(ListaSimple<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Search(R.Next(25), textBox);
            }
        }

        public void Auto_Add_CircularList(ListaCircular<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            textBox.Text = string.Empty;
            for (int i = 0; i < numDatos; i++)
            {
                lista.Agregar(R.Next(25));
            }
            lista.Show(textBox);
        }

        public void Auto_Delete_CircularList(ListaCircular<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Borrar(R.Next(25), textBox);
            }
        }

        public void Auto_Search_CircularList(ListaCircular<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Search(R.Next(25), textBox);
            }
        }

        public void Auto_Add_DoublyListLinked(ListaDobleEnlazada<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {
            for (int i = 0; i < numDatos; i++)
            {
                lista.Add(R.Next(25));
            }
            lista.Show(textBox);
        }

        public void Auto_Delete_DoublyListLinked(ListaDobleEnlazada<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Delete(R.Next(25), textBox);
            }
        }

        public void Auto_Search_DoublyListLinked(ListaDobleEnlazada<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Search(R.Next(25), textBox);
            }
        }

        public void Auto_Add_CircularDoublyLinkedList(ListaCircularDobleEnlazada<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Add(R.Next(25));
            }
            lista.Show(textBox);
        }

        public void Auto_Delete_CircularDoublyLinkedList(ListaCircularDobleEnlazada<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Delete(R.Next(25), textBox);
            }
        }

        public void Auto_Search_CircularDoublyLinkedList(ListaCircularDobleEnlazada<int> lista, Random R, System.Windows.Forms.TextBox textBox, int numDatos)
        {

            for (int i = 0; i < numDatos; i++)
            {
                lista.Search(R.Next(25), textBox);
            }
        }
    }
}


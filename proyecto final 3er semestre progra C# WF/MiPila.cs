using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final_3er_semestre_progra_C__WF
{
    internal class MiPila <T>
    {
        private List<T> stackList;

        public MiPila() 
        {
            stackList = new List<T>();
        }

        public void Push (T item) 
        {
            stackList.Add (item);
        }

        public T Pop ()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("La Pila Esta Vacia");
            }
            int lastIndex = stackList.Count - 1;
            T poppedItem = stackList[lastIndex];
            stackList.RemoveAt(lastIndex);

            return poppedItem;
        }
        public T Peek()
        {
            if (stackList.Count == 0)
            {
                throw new InvalidOperationException("La Pila Esta Vacia");
            }

            return stackList[stackList.Count - 1];
        }

        public int Count
        {
            get { return stackList.Count; }
        }
        public T this[int index]
        {
            get { return stackList[index]; }
        }
    }
}

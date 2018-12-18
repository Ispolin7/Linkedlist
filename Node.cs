using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class Node<T>
    {
        public Node(T Data)
        {
            this.Data = Data;
        }
        public T Data { get; set; }

        public Node<T> Next;
    }
}

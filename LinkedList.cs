using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class LinkedList<T> : IEnumerator
    {
        // First and last nodes in list
        public Node<T> first;
        public Node<T> last;

        // Number of nodes in the list
        public int Count = 0;

        // Index for foreach
        int index = -1;

        /// <summary>
        /// Check if the list not empty
        /// </summary>
        /// <returns>true if list not empty</returns>
        public bool Any()
        {
            return this.first != null;
        }

        /// <summary>
        /// Get node by index
        /// </summary>
        /// <param name="index">the node index to get</param>
        /// <returns>found node</returns>
        public Node<T> GetByIndex(int index)
        {
            if (this.Any())
            {
                int count = this.Count;
                if (index < count)
                {
                    Node<T> current = this.first;
                    for (int i = 0; i < count; i++)
                    {
                        if(i == index)
                        {
                            return current;
                        }
                        current = current.Next;
                    }
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Replacing a node in the list
        /// </summary>
        /// <param name="index">index of the node to be replaced</param>
        /// <param name="data">node field that is being replaced</param>
        /// <returns>true if operation successful</returns>
        public bool InsertInIndex(int index, T data)
        {
            if (this.Any())
            {
                int count = this.Count;
                if (index < count)
                {
                    Node<T> added = new Node<T>(data);
                    if (index == 0)
                    {
                        added.Next = this.first.Next;
                        this.first = added;
                        return true;
                    }
                    else
                    {
                        Node<T> previous = this.GetByIndex(index - 1);
                        added.Next = previous.Next.Next;
                        previous.Next = added;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Delete selected node
        /// </summary>
        /// <param name="index">index of the node to be deleted</param>
        /// <returns>operation result</returns>
        public bool RemoveByIndex(int index)
        {
            if (this.Any())
            {
                int count = this.Count;
                // check that the index is less than the length of the list
                if (index < count)
                {
                    // if we delete the first item
                    if (index == 0)
                    {
                        // if only one item is list
                        if (count == 1)
                        {
                            this.first = null;
                            return true;
                        }
                        else
                        {
                            this.first = first.Next;
                            return true;
                        }                       
                    }
                    // if there are two elements in the list and you need to delete the last
                    else if (count == 2)
                    {                    
                        this.first.Next = null;
                        return true;                       
                    }
                    else
                    {
                        Node<T> previous = this.GetByIndex(index - 1);
                        // if need delete last element
                        if(index == count - 1)
                        {
                            previous.Next = null;
                            this.last = previous;
                            return true;
                        }
                        // if there are more than two items in the list and you need to delete not the first and not the last
                        else
                        {
                            previous.Next = previous.Next.Next;
                            return true;
                        }
                    }                   
                }
                Count--;
            }
            return false;
        }

        /// <summary>
        /// Add new node to end list
        /// </summary>
        /// <param name="element">node to add</param>
        public void Add(Node<T> element)
        {
            if (this.Any())
            {
                this.last.Next = element;
                this.last = element;
            }
            else
            {
                this.first = element;
                this.last = element;
            }
            Count++;
        }

        /// <summary>
        /// Delete node by data
        /// </summary>
        /// <param name="data">node data</param>
        /// <returns>operation result</returns>
        public bool Remove(T data)
        {
            if (this.Any())
            {
                Node<T> current = this.first;
                int index = 0;           
                while(current != null)
                {
                    // check for equality
                    if (current.Data.Equals(data))
                    {
                        return this.RemoveByIndex(index);
                    }
                    current = current.Next;
                    index++;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Convert list to array
        /// </summary>
        /// <returns>array with nodes data</returns>
        public T[] ToArray()
        {
            T[] list = null;
            if (this.Any())
            {
                int count = this.Count;
                list = new T[count] ;
                Node<T> current = this.first;
                // iterate all nodes
                for (int i = 0; i < count; i++)
                {
                    list[i] = current.Data;
                    current = current.Next;
                }
            }
            return list;
        }

        /// <summary>
        /// Sort list
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="firstNode">first node in list</param>
        public void Sort<T>(Node<T> firstNode) where T : IComparable
        {
            Node<T> current = firstNode;

            while (current != null)
            {
                Node<T> minimum = current;
                Node<T> next = current.Next;

                while (next != null)
                {
                    if (next.Data.CompareTo(minimum.Data) < 0)
                    {
                        minimum = next;
                    }
                    next = next.Next;
                }

                if (!Object.ReferenceEquals(minimum, current))
                {
                    T temp = current.Data;
                    current.Data = minimum.Data;
                    minimum.Data = temp;
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// Owerride IEnumerable method
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        /// <summary>
        /// IEnumerator, move to next node
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (index == this.Count - 1)
            {
                Reset();
                return false;
            }
            index++;
            return true;
        }

        /// <summary>
        /// IEnumerator, loop termination condition
        /// </summary>
        public void Reset()
        {
            index = -1;
        }

        /// <summary>
        /// IEnumerator, get current node in foreach
        /// </summary>
        public object Current
        {
            get
            {
                return GetByIndex(index);
            }
        }
    }
}

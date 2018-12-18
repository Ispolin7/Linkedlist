using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add(new Node<string>("1"));
            list.Add(new Node<string>("7"));
            list.Add(new Node<string>("3"));
            list.Add(new Node<string>("4"));
            list.Add(new Node<string>("5"));
          //  list.InsertInIndex(4, "8");
           
            foreach(Node<string> element in list)
            {
                element.Data = "0";
            }

            list.Sort(list.first);
            //string[] result = list.ToArray();
            //foreach(string data in result)
            //{
            //    Console.WriteLine(data);
            //}
            //list.RemoveByIndex(4);
            //Console.WriteLine(list.Remove("1"));
            //var head = list.first;

            //while (head != null)
            //{
            //    Console.WriteLine(head.Data);
            //    head = head.Next;
            //}
            //Console.WriteLine(list.Count());
            //bool remove = list.Remove();

            var head = list.first;

            while (head != null)
            {
                Console.WriteLine(head.Data);
                head = head.Next;
            }
            //Console.WriteLine(remove);
            //Console.WriteLine(list.Count());
            //Console.WriteLine(list.GetByIndex(4).Data);
            Console.ReadKey();            
        }
    }
}

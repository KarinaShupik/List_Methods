using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_add
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList list = new CircularLinkedList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.PrintList();
            list.Clear();
            list.PrintList();
        }
    }
}

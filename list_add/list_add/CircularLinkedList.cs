using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_add
{
    internal class CircularLinkedList
    {
        private Node head;
        private int size;

        public CircularLinkedList()
        {
            head = null;
            size = 0;
        }

        public void SwapElements(int firstValue, int secondValue)
        {
            if (head == null)
                return;

            Node firstNode = null;
            Node secondNode = null;
            Node current = head;

            do
            {
                if (current.Data == firstValue)
                    firstNode = current;

                if (current.Data == secondValue)
                    secondNode = current;

                current = current.Next;
            } while (current != head);

            if (firstNode == null || secondNode == null)
                return;

            Node firstPrev = GetPreviousNode(firstNode);
            Node secondPrev = GetPreviousNode(secondNode);

            if (firstPrev != null)
                firstPrev.Next = secondNode;
            else
                head = secondNode;

            if (secondPrev != null)
                secondPrev.Next = firstNode;
            else
                head = firstNode;

            Node temp = firstNode.Next;
            firstNode.Next = secondNode.Next;
            secondNode.Next = temp;
        }

        private Node GetPreviousNode(Node node)
        {
            Node current = head;

            while (current.Next != node)
            {
                current = current.Next;
            }

            return current;
        }

        public void AddBefore(int value, int newValue)
        {
            Node newNode = new Node(newValue);

            if (head == null)
            {
                head = newNode;
                newNode.Next = head;
                return;
            }

            Node current = head;
            Node previous = null;

            do
            {
                if (current.Data == value)
                {
                    newNode.Next = current;
                    if (previous == null)
                    {
                        head = newNode;
                    }
                    else
                    {
                        previous.Next = newNode;
                    }
                    return;
                }

                previous = current;
                current = current.Next;
            } while (current != head);
        }


        public void Add(int data)
        {
            Node node = new Node(data);

            if (head == null)
            {
                head = node;
                node.Next = head;
            }
            else
            {
                Node current = head;

                while (current.Next != head)
                {
                    current = current.Next;
                }

                current.Next = node;
                node.Next = head;
            }

            size++;
        }
        public void Remove(int data)
        {
            Node current = head;
            Node previous = null;

            while (current.Data != data)
            {
                if (current.Next == head)
                {
                    return;
                }

                previous = current;
                current = current.Next;
            }

            if (current == head)
            {
                if (size == 1)
                {
                    head = null;
                }
                else
                {
                    previous = head;

                    while (previous.Next != head)
                    {
                        previous = previous.Next;
                    }

                    head = head.Next;
                    previous.Next = head;
                }
            }
            else
            {
                previous.Next = current.Next;
            }

            size--;
        }

        public void PrintList()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            Node current = head;

            do
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            } while (current != head);

            if (size == 0)
            {
                Console.WriteLine("Empty list!");
            }

            Console.WriteLine();
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnLinkedList
{
    public class Node
    {
        public object data;
        public Node next;

        public Node(object i)
        {
            data = i;
            next = null;
        }
        public void InsertTailNode(object data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else
            {
                next.InsertTailNode(data);
            }
        }
        public void PrintList()
        {
            Console.WriteLine("[ " + data + " ] -> ");
            if (next != null)
            {
                next.PrintList();
            }
        }
    }

    public class LinkedList
    {
        public Node head;
        public int count;
        public Node next;


        public LinkedList()
        {
            head = null;
            next = null;
            count = 0;
        }
        public void PrintList()
        {
            if (head != null)
            {
                head.PrintList();
            }
        }
        public Node findNodes(object data)
        {
            for (Node curr = head; curr != null; curr = curr.next)
            {
                if (curr.data.Equals(data))
                {
                    Console.WriteLine("I have found the node at " + curr.data);
                    return curr;
                }
            }
            return null;
        }
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int Counter
        {
            get { return this.count; }
        }
        public void InsertHeadNode(object data)
        {
            if (head == null)
            {
                head = new Node(data);
                count++;
            }
            else
            {
                Node temp = new Node(data);
                temp.next = head;
                head = temp;
                count++;
            }
        }
        public void InsertTailNode(object data)
        {
            if (head == null)
            {
                head = new Node(data);
                count++;
            }
            else
            {
                head.InsertTailNode(data);
                count++;
            }
        }
        public void RemoveHeadNode()
        {
            if (count > 0)
            {
                head = head.next;
                count--;
            }
        }
        public void RemoveTailNode()
        {
            Node last = head;
            Node previousToLast = null;
            if (head == null)
            {
                Console.WriteLine("Cannot remove a non-exsistent tail node");
            }
            while (last.next != null)
            {
                previousToLast = last;
                last = last.next;
            }
            previousToLast.next = null;
            count--;
        }
        public void InsertAfter(Node x, object data)
        {
            for (Node curr = head; curr != null; curr = curr.next)
            {
                if (curr == x)
                {
                    Node temp = new Node(data);
                    temp.next = curr.next;
                    curr.next = temp;
                    count++;
                }
            }
        }
        public void RemoveAfter(Node y)
        {
            for (Node curr = head; curr != null; curr = curr.next)
            {
                if (curr == y)
                {
                    curr.next = curr.next.next;
                    count--;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertTailNode(7);
            list.InsertHeadNode(5);
            list.InsertHeadNode(3);
           list.RemoveTailNode();
            list.InsertHeadNode(11);
            list.InsertTailNode(4);
            Node currburr = list.findNodes(3);
            list.InsertAfter(currburr, 15);
            list.RemoveAfter(currburr);
            list.RemoveHeadNode();
            list.PrintList();
            Console.WriteLine("Is the List Empty? =  " + list.IsEmpty);
            Console.WriteLine("The list is currently at = " + list.Counter);

        }
    }
}

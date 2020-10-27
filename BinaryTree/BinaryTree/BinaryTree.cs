using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Node<T>
        where T : IComparable
    {
        public T Key;
        public Node<T> Left, Right, Parent;

        public Node(T value,Node<T> parent)
        {
            Key = value;
            Parent = parent;
        }
    }
    public class BinaryTree<T>
        where T : IComparable
    {
        private Node<T> _root;

        public void Add(T key)
        {
            if (_root == null)
                _root = new Node<T>(key,null);
            else
            {
                var treeNode = _root;
                while (true)
                {
                    if (treeNode.Key.CompareTo(key) <= 0)
                        if (treeNode.Right == null)
                        {
                            treeNode.Right = new Node<T>(key,treeNode);
                            return;
                        }
                        else treeNode = treeNode.Right;
                    else
                    if (treeNode.Left == null)
                    {
                        treeNode.Left = new Node<T>(key,treeNode);
                        return;
                    }
                    else treeNode = treeNode.Left;
                }
            }
        }
        
        public Node<T> FindKey(T key)
        {
            var current = _root;
            while (true)
            {
                if (current == null) return null;
                if (current.Key.CompareTo(key) == 0) return current;
                if (current.Key.CompareTo(key) < 0)
                    if (current.Right != null)
                        current = current.Right;
                    else return current;
                else
                {
                    if (current.Left != null)
                        current = current.Left;
                    else return current;
                }
            }
        }

        public void Print2()
        {
            if (_root == null) return;
            var str = new StringBuilder(_root.Key+"\n");
            var stack = new Stack<Tuple<Node<T>,int>>();
            if (_root.Right != null) stack.Push(Tuple.Create(_root.Right, 0));
            if (_root.Left != null) stack.Push(Tuple.Create(_root.Left, 0));
            while (stack.Count > 0)
            {
                var variable = stack.Pop();
                if (variable.Item1.Right != null) stack.Push(Tuple.Create(variable.Item1.Right, variable.Item2+1));
                if (variable.Item1.Left != null) stack.Push(Tuple.Create(variable.Item1.Left, variable.Item2+1));
                var line = "";
                for (var i = 0; i < (variable.Item2) * 3; i++)
                {
                    if (i % 3 == 0)
                    {
                        if ((variable.Item1.Right == null || variable.Item1.Left == null) && i==(variable.Item2)*3-1)
                            line += " ";
                        else line += "│";
                    }
                    else line += " ";
                }
                if (variable.Item1.Parent.Right == null || variable.Item1.Parent.Left == null)
                    line += "└──"+variable.Item1.Key;
                else
                    line += "├──"+variable.Item1.Key;
                str.Append(line+"\n");
            }

            Console.WriteLine(str.ToString());
        }
        public int FindHeight()
        {
            if (_root == null) return 0;
            var height = 0;
            var myQueue = new Queue<Tuple<Node<T>,int>>();
            myQueue.Enqueue(Tuple.Create(_root,0));
            while (myQueue.Count > 0)
            {
                var value = myQueue.Dequeue();
                if(value.Item1.Left!=null)
                    myQueue.Enqueue(Tuple.Create(value.Item1.Left,value.Item2+1));
                if(value.Item1.Right!=null)
                    myQueue.Enqueue(Tuple.Create(value.Item1.Right,value.Item2+1));
                height = value.Item2;
            }

            return height;
        }
        public List<T> GetKeys()
        {
            var list = new List<T>();
            var stack = new Stack<Node<T>>();
            var treeNode = _root;
            while(treeNode != null || stack.Count > 0)
            {
                if(treeNode != null)
                {
                    stack.Push(treeNode);
                    treeNode = treeNode.Left;
                }
                else
                {
                    treeNode = stack.Pop();
                    list.Add(treeNode.Key);
                    treeNode = treeNode.Right;
                }
            }

            return list;
        }
        
    }
}
/*
  public void Print()
        {
            if (_root == null) return;
            var myQueue = new Queue<Node<T>>();
            myQueue.Enqueue(_root);
            var line = "";
            var lowLine = "";
            int count = 0, temp = 1,h=-1;
            var realH = FindHeight();
            while (realH>=h)
            {
                count++;
                var value = myQueue.Dequeue();
                if (value == null)
                {
                    myQueue.Enqueue(null);
                    myQueue.Enqueue(null);
                }
                else
                {
                    if (value.Left != null)
                    {
                        myQueue.Enqueue(value.Left);
                        lowLine += "/";
                    }
                    else myQueue.Enqueue(null);
                    if (value.Right != null)
                    {
                        myQueue.Enqueue(value.Right);
                        lowLine += "\\";
                    }
                    else myQueue.Enqueue(null);
                    lowLine += count!=temp ? "_": "";
                }

                line += value != null ? ((count != 1 ? "|" : "")+value.Key) : "";
                if (count != temp) continue;
                Print(ref h,ref count,ref temp,realH,ref line,ref lowLine);
            }
        }

        private static void Print(ref int h, ref int count, ref int temp,int realH, ref string line, ref string lowLine )
        {
            h++; 
            count = 0;
            temp *= 2;
            Console.WriteLine(line); 
            if(h!=realH) Console.WriteLine(lowLine);
            line = "";
            lowLine = "";
        }
*/
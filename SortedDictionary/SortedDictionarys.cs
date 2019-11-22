using System;
using System.Collections.Generic;
using System.Text;

namespace SortedDictionary
{
    class SortedDictionarys<K,V> where V: IComparable<V>
    {
        Entry<K, V> root;
        int count;
        public int Count { get { return count; } }
        public Entry<K, V> Root { get { return root; } set { root = value; } }
        public V miniValue = default(V);
        public int CompareTo(V otherVal)
        {

            return otherVal.CompareTo(miniValue);

        }
        public void Inorder()
        {
            Entry<K, V> treeNode = root;
            if (treeNode == null)
            {
                throw new ArgumentException("Nigga how far you na");
            }
            //if(!keys.Equals(treeNode.Keys))
            //{
                Stack<Entry<K, V>> S = new Stack<Entry<K, V>>();
                while (true)
                {
                    while (treeNode != null)
                    {
                        S.Push(treeNode);
                        treeNode = treeNode.Left;
                    }
                    if (S.Count == 0) { break; }
                    treeNode = S.Pop();
                    Console.WriteLine(treeNode.Values + " ");
                    treeNode = treeNode.Right;

                }
            //}
            //return treeNode.Values;
        }
        public V Get(K keys)
        {
            Entry<K, V> slot = root;
            while (slot != null)
            {
                if (keys.Equals(slot.Keys))
                {
                    return slot.Values;
                }
                Queue<Entry<K, V>> Q = new Queue<Entry<K, V>>();
                Q.Enqueue(slot);
                while(Q.Count!= 0)
                {
                    slot = Q.Dequeue();
                    if (slot.Keys.Equals(keys))
                    {
                        break;
                    }
                    if(slot.Left != null)
                    {
                        Q.Enqueue(slot.Left);

                    }
                    if(slot.Right != null)
                    {
                        Q.Enqueue(slot.Right);
                    }
                }
            }
            throw new ArgumentException("Key doesnt exist");
        }
        public void Insert(K keys , V values)
        {
            Entry<K, V> newNode = new Entry<K, V>(keys,values);
            if(root == null)
            {
                root = newNode;
                count++;
                return;
            }
            Entry<K, V> currentNode = root;
            Entry<K, V> parentNode = null;
            if (keys.Equals(newNode.Keys))
            {
                while (true)
                {
                    parentNode = currentNode;
                    if(values.CompareTo(currentNode.Values)<0)
                    {
                        currentNode = currentNode.Left;
                        if(currentNode == null)
                        {
                            parentNode.Left = newNode;
                            count++;
                            return;
                        }
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                        if(currentNode == null)
                        {
                            parentNode.Right = newNode;
                            count++;
                            return;
                        }
                    }
                   
                }
            }
            
        }
    }
}

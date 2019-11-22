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
        public bool Empty { get { return count == 0; } }
        public bool ContainsKey(K keys)
        {
            Entry<K, V> slot = root;
            if(slot == null)
            {
                return false;
            }
            Queue<Entry<K, V>> Q = new Queue<Entry<K, V>>();
            Q.Enqueue(slot);
            while(Q.Count != 0)
            {
                slot = Q.Dequeue();
                if(slot.Left != null)
                {
                    Q.Enqueue(slot.Left);
                }
                if(slot.Right != null)
                {
                    Q.Enqueue(slot.Right);
                }
                if (slot.Keys.Equals(keys))
                {
                    return true;
                }
               
            }
            return false;
        }
        public bool ContainsValue(V values)
        {
            Entry<K, V> slot = root;
            if (slot == null)
            {
                return false;
            }
            Queue<Entry<K, V>> Q = new Queue<Entry<K, V>>();
            Q.Enqueue(slot);
            while (Q.Count != 0)
            {
                slot = Q.Dequeue();
                if (slot.Left != null)
                {
                    Q.Enqueue(slot.Left);
                }
                if (slot.Right != null)
                {
                    Q.Enqueue(slot.Right);
                }
                if (slot.Values.Equals(values))
                {
                    return true;
                }

            }
            return false;
        }
        public void Inorder()
        {
            Entry<K, V> treeNode = root;
            if (treeNode == null)
            {
                throw new ArgumentException("Nigga how far you na");
            }
            
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
                if (!slot.Keys.Equals(keys))
                {
                    throw new ArgumentException("Key doesnt exist");
                }
            }

            
            throw new ArgumentException("Key doesnt exist");
        }
        public void Insert(K keys , V values)
        {
            if (ContainsKey(keys))
            {
                throw new ArgumentException("You cant use duplicate keys here nigga"); // Sorted dictionary didnt allow for dupplicates keys
            }
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
        
        public bool Delete(K keys)
        {
            Entry<K,V> parent = root;
            Entry<K,V> current = root;
            bool isLeftChild = false;
            while (!current.Keys.Equals(keys))
            {
                parent = current;
                if (current.Values.CompareTo(root.Values) > 0)
                {
                    isLeftChild = true;
                    current = current.Left;
                }
                else
                {
                    isLeftChild = false;
                    current = current.Right;
                }
                if (current == null)
                {
                    return false;
                }
            }
            // case 1: if node has no children
            if (current.Left == null && current.Right == null)
            {
                if (current == root)
                {
                    root = null;
                }
                if (isLeftChild == true)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            /// if it has only one child
            else if (current.Right == null)
            {
                if (current == root)
                {
                    root = current.Left; // updating the root with the child
                }
                else if (isLeftChild == true)
                {
                    parent.Left = current.Left;
                }
                else
                {
                    parent.Right = current.Right;
                }
            }
            else if (current.Left == null)
            {
                if (current == root)
                {
                    root = root.Right;
                }
                else if (isLeftChild)
                {
                    parent.Left = current.Right;
                }
                else
                {
                    parent.Right = current.Right;
                }
            }
            // case 3,when the root has two children
            else if (current.Left != null && current.Right != null)
            {
                Entry<K,V> sucessor = Successor(current);
                if (current == root)
                {
                    root = sucessor;
                }
                else if (isLeftChild)
                {
                    parent.Left = sucessor;
                }
                else
                {
                    parent.Right = sucessor;
                }
                sucessor.Left = current.Left;
            }
            count--;
            return true;
        }
        public Entry<K,V> Successor(Entry<K,V> node)
        {

            if (node != null)
            {
                if (node.Right != null)
                {
                    while (node.Left != null)
                    {
                        node = node.Left;
                    }

                }
            }
            return node;

        }
        public void clear()
        {
            root = null;
            count = 0;
        }
        public V this[K index]
        {
            get
            {
                return Get(index);
            }
        }
    }
}

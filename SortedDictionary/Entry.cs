using System;
using System.Collections.Generic;
using System.Text;

namespace SortedDictionary
{
    class Entry<K,V>
    {
        Entry<K,V> right;
        Entry<K, V> left;
        K key;
        V values;
        public Entry()
        {
           // left = right = null;
        }
        public Entry(V values)
        {
            this.values = values;
        }
        public Entry(K key, V values)
        {
            this.key = key;
            this.values = values;
        }

        public Entry<K,V> Right { get { return right; } set { right = value; } }
        public Entry<K, V> Left { get { return left; } set { left = value; } }
        public K Keys { get { return key; } set { key = value; } }
        public V Values { get { return values; } set { values = value; } }

    }
}

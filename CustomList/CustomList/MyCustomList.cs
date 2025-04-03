using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomList
{
    class MyCustomList<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;

        public int Count => count;
        public int Capacity => items.Length;

        public MyCustomList()
        {
            items = new T[3];
            count = 0;
        }
        public MyCustomList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity cannot be negative.", nameof(capacity));

            items = new T[capacity];
            count = 0;
        }
        public MyCustomList(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Array cannot be empty.", nameof(array));

            items = new T[array.Length];
            Array.Copy(array, items, array.Length);
            count = array.Length;
        }


        private void Resize()
        {
            int newCapacity = items.Length == 0 ? 3 : items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, newItems, count);
            items = newItems;
        }
        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException("Item cannot be empty.", nameof(item));

            if (count == items.Length)
                Resize();

            items[count] = item;
            ++count;
        }
        public bool Remove(T item)
        {
            int index = Array.IndexOf(items, item, 0, count);
            if (index == -1)
                return false;

            RemoveAtIndex(index);
            return true;
        }
        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("Index out of range.", nameof(index));

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;
            items[count] = default;
        }


        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
                items[index] = value;
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

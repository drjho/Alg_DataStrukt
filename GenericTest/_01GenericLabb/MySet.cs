using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01GenericLabb
{
    public class MySet<T> : ISet<T>
    {
        public int Count
        {
            get
            {
                return count;
            }
        }

        void IncreaseCapacity()
        {
            var tempArray = new T[array.Length * 2];
            for (int i = 0; i < count; i++)
            {
                tempArray[i] = array[i];
            }
            array = tempArray;
        }

        public void Add(T item)
        {
            if (this.Contains(item))
                return;
            if (count >= array.Length)
                IncreaseCapacity();
            array[count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item))
                    return true;
            }
            return false;
        }

        public ISet<T> Copy()
        {
            var newSet = new MySet<T>();
            for (int i = 0; i < count; i++)
            {
                newSet.Add(array[i]);
            }
            return newSet;
        }

        public bool EqualTo(ISet<T> other)
        {
            if (count != other.Count)
                return false;
            for (int i = 0; i < count; i++)
            {
                if (!other.Contains(array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public ISet<T> IntersectionWith(ISet<T> other)
        {
            var newSet = new MySet<T>();
            for (int i = 0; i < count; i++)
            {
                if (other.Contains(array[i]))
                {
                    newSet.Add(array[i]);
                }
            }
            return newSet;
        }

        int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                for (int i = index; i < count; i++)
                {
                    array[i] = array[i + 1];
                }
                --count;
            }
        }

        public ISet<T> UnionWith(ISet<T> other)
        {
            var newSet = other.Copy();
            for (int i = 0; i < count; i++)
            {
                newSet.Add(array[i]);
            }

            return newSet;
        }

        int count = 0;
        T[] array = new T[16];
    }
}

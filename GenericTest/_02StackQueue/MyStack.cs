using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02StackQueue
{
    public class MyStack<T> : IMyCollection<T>, IEnumerable<T>
    {
        class MyT
        {
            public T Item { get; set; }
            public MyT Previous { get; set; }
        }

        private MyT Tail { get; set; }

        public int Count
        {
            get; private set;
        }

        public void Push(T item)
        {
            var newT = new MyT() { Item = item };
            if (Tail != null)
                newT.Previous = Tail;
            Tail = newT;
            Count++;
        }

        public T Pop()
        {
            var temp = Tail;
            Tail = Tail.Previous;
            temp.Previous = null;
            Count--;
            return temp.Item;
        }

        public T Peek()
        {
            return Tail.Item;
        }

        public void Add(T item)
        {
            Push(item);
        }

        public void Clear()
        {
            if (Tail != null)
            {
                var current = Tail;
                do
                {
                    var temp = current;
                    current = current.Previous;
                    temp.Item = default(T);
                    temp.Previous = null;
                    temp = null;
                    --Count;
                } while (current != null);
                Tail = null;
            }
        }

        public bool Contains(T item)
        {
            if (Tail != null)
            {
                var current = Tail;
                do
                {
                    if (current.Item.Equals(item))
                    {
                        return true;
                    }
                    current = current.Previous;
                } while (current != null);
            }
            return false;
        }

        public T Get()
        {
            return Peek();
        }

        public T GetAndRemove()
        {
            return Pop();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Tail != null)
            {
                var current = Tail;
                do
                {
                    yield return current.Item;
                    current = current.Previous;
                } while (current != null);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}

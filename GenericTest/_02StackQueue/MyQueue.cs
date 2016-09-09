using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02StackQueue
{
    class MyQueue<T> : IMyCollection<T>, IEnumerable<T>
    {
        class MyT
        {
            public T Item { get; set; }
            public MyT Next { get; set; }
        }

        private MyT Head { get; set; }

        private MyT Tail { get; set; }

        public int Count
        {
            get; private set;
        }

        public void Enqueue(T item)
        {
            if (Head == null)
            {
                Head = new MyT() { Item = item };
                Tail = Head;
                Count++;
            }
            else
            {
                var newT = new MyT() { Item = item };
                Tail.Next = newT;
                Tail = newT;
                Count++;
            }
        }

        public T Dequeue()
        {
            var deqT = Head;
            Head = deqT.Next;
            deqT.Next = null;
            Count--;
            return deqT.Item;
        }

        public T Peek()
        {
            return Head.Item;
        }

        public void Add(T item)
        {
            Enqueue(item);
        }

        public void Clear()
        {
            if (Head != null)
            {
                var current = Head;
                do
                {
                    var temp = current;
                    current = current.Next;
                    temp.Item = default(T);
                    temp.Next = null;
                    temp = null;

                } while (current != null);
                Head = null;
                Tail = null;
            }
        }

        public bool Contains(T item)
        {
            if (Head != null)
            {
                var current = Head;
                do
                {
                    if (current.Item.Equals(item))
                        return true;
                    current = current.Next;
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
            return Dequeue();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Head != null)
            {
                var current = Head;
                do
                {
                    yield return current.Item;
                    current = current.Next;
                } while (current != null);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}

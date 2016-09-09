using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02StackQueue
{
    interface IMyCollection<T>
    {
        void Add(T item); // Jfr Enqueue / Push

        T Get(); // Jfr Peek

        T GetAndRemove(); // Jfr Dequeue / Pop

        Int32 Count { get; }

        void Clear();

        Boolean Contains(T item);
    }
}

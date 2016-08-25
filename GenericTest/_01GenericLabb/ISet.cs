using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01GenericLabb
{
    public interface ISet<T>
    {
        int Count { get; }

        void Add(T item);

        ISet<T> Copy();

        bool Contains(T item);

        ISet<T> UnionWith(ISet<T> other);

        ISet<T> IntersectionWith(ISet<T> other);

        bool EqualTo(ISet<T> other);

        void Remove(T item);
    }
}

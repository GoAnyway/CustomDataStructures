using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomDataStructures.Library
{
    public class CustomHashSet<T> : IEnumerable<T>
    {
        private List<T>[] _storage = new List<T>[10];

        public int Count { get; private set; } = 0;
        public bool IsEmpty { get => Count == 0; }

        public void Add(T element)
        {
            if(Count == _storage.Length - 1)
            {
                var newStorage = new List<T>[_storage.Length * 2];

                foreach (var bucket in _storage.Where(_ => _ != null && _.Any()))
                {
                    foreach (var item in bucket)
                    {
                        int newIndex = item.GetHashCode() % newStorage.Length;
                        newStorage[newIndex] = new List<T> { item };
                    }
                }

                _storage = newStorage;
            }

            int index = element.GetHashCode() % _storage.Length;

            if(!Contains(element))
            {
                _storage[index] = new List<T> { element };
                Count++;
            }
        }

        public bool Contains(T element)
        {
            int index = element.GetHashCode() % _storage.Length;

            return _storage[index]?.Any(_ => _.Equals(element)) ?? false;
        }

        public bool Remove(T element)
        {
            if(Contains(element))
            {
                int index = element.GetHashCode() % _storage.Length;
                _storage[index].Remove(element);

                Count--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            _storage = new List<T>[10];
            Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var bucket in _storage.Where(_ => _ != null && _.Any()))
            {
                foreach (var item in bucket)
                {
                    yield return item;
                }
            }
        }
    }
}
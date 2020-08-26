using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomDataStructures.Library
{
    public class CustomDictionary<TKey, TValue> : IEnumerable<TValue>
    {
        private List<CustomKeyValuePair<TKey, TValue>>[] _storage = new List<CustomKeyValuePair<TKey, TValue>>[10];

        public int Count { get; private set; } = 0;
        public bool IsEmpty { get => Count == 0; }

        public void Add(TKey key, TValue value)
        {
            if (Count == _storage.Length - 1)
            {
                var newStorage = new List<CustomKeyValuePair<TKey, TValue>>[_storage.Length * 2];

                foreach (var bucket in _storage.Where(_ => _ != null && _.Any()))
                {
                    foreach (var item in bucket)
                    {
                        int newIndex = item.GetHashCode() % newStorage.Length;
                        newStorage[newIndex] = new List<CustomKeyValuePair<TKey, TValue>>
                        {
                            new CustomKeyValuePair<TKey, TValue>(key, value)
                        };
                    }
                }

                _storage = newStorage;
            }

            int index = key.GetHashCode() % _storage.Length;

            if (!Contains(key))
            {
                _storage[index] = new List<CustomKeyValuePair<TKey, TValue>>
                {
                    new CustomKeyValuePair<TKey, TValue>(key, value)
                };
                Count++;
            }
            else
            {
                throw new ArgumentException($"An item with the same key has already been added. Key: {key}");
            }
        }

        public bool Remove(TKey key)
        {
            if (Contains(key))
            {
                int index = key.GetHashCode() % _storage.Length;
                _storage[index].Remove(_storage[index].Where(_ => _.Key.Equals(key)).First());

                Count--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Contains(TKey key)
        {
            int index = key.GetHashCode() % _storage.Length;

            return _storage[index]?.Any(_ => _.Key.Equals(key)) ?? false;
        }


        public void Clear()
        {
            _storage = new List<CustomKeyValuePair<TKey, TValue>>[10];
            Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            foreach (var bucket in _storage.Where(_ => _ != null && _.Any()))
            {
                foreach (var item in bucket)
                {
                    yield return item.Value;
                }
            }
        }
    }
}
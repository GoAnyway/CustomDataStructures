using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDataStructures.Library
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private CustomQueueItem<T> _head;
        private CustomQueueItem<T> _tail;

        public int Count { get; private set; } = 0;
        public bool IsEmpty { get => Count == 0; }

        public void Enqueue(T item)
        {
            var newItem = new CustomQueueItem<T>(item);

            if (IsEmpty)
            {
                _head = newItem;
            }
            else
            {
                _tail.Next = newItem;
            }

            _tail = newItem;
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            T output = _head.Data;
            _head = _head.Next;

            Count--;
            return output;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            return _head.Data;
        }

        public bool Contains(T data)
        {
            var index = 0;
            CustomQueueItem<T> current = _head;
            while (index++ < Count && !current.Data.Equals(data))
            {
                current = current.Next;
            }

            return --index < Count && current.Data.Equals(data);
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            CustomQueueItem<T> current = _head;
            var index = 0;
            while (index++ < Count)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
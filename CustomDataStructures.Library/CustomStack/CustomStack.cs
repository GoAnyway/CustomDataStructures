using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDataStructures.Library
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private CustomStackItem<T> _head;

        public int Count { get; private set; } = 0;
        public bool IsEmpty { get => Count == 0; }

        public void Push(T item)
        {
            _head = new CustomStackItem<T>(item)
            {
                Next = _head
            };

            Count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            CustomStackItem<T> deletedItem = _head;
            _head = _head.Next;

            Count--;
            return deletedItem.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            return _head.Data;
        }

        public bool Contains(T data)
        {
            var index = 0;
            CustomStackItem<T> current = _head;
            while (index++ < Count && !current.Data.Equals(data))
            {
                current = current.Next;
            }

            return --index < Count && current.Data.Equals(data);
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            CustomStackItem<T> current = _head;
            var index = 0;
            while (index++ < Count)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

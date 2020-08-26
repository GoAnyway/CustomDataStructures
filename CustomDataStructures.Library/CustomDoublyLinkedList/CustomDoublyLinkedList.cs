using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDataStructures.Library
{
    public class CustomDoublyLinkedList<T> : IEnumerable<T>
    {
        private DoublyNode<T> _head;
        private DoublyNode<T> _tail;

        public int Count { get; private set; } = 0;
        public bool IsEmpty { get => Count == 0; }

        public void AddLast(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);

            if (IsEmpty)
                _head = newNode;
            else
            {
                _tail.Next = newNode;
                _tail.Previous = _tail;
            }

            _tail = newNode;
            Count++;
        }

        public void AddFirst(T data)
        {
            _head = new DoublyNode<T>(data)
            {
                Previous = _head,
                Next = _head
            };

            if (IsEmpty)
                _tail = _head;

            Count++;
        }

        public bool Remove(T data)
        {
            if (data == null || IsEmpty)
                return false;

            if (data.Equals(_head.Data))
            {
                _head = _head.Next;

                Count--;
                return true;
            }
            else
            {
                DoublyNode<T> current = _head;
                while (current.Next != null && !current.Data.Equals(data))
                {
                    current = current.Next;
                }

                if (current.Next == null && !current.Data.Equals(data))
                    return false;

                current.Next = current.Next?.Next;
                //current.Next.Previous = current.Previous;

                Count--;
                return true;
            }
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            if (IsEmpty)
                return false;

            var index = 0;
            DoublyNode<T> current = _head;
            while (index++ < Count && !current.Data.Equals(data))
            {
                current = current.Next;
            }

            return --index < Count && current.Data.Equals(data);
        }

        public int IndexOf(T data)
        {
            if (IsEmpty)
                return -1;

            var index = 0;
            DoublyNode<T> current = _head;
            while (index++ < Count && !current.Data.Equals(data))
            {
                current = current.Next;
            }

            return --index < Count ? index : -1;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count - 1)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array.");

                DoublyNode<T> current = _head;
                while (index-- > 0)
                {
                    current = current.Next;
                }

                return current.Data;
            }
            set
            {
                if (index < 0 || index > Count - 1)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array.");

                if (index == 0)
                {
                    _head = new DoublyNode<T>(value)
                    {
                        Next = _head.Next
                    };
                }

                else
                {
                    DoublyNode<T> previous = _head;

                    while (--index > 0)
                    {
                        previous = previous.Next;
                    }

                    previous.Next = new DoublyNode<T>(value)
                    {
                        Next = previous.Next?.Next
                    };
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = _head;
            var index = 0;
            while (index++ < Count)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = _tail;
            var index = 0;
            while (index++ < Count)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}
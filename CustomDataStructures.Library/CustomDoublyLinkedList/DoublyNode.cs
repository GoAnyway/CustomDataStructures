namespace CustomDataStructures.Library
{
    public class DoublyNode<T>
    {
        public T Data { get; private set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }

        public DoublyNode(T data) => Data = data;
    }
}
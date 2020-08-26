namespace CustomDataStructures.Library
{
    public class CustomStackItem<T>
    {
        public T Data { get; private set; }
        public CustomStackItem<T> Next { get; set; }
        public CustomStackItem(T data) => Data = data;
    }
}

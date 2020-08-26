namespace CustomDataStructures.Library
{
    public class CustomQueueItem<T>
    {
        public T Data { get; private set; }
        public CustomQueueItem<T> Next { get; set; }
        public CustomQueueItem(T data) => Data = data;
    }
}
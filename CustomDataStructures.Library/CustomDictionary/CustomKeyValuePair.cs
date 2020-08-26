namespace CustomDataStructures.Library
{
    public class CustomKeyValuePair<TKey, TValue>
    {
        public CustomKeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
        public TKey Key { get; }
        public TValue Value { get; }
    }
}
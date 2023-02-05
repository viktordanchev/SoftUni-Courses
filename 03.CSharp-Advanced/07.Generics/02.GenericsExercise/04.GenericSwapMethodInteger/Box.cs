namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
    {
        public T BoxValue { get; set; }

        public override string ToString()
        {
            return $"{BoxValue.GetType()}: {BoxValue}";
        }
    }
}
namespace _03.GenericSwapMethodString
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

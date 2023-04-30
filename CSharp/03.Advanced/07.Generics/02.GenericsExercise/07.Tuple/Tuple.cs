namespace _07.Tuple
{
    public class Tuple<T, T2>
    {
        public T FirstObj { get; set; }
        public T2 SecondObj { get; set; }

        public Tuple(T firstObj, T2 secondObj)
        {
            FirstObj = firstObj;
            SecondObj = secondObj;
        }
    }
}

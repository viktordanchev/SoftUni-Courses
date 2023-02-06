namespace _08.Threeuple
{
    public class Threeuple<T, T2, T3>
    {
        public T FirstObj { get; set; }
        public T2 SecondObj { get; set; }
        public T3 ThirdObj { get; set; }

        public Threeuple(T firstObj, T2 secondObj, T3 thirdObj)
        {
            FirstObj = firstObj;
            SecondObj = secondObj;
            ThirdObj = thirdObj;
        }
    }
}
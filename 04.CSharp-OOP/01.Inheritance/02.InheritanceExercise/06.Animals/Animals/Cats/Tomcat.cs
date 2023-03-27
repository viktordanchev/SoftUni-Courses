namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender)
            : base(name, age, gender)
        {
            Gender = "Male";
        }

        public override string ProduceSound()
            => "MEOW";
    }
}

namespace UniversityCompetition.IO
{
    using System;
    using System.IO;
    using UniversityCompetition.IO.Contracts;

    public class Writer : IWriter
    {
        string path = "../../../o.txt";

        public void Write(string message)
        {
            using (StreamWriter wr = new StreamWriter(path, true))
            {
                wr.Write(message);
            }

            //Console.Write(message);
        }

        public void WriteLine(string message)
        {
            using (StreamWriter wr = new StreamWriter(path, true))
            {
                wr.WriteLine(message);
            }

            //Console.WriteLine(message);
        }
    }
}

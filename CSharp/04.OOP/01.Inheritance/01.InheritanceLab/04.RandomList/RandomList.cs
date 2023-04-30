using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();

            return random.Next(0, Count).ToString();
        }
    }
}
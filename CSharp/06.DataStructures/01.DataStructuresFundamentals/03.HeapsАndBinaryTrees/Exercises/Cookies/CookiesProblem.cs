using System.Collections.Generic;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var list = new List<int>(cookies);
            list.Sort();

            var count = 0;
            while (list.Count > 0)
            {
                var cookie = list[0];

                if(AreAllGreater(list, minSweetness))
                {
                    return count;
                }

                if (cookie < minSweetness)
                {
                    if(list.Count > 1)
                    {
                        cookie += 2 * list[1];
                        list[1] = cookie;
                    }

                    count++;
                }

                list.RemoveAt(0);
            }

            return -1;
        }

        private bool AreAllGreater(List<int> cookies, int minSweetness) 
        {
            for (int i = 0; i < cookies.Count; i++)
            {
                if (cookies[i] < minSweetness)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

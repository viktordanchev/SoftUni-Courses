using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }

            return false;
        }
        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (string item in collection)
            {
                this.Push(item);
            }

            return this;
        }
    }
}
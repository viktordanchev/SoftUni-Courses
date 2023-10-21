namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (string str in input)
            {
                var keys = str.Split(" ").Select(int.Parse).ToArray();

                var parent = keys[0];
                var child = keys[1];

                AddEdge(parent, child);
            }

            return null;
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            throw new NotImplementedException();
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = new IntegerTree(parent);
            var childNode = new IntegerTree(child);
        }

        public IntegerTree GetRoot()
        {
            throw new NotImplementedException();
        }
    }
}

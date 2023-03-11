using System;
using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> addCollectionOperations = new();
            List<int> addRemoveCollectionOperations = new();
            List<int> myListOperations = new();
            List<string> AddRemoveCollectionRemoves = new();
            List<string> myListRemoves = new(); 

            string[] elemntsToAdd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            AddCollection<string> addCollection = new AddCollection<string>();
            AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            for (int i = 0; i < elemntsToAdd.Length; i++)
            {
                addCollectionOperations.Add(addCollection.Add(elemntsToAdd[i]));
                addRemoveCollectionOperations.Add(addRemoveCollection.Add(elemntsToAdd[i]));
                myListOperations.Add(myList.Add(elemntsToAdd[i]));
            }

            int amountOfRemoveOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfRemoveOperations; i++)
            {
                AddRemoveCollectionRemoves.Add(addRemoveCollection.Remove());
                myListRemoves.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(' ', addCollectionOperations));
            Console.WriteLine(string.Join(' ', addRemoveCollectionOperations));
            Console.WriteLine(string.Join(' ', myListOperations));
            Console.WriteLine(string.Join(' ', AddRemoveCollectionRemoves));
            Console.WriteLine(string.Join(' ', myListRemoves));
        }
    }
}

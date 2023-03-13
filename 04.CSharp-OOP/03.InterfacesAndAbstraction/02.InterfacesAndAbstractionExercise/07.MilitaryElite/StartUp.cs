using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new();

            string input = Console.ReadLine();

            while (input != "End")
            {
                Queue<string> infoAboutSoldier = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
                string rank = infoAboutSoldier.Dequeue();
                string id = infoAboutSoldier.Dequeue();
                string firstName = infoAboutSoldier.Dequeue();
                string lastName = infoAboutSoldier.Dequeue();

                switch (rank)
                {
                    case "Private":
                        decimal salary = decimal.Parse(infoAboutSoldier.Dequeue());
                        soldiers.Add(new Private(id, firstName, lastName, salary));
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(infoAboutSoldier.Dequeue());
                        var soldier = new LieutenantGeneral(id, firstName, lastName, salary);

                        soldiers.Add(soldier);

                        for (int i = infoAboutSoldier.Count; i >= 0; i--)
                        {
                            string currId = infoAboutSoldier.Dequeue();

                            Private currPrivate = soldiers.A(s => s.Id == currId);
                            if (soldiers.Any(s => s.Id == currId))
                            {
                                soldier.AddPrivate(soldier);
                            }
                        }

                        break;
                    case "Engineer":
                        salary = decimal.Parse(infoAboutSoldier[4]);
                        string corps = infoAboutSoldier[5];

                        if (corps != "Airforces" && corps != "Marines")
                        {
                            continue;
                        }

                        soldiers.Add(new Engineer(id, firstName, lastName, salary, corps));
                        break;
                    case "Commando":
                        salary = decimal.Parse(infoAboutSoldier[4]);
                        corps = infoAboutSoldier[5];

                        if (corps != "Airforces" && corps != "Marines")
                        {
                            continue;
                        }

                        soldiers.Add(new Commando(id, firstName, lastName, salary, corps));
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(infoAboutSoldier[4]);
                        soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                        break; 
                }

                input = Console.ReadLine();
            }
        }
    }
}

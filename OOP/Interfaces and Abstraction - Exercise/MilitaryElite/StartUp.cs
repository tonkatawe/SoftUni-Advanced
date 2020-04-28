using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var soldiers = new List<Soldier>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                var tokens = command.Split();
                var soldierType = tokens[0];
                var iD = int.Parse(tokens[1]);
                var firstName = tokens[2];
                var lastName = tokens[3];
                var salary = decimal.Parse(tokens[4]);
                switch (soldierType)
                {
                    case "Private":
                        var newPrivate = new Private(firstName, lastName, iD, salary);
                        Console.WriteLine(newPrivate);
                        soldiers.Add(newPrivate);
                        break;
                    case "LieutenantGeneral":
                        var currentLieutenant = new LieutenantGeneral(firstName, lastName, iD, salary);
                        for (int i = 5; i < tokens.Length; i++)
                        {
                            var currentPrivate = (Private)soldiers.First(s => s.Id == int.Parse(tokens[i]));
                            currentLieutenant.AddPrivate(currentPrivate);
                        }
                        soldiers.Add(currentLieutenant);
                        Console.WriteLine(currentLieutenant);
                        break;
                    case "Commando":
                        var corpsType = tokens[5];
                        var currentCommando = new Commando(firstName, lastName, iD, salary, corpsType);
                        for (int i = 6; i < tokens.Length; i += 2)
                        {
                            if (i + 1 >= tokens.Length)
                            {
                                break;
                            }
                            var name = tokens[i];
                            var state = tokens[i + 1];
                            var mission = new Mission(name, state);
                            currentCommando.AddMission(mission);
                        }
                        soldiers.Add(currentCommando);
                        Console.WriteLine(currentCommando);
                        break;
                    case "Engineer":
                        corpsType = tokens[5];
                        var currentEngineer = new Engineer(firstName, lastName, iD, salary, corpsType);
                        for (int i = 6; i < tokens.Length; i += 2)
                        {
                            if (i + 1 >= tokens.Length)
                            {
                                break;
                            }
                            var part = tokens[i];
                            var hours = int.Parse(tokens[i + 1]);
                            var repair = new Repair(part, hours);
                            currentEngineer.AddRepair(repair);
                        }
                        soldiers.Add(currentEngineer);
                        Console.WriteLine(currentEngineer);
                        break;
                    case "Spy":
                        var currentSpy = new Spy(firstName, lastName, iD);
                        Console.WriteLine(currentSpy);
                        soldiers.Add(currentSpy);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}

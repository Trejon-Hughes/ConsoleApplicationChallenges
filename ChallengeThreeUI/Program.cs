using ChallengeThreeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            BadgeRepo repo = new BadgeRepo();
            do
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("What is the number on the badge:");
                        string badgeID = Console.ReadLine();
                        List<string> doors = new List<string>();
                        Console.Clear();
                        Console.WriteLine("Is there any doors this badge needs access to(y/n)?");
                        string addDoor;
                        do
                        {
                            addDoor = Console.ReadLine().ToLower();
                            switch (addDoor)
                            {
                                case "y":
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("List a door that it needs access to:");
                                        string newDoor = Console.ReadLine();
                                        if (doors.Contains(newDoor))
                                        {
                                            Console.WriteLine("You already entered that door");
                                        }
                                        else
                                        {
                                            doors.Add(newDoor);
                                        }
                                        Console.WriteLine("Any other doors(y/n)?");
                                        addDoor = Console.ReadLine().ToLower();
                                        switch (addDoor)
                                        {
                                            case "y":
                                                break;
                                            case "n":
                                                break;
                                            default:
                                                do
                                                {
                                                    Console.WriteLine("Please enter y or n");
                                                    addDoor = Console.ReadLine().ToLower();
                                                } while (addDoor != "n" && addDoor != "y");
                                                break;
                                        }
                                    } while (addDoor != "n");
                                    break;
                                case "n":
                                    break;
                                default:
                                    Console.WriteLine("Please enter y or n");
                                    break;
                            }
                        } while (addDoor != "y" && addDoor != "n");
                        doors.Sort();
                        Badges badge = new Badges(badgeID, doors);
                        Console.Clear();
                        if (repo.AddBadge(badge))
                        {
                            Console.WriteLine($"Badge# {badgeID} added");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"Badge# {badgeID} already exists. Maybe try updating it?");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("What is the badge number to update?");
                        badgeID = Console.ReadLine();
                        string badgeEdit = "0";
                        do
                        {
                            if (repo.ShowBadge(badgeID))
                            {
                                Console.WriteLine("What would you like to do?\n" +
                                    "1. Remove a door\n" +
                                    "2. Add a door\n" +
                                    "3. Remove all doors\n" +
                                    "4. Exit");
                                badgeEdit = Console.ReadLine();
                                switch (badgeEdit)
                                {
                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine("What door would you like to remove?");
                                        string door = Console.ReadLine();
                                        repo.RemoveDoor(badgeID, door);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        Console.Clear();
                                        Console.WriteLine("What door would you like to add?");
                                        door = Console.ReadLine();
                                        repo.AddDoor(badgeID, door);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case "3":
                                        Console.Clear();
                                        repo.DeleteAllDoors(badgeID);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case "4":
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Please enter a number betwen 1-4");
                                        break;
                                }
                            }
                            else
                            {
                                badgeEdit = "4";
                            }
                        } while (badgeEdit != "4");
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        repo.ShowAllBadges();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a number between 1-4");
                        break;
                }
            } while (userInput != "4");
        }
    }
}

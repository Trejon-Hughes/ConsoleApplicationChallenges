using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class BadgeRepo
    {
        Dictionary<string, List<string>> badgeDictionary = new Dictionary<string, List<string>>();

        public bool AddBadge(Badges badge)
        {
            if (badgeDictionary.ContainsKey(badge.BadgeID))
            {
                return false;
            }
            else
            {
                badgeDictionary.Add(badge.BadgeID, badge.DoorAccess);
                return true;
            }

        }

        public bool ShowAllBadges()
        {
            if (badgeDictionary.Count > 0)
            {
                Console.WriteLine("Badge#      Door Access");
                foreach (KeyValuePair<string, List<string>> badge in badgeDictionary)
                {
                    Console.Write($"{badge.Key}      ");
                    foreach (string door in badge.Value)
                    {
                        Console.Write($"{door}|");
                    }
                    Console.WriteLine();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ShowBadge(string badgeNumber)
        {
            if (badgeDictionary.ContainsKey(badgeNumber))
            {
                if (badgeDictionary[badgeNumber].Count > 0)
                {
                    Console.Write($"Badge# {badgeNumber} has access to door(s) ");
                    foreach (string door in badgeDictionary[badgeNumber])
                    {
                        Console.Write($"{door}|");

                    }
                }
                else
                {
                    Console.WriteLine("This badge has no door access.");
                }
                return true;
            }
            else
            {
                Console.WriteLine("There is no badge with that ID");
                return false;
            }
        }

        public bool AddDoor(string badgeNumber, string door)
        {
            if (badgeDictionary.ContainsKey(badgeNumber))
            {
                if (badgeDictionary[badgeNumber].Contains(door))
                {
                    Console.WriteLine("That door already exists");
                    return false;
                }
                else
                {
                    badgeDictionary[badgeNumber].Add(door);
                    badgeDictionary[badgeNumber].Sort();
                    Console.WriteLine($"Door {door} was added to Badge# {badgeNumber}");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("There is no badge with that ID");
                return false;
            }
        }

        public bool RemoveDoor(string badgeNumber, string door)
        {
            if (badgeDictionary.ContainsKey(badgeNumber))
            {
                if (badgeDictionary[badgeNumber].Count > 0)
                {
                    if (badgeDictionary[badgeNumber].Contains(door))
                    {
                        foreach (string doors in badgeDictionary[badgeNumber].ToList())
                        {
                            if (doors == door)
                            {
                                badgeDictionary[badgeNumber].RemoveAt(badgeDictionary[badgeNumber].IndexOf(door));
                                Console.WriteLine("Door Removed");
                            }
                        }
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("There is no door with that number for this badge");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("This badge has no door access.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("There is no badge with that ID");
                return false;
            }
        }

        public bool DeleteAllDoors(string badgeNumber)
        {
            if (badgeDictionary.ContainsKey(badgeNumber))
            {
                if (badgeDictionary[badgeNumber].Count > 0)
                {
                    badgeDictionary[badgeNumber].Clear();
                    Console.WriteLine("All Doors Removed");
                }
                else
                {
                    Console.WriteLine("This badge has no door access.");
                }
                return true;
            }
            else
            {
                Console.WriteLine("There is no badge with that ID");
                return false;
            }
        }
    }
}

using ChallengeFourRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            OutingRepo repo = new OutingRepo();
            do
            {
                Console.WriteLine("Please choose a menu item\n" +
                    "1. Display a list of all outings\n" +
                    "2. Add outing\n" +
                    "3. Cost Statistics\n" +
                    "4. Exit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        repo.DisplayAll();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Please enter the event type (Golf, Bowling, Amusement Park, Concert)");
                        string eventSTR;
                        Outing.Events events = Outing.Events.Golf;
                        do
                        {
                            eventSTR = Console.ReadLine().ToLower().Replace(" ", "");
                            switch (eventSTR)
                            {
                                case "golf":
                                    events = Outing.Events.Golf;
                                    break;
                                case "bowling":
                                    events = Outing.Events.Bowling;
                                    break;
                                case "amusementpark":
                                    events = Outing.Events.AmusementPark;
                                    break;
                                case "concert":
                                    events = Outing.Events.Concert;
                                    break;
                                default:
                                    Console.WriteLine("Please enter one of the options");
                                    break;
                            }
                        } while (eventSTR != "golf" && eventSTR != "bowling" && eventSTR != "amusementpark" && eventSTR != "concert");
                        Console.Clear();
                        Console.WriteLine("Please enter the number of people that attended");
                        int numberAttended;
                        bool isNumber;
                        do
                        {
                            if (int.TryParse(Console.ReadLine(), out numberAttended))
                            {
                                isNumber = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a whole number");
                                isNumber = false;
                            }
                        } while (!isNumber);
                        Console.Clear();
                        Console.WriteLine("Please enter the date of the event (Format MM/DD/YY)");
                        DateTime date;
                        bool isDate;
                        do
                        {
                            if (DateTime.TryParse(Console.ReadLine(), out date))
                            {
                                isDate = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a date with the correct format");
                                isDate = false;
                            }
                        } while (!isDate);
                        Console.Clear();
                        Console.WriteLine("Please enter the cost per person for the event.");
                        decimal costPerPerson;
                        bool isCost;
                        do
                        {
                            string costSTR = Console.ReadLine().Replace("$", "");
                            decimal.TryParse(costSTR, out costPerPerson);
                            if (decimal.Round(costPerPerson, 2) != costPerPerson || costSTR != Convert.ToString(costPerPerson))
                            {
                                Console.WriteLine("Please enter a valid number");
                                isCost = false;
                            }
                            else
                            {
                                isCost = true;
                            }
                        } while (!isCost);
                        Console.Clear();
                        Outing outing = new Outing(events, numberAttended, date, costPerPerson);
                        repo.AddOuting(outing);
                        Console.WriteLine("Outing added.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        repo.CombinedCosts();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Please choose a number between 1-4");
                        break;
                }

            } while (userInput != "4");
        }
    }
}

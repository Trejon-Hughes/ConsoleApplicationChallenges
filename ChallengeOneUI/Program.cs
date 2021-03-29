using ChallengeOneRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChallengeOneRepo.MenuRepo;

namespace ChallengeOneUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuRepo menu = new MenuRepo();
            string userSelection;
            bool itemRemoved;
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter 1 to add a meal, enter 2 to remove a meal, enter 3 to list all meals, and enter 4 to exit");
                userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        Console.Clear();
                        bool newNumber = true;
                        List<string> ingredientList = new List<string>();
                        Console.WriteLine("Please enter the number for the meal");
                        string mealNumber = Console.ReadLine();
                        if (menu.menu.Count > 0)
                        {
                            do
                            {
                                foreach (Menu item in menu.menu)
                                {
                                    if (item.MealNumber == mealNumber)
                                    {
                                        Console.WriteLine("That meal number is already taken, please enter another one.");
                                        newNumber = false;
                                        mealNumber = Console.ReadLine();
                                    }
                                    else
                                    {
                                        newNumber = true;
                                    }
                                }
                            } while (!newNumber);
                        }
                        Console.WriteLine("Please enter the name of the meal");
                        string mealName = Console.ReadLine();
                        Console.WriteLine("Please enter a description for the meal");
                        string description = Console.ReadLine();
                        Console.WriteLine("Please enter the ingredients for the meal one at a time, and enter 2 when finished");
                        string ingredients = Console.ReadLine();
                        while (ingredients != "2")
                        {
                            ingredientList.Add(ingredients);
                            Console.WriteLine("Added!");
                            ingredients = Console.ReadLine();
                        }
                        Console.WriteLine("Please enter the price of the meal");
                        string price = Console.ReadLine();
                        menu.NewItem(mealNumber, mealName, description, ingredientList, price);
                        break;
                    case "2":
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("Please enter the meal number of the item you want to remove or type Exit to leave");
                            string itemToRemove = Console.ReadLine();
                            if (itemToRemove.ToLower() == "exit")
                            {
                                itemRemoved = true;
                            }
                            else
                            {
                                itemRemoved = menu.DeleteItem(itemToRemove);
                            }  
                        } while (!itemRemoved);
                        break;
                    case "3":
                        menu.ShowMenu();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("You did not enter a number between 1-4");
                        break;
                }
            } while (userSelection != "4");
        }
    }
}

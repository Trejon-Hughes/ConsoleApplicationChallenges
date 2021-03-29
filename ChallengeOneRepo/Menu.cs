﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepo
{
    public class Menu
    {
        public string MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public string Price { get; set; }

        public Menu()
        {

        }

        public Menu(string mealNumber, string mealName, string description, List<string> ingredients, string price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }

    public class MenuRepo
    {
        public List<Menu> menu = new List<Menu>();

        public void NewItem(string mealNumber, string mealName, string description, List<string> ingredientList, string price)
        {
            Menu menuItem = new Menu(mealNumber, mealName, description, ingredientList, price);
            menu.Add(menuItem);
        }

        public bool ShowMenu()
        {
            foreach (Menu item in menu)
            {
                Console.WriteLine($"Number: {item.MealNumber} Name: {item.MealName} Description: {item.Description} Price: {item.Price}");
            }
            return true;
        }

        public bool DeleteItem(string itemToRemove)
        {
            bool itemRemoved = false;
            foreach (Menu item in menu.ToList())
            {
                if (itemToRemove == item.MealNumber)
                {
                    menu.Remove(item);
                    itemRemoved = true;
                }
            }
            if (!itemRemoved)
            {
                Console.WriteLine("No meal with that number exists");
            }
            return itemRemoved;
        }
    }
}

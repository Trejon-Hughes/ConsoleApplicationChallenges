using ChallengeOneRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static ChallengeOneRepo.MenuRepo;

namespace ChallengeOneUnitTest
{

    [TestClass]
    public class UnitTest1
    {
        string menuNumber = "1";
        string menuItem = "Banana";
        string description = "Is a Banana";
        string ingredients = "1 banana";
        string price = ".99";
        string firstItemToRemove = "2";

        [TestMethod]
        public void NewItem_AddsItemToList()
        {
            MenuRepo menu = new MenuRepo();
            List<string> ingredientList = new List<string>() { ingredients };
            List<Menu> comparison = new List<Menu>() { new Menu(menuNumber, menuItem, description, ingredientList, price) };
            menu.NewItem(menuNumber, menuItem, description, ingredientList, price);

            Assert.AreEqual(comparison[0].MealNumber, menu.menu[0].MealNumber);
            Assert.AreEqual(comparison[0].MealName, menu.menu[0].MealName);
            Assert.AreEqual(comparison[0].Description, menu.menu[0].Description);
            Assert.AreEqual(comparison[0].Ingredients, menu.menu[0].Ingredients);
            Assert.AreEqual(comparison[0].Price, menu.menu[0].Price);
        }
        //Everything relies on user input and the worse part is I KNOW everything is working I just can't figure out how to write any tests for it. I tried to write an interface for user input and it yelled at me because it exepects an actual console. I'm just putting this here to express my fustration with unit tests and just in case I never get back around to testing for it.
        //I figured out how to do it. Ended up moving most of my logic to Program and left just the functional methods in class.
        [TestMethod]
        public void DeleteItem_RemovesAnItem()
        {
            MenuRepo menu = new MenuRepo();
            List<string> ingredientList = new List<string>() { ingredients };
            menu.NewItem(menuNumber, menuItem, description, ingredientList, price);
            

            Assert.IsFalse(menu.DeleteItem(firstItemToRemove));
            Assert.IsTrue(menu.DeleteItem(menuNumber));
        }

        [TestMethod]
        public void ShowMenu_PrintsMenu()
        {
            MenuRepo menu = new MenuRepo();
            List<string> ingredientList = new List<string>() { ingredients };
            menu.NewItem(menuNumber, menuItem, description, ingredientList, price);

            Assert.IsTrue(menu.ShowMenu());

        }
    }
}

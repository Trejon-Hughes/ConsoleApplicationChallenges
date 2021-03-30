using ChallengeThreeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string badgeID = "1431535";
        List<string> doors = new List<string>() { "A1", "B2", "C3" };
        [TestMethod]
        public void AddBadgeAndShowTest_AddBadgeToListAndShow()
        {
            BadgeRepo repo = new BadgeRepo();
            Badges badge = new Badges(badgeID, doors);

            repo.AddBadge(badge);
            Assert.IsTrue(repo.ShowAllBadges());

        }

        [TestMethod]
        public void DeleteAllDoorsTest_RemovesAllDoors()
        {
            BadgeRepo repo = new BadgeRepo();
            Badges badge = new Badges(badgeID, doors);

            repo.AddBadge(badge);
            Assert.IsTrue(repo.DeleteAllDoors(badgeID));
            repo.ShowAllBadges();
        }

        [TestMethod]
        public void AddDoorsTest_AddDoorToBadge()
        {
            BadgeRepo repo = new BadgeRepo();
            Badges badge = new Badges(badgeID, doors);

            repo.AddBadge(badge);
            Assert.IsTrue(repo.AddDoor(badgeID, "CD21"));
            repo.ShowAllBadges();
        }

        [TestMethod]
        public void RemoveDoorsTest_RemoveDoorFromList()
        {
            BadgeRepo repo = new BadgeRepo();
            Badges badge = new Badges(badgeID, doors);

            repo.AddBadge(badge);
            Assert.IsTrue(repo.RemoveDoor(badgeID, "C3"));
            repo.ShowAllBadges();
        }

        [TestMethod]
        public void ShowBadgeTest_ShowsBadge()
        {
            BadgeRepo repo = new BadgeRepo();
            Badges badge = new Badges(badgeID, doors);

            repo.AddBadge(badge);
            Assert.IsTrue(repo.ShowBadge(badgeID));
        }
    }
}

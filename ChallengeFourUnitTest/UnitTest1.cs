using ChallengeFourRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeFourUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Outing.Events events = Outing.Events.Golf;
        int peopleAttended = 10;
        DateTime date = DateTime.Parse("3/25/97");
        decimal costPerPerson = 3;

        [TestMethod]
        public void AddOutingAndDisplayTest_AddsOutingAndDisplays()
        {
            OutingRepo repo = new OutingRepo();
            Outing outing = new Outing(events, peopleAttended, date, costPerPerson);


            repo.AddOuting(outing);
            Assert.IsTrue(repo.DisplayAll());
        }
        [TestMethod]
        public void CombinedCostTest_ShowsCombinedCostAndIndividualCosts()
        {
            OutingRepo repo = new OutingRepo();
            Outing outing = new Outing(events, peopleAttended, date, costPerPerson);


            repo.AddOuting(outing);
            Assert.IsTrue(repo.CombinedCosts());
        }
    }
}

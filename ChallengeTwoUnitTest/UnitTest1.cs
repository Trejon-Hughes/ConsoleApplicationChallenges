using ChallengeTwoRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeTwoUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string ID = "1";
        Claim.ClaimTypes claimType = Claim.ClaimTypes.Car;
        string description = "description";
        string amount = "10";
        DateTime incident = DateTime.Parse("03/27/97");
        DateTime claim = DateTime.Parse("03/28/97");

        [TestMethod]
        public void TestAddClaimAndSeeClaims_AddClaimToListAndDisplay()
        {
            ClaimRepo repo = new ClaimRepo();
            repo.AddClaim(ID, claimType, description, amount, incident, claim);
            Assert.IsTrue(repo.SeeClaims());
        }

        [TestMethod]
        public void TestNextClaim_DesplaysNextClaimInList()
        {
            ClaimRepo repo = new ClaimRepo();
            repo.AddClaim(ID, claimType, description, amount, incident, claim);
            Assert.IsTrue(repo.ShowNextClaim());
        }

        [TestMethod]
        public void TestRemoveClaim_RemovesTheFirstClaimInList()
        {
            ClaimRepo repo = new ClaimRepo();
            repo.AddClaim(ID, claimType, description, amount, incident, claim);
            repo.RemoveClaim();
            Assert.IsFalse(repo.SeeClaims());
        }
    }
}

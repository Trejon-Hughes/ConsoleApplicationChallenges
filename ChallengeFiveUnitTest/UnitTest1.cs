using ChallengeFiveRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeFiveUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string firstName = "John";
        string lastName = "Wick";
        Customers.CustomerType type = Customers.CustomerType.Past;

        [TestMethod]
        public void CreateAndShowCustomersTest_AddCustomerToListAndShow()
        {
            Customers customer = new Customers(firstName, lastName, type);
            EmailRepo repo = new EmailRepo();

            repo.CreateCustomer(customer);
            repo.CreateCustomer(customer);
            Assert.IsTrue(repo.ShowCustomers());
        }

        [TestMethod]
        public void UpdateCustomerInfoFirstNameTest_UpdatesFirstName()
        {
            Customers customer = new Customers(firstName, lastName, type);
            EmailRepo repo = new EmailRepo();

            repo.CreateCustomer(customer);
            Assert.IsTrue(repo.UpdateCustomerInfo(customer, "1", "Lucus"));
            Assert.IsTrue(repo.ShowCustomers());
        }

        [TestMethod]
        public void UpdateCustomerInfoLastNameTest_UpdatesLastName()
        {
            Customers customer = new Customers(firstName, lastName, type);
            EmailRepo repo = new EmailRepo();

            repo.CreateCustomer(customer);
            Assert.IsTrue(repo.UpdateCustomerInfo(customer, "2", "Lucus"));
            Assert.IsTrue(repo.ShowCustomers());
        }

        [TestMethod]
        public void UpdateCustomerInfoTypeTest_UpdatesType()
        {
            Customers customer = new Customers(firstName, lastName, type);
            EmailRepo repo = new EmailRepo();

            repo.CreateCustomer(customer);
            Assert.IsTrue(repo.UpdateCustomerInfo(customer, "3", "potential"));
            Assert.IsTrue(repo.ShowCustomers());
        }

        [TestMethod]
        public void UpdateCustomerInfoRemoveTest_RemovesCustomer()
        {
            Customers customer = new Customers(firstName, lastName, type);
            EmailRepo repo = new EmailRepo();

            repo.CreateCustomer(customer);
            Assert.IsTrue(repo.UpdateCustomerInfo(customer, "4", ""));
            Assert.IsFalse(repo.ShowCustomers());
        }
    }
}

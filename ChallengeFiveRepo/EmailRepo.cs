using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{
    public class EmailRepo
    {
        List<Customers> customers = new List<Customers>();

        public void CreateCustomer(Customers customer)
        {
            customers.Add(customer);
            customers.Sort();
        } 

        public bool ShowCustomers()
        {
            if (customers.Count > 0)
            {
                foreach (Customers customer in customers)
                {
                    Console.WriteLine($"First Name: {customer.FirstName}\n" +
                        $"Last Name: {customer.LastName}\n" +
                        $"Type: {customer.Type}\n" +
                        $"Email: {customer.Email}\n");
                }
                return true;
            }
            else
            {
                Console.WriteLine("There are no customers currently added");
                return false;
            }
        }

        public List<Customers> GetCustomer(string firstName, string lastName)
        {
            List<Customers> retrivedCustomers = new List<Customers>();
            foreach (Customers customer in customers)
            {
                if (customer.FirstName == firstName && customer.LastName == lastName)
                {
                    retrivedCustomers.Add(customer);
                }
            }
            return retrivedCustomers;
        }

        public bool UpdateCustomerInfo(Customers customer, string option, string change)
        {
            switch (option)
            {
                case "1":
                    customer.FirstName = change;
                    return true;
                case "2":
                    customer.LastName = change;
                    return true;
                case "3":
                    Customers.CustomerType type = Customers.CustomerType.Potential;
                    switch (change)
                    {
                        case "potential":
                            type = Customers.CustomerType.Potential;
                            break;
                        case "current":
                            type = Customers.CustomerType.Current;
                            break;
                        case "past":
                            type = Customers.CustomerType.Past;
                            break;
                    }
                    customer.Type = type;
                    return true;
                case "4":
                    customers.Remove(customer);
                    return true;
                default:
                    return false;
            }
        }
    }
}

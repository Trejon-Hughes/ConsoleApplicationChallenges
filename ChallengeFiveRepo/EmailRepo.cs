using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{
    class EmailRepo
    {
        List<Customers> customers = new List<Customers>();

        public void CreateCustomer(Customers customer)
        {
            customers.Add(customer);
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

        public bool UpdateCustomerInfo(string option)
        {
            switch (option)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }
    }
}

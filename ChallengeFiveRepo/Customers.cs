using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{
    public class Customers
    {
        public enum CustomerType { Potential, Current, Past}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
        public string Email
        {
            get
            {
                switch (Type)
                {
                    case CustomerType.Current:
                        return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    case CustomerType.Potential:
                        return "We currently have the lowest rates on Helicopter Insurance!";
                    case CustomerType.Past:
                        return "It's been a long time since we've heard from you, we want you back.";
                    default:
                        return "";
                }
            }
        }

        public Customers()
        {

        }

        public Customers(string firstName, string lastName, CustomerType type)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }
    }
}

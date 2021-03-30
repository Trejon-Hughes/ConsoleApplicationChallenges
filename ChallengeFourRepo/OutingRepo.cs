using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourRepo
{
    class OutingRepo
    {
        List<Outing> outings = new List<Outing>();

        public bool DisplayAll()
        {
            if (outings.Count > 0)
            {
                foreach (Outing outing in outings)
                {
                    Console.WriteLine($"{outing.EventType}    {outing.PeopleAttended}    {outing.Date}    {outing.CostPerPerson}    {outing.CostPerPerson}");
                }
                return true;
            }
            else
            {
                Console.WriteLine("There are no outings listed");
                return false;
            }
        }

        public void AddOuting(Outing outing)
        {
            outings.Add(outing);
        }

        public bool CombinedCosts()
        {
            if (outings.Count > 0)
            {
                double golfCost = 0;
                double bowlingCost = 0;
                double amusementCost = 0;
                double concertCost = 0;
                double totalCost = 0;
                foreach (Outing outing in outings)
                {
                    switch (outing.EventType)
                    {
                        case Outing.Events.Golf:
                            golfCost += outing.CostForEvent;
                            break;
                        case Outing.Events.Bowling:
                            bowlingCost += outing.CostForEvent;
                            break;
                        case Outing.Events.AmusementPark:
                            amusementCost += outing.CostForEvent;
                            break;
                        case Outing.Events.Concert:
                            concertCost += outing.CostForEvent;
                            break;
                    }
                }
                totalCost = golfCost + bowlingCost + amusementCost + concertCost;
                Console.WriteLine($"Your total cost is: ${}");
            }
        }
    }
}

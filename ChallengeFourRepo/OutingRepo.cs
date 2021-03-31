using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourRepo
{
    public class OutingRepo
    {
        List<Outing> outings = new List<Outing>();

        public bool DisplayAll()
        {
            if (outings.Count > 0)
            {
                foreach (Outing outing in outings)
                {
                    Console.WriteLine($"Event Type: {outing.EventType}\n" +
                        $"People Attended: {outing.PeopleAttended}\n" +
                        $"Date: {outing.Date.ToShortDateString()}\n" +
                        $"Cost Per Person: ${outing.CostPerPerson}\n" +
                        $"Cost For Event: ${outing.CostForEvent}\n");
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
                decimal golfCost = 0;
                decimal bowlingCost = 0;
                decimal amusementCost = 0;
                decimal concertCost = 0;
                decimal totalCost = 0;
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
                Console.WriteLine($"Your total cost is: ${totalCost.ToString("F")}\n" +
                    $"Golf outings: ${golfCost.ToString("F")}\n" +
                    $"Bowling outings: ${bowlingCost.ToString("F")}\n" +
                    $"Amusement Park outings: ${amusementCost.ToString("F")}\n" +
                    $"Concert outings: ${concertCost.ToString("F")}");
                return true;
            }
            else
            {
                Console.WriteLine("There are no outings listed");
                return false;
            }
        }
    }
}

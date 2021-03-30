using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourRepo
{
    public class Outing
    {
        public enum Events { Golf, Bowling, AmusementPark, Concert };
        public Events EventType { get; set; }
        public int PeopleAttended { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double CostForEvent
        {
            get
            {
                return CostPerPerson * PeopleAttended;
            }
        }

        public Outing()
        {

        }

        public Outing(Events eventType, int peopleAttended, DateTime date, double costPerPerson)
        {
            EventType = eventType;
            PeopleAttended = peopleAttended;
            Date = date;
            CostPerPerson = costPerPerson;
        }
    }
}

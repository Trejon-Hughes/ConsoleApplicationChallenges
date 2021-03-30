using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class Badges
    {
        public string BadgeID { get; }
        public List<string> DoorAccess { get; set; }

        public Badges()
        {

        }

        public Badges(string badgeID, List<string> doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;
        }
    }
}

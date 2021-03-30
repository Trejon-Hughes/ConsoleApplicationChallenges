using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepo
{
    public class Claim
    {
        public enum ClaimTypes {Car, Home, Theft }
        public string ClaimID { get; set; }
        public ClaimTypes ClaimType { get; set; }
        public string Description { get; set; }
        public string ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan timeSpan = DateOfClaim - DateOfIncident;
                if (timeSpan.TotalDays > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Claim()
        {

        }

        public Claim(string claimID, ClaimTypes claimType, string description, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}

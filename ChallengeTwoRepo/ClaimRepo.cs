using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepo
{
    public class ClaimRepo
    {
        List<Claim> claims = new List<Claim>();
        
        public bool SeeClaims()
        {

            if (claims.Count > 0)
            {
                foreach (Claim claim in claims)
                {
                    Console.WriteLine($"ClaimID: {claim.ClaimID} |Type: {claim.ClaimType} |Description: {claim.Description} |Amount: ${double.Parse(claim.ClaimAmount).ToString("F")} |DateOfAccident: {claim.DateOfIncident.ToShortDateString()} |DateOfClaim: {claim.DateOfClaim.ToShortDateString()} |IsValid: {claim.IsValid}");
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ShowNextClaim()
        {
            if (claims.Count > 0)
            {
                Console.WriteLine($"ClaimID: {claims[0].ClaimID}\n" +
                    $"Type: {claims[0].ClaimType}\n" +
                    $"Amount: ${double.Parse(claims[0].ClaimAmount).ToString("F")}\n" +
                    $"DateOfAccident: {claims[0].DateOfIncident.ToShortDateString()}\n" +
                    $"DateOfClaim: {claims[0].DateOfClaim.ToShortDateString()}\n" +
                    $"IsValid: {claims[0].IsValid}\n");
                return true;
            }
            else
            {
                return false;
            }

        }

        public void RemoveClaim()
        {
            claims.RemoveAt(0);
        }

        public void AddClaim(string claimID, Claim.ClaimTypes claimType, string description, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            claims.Add(new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim));
        }
    }
}

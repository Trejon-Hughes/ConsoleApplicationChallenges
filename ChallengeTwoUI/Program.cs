using ChallengeTwoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimRepo repo = new ClaimRepo();
            string userInput;
            string claimInput;
            string claimTypeSTR;
            bool validClaimType;
            bool validDamageNumber;
            bool successfulAccident;
            bool successfulClaim;
            DateTime accidentDate;
            DateTime claimDate;

            do
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4. Exit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        if (repo.SeeClaims())
                        {
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There are no claims. Press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        if (repo.ShowNextClaim())
                        {
                            do
                            {
                                Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                                claimInput = Console.ReadLine().ToLower();
                                switch (claimInput)
                                {
                                    case "y":
                                        repo.RemoveClaim();
                                        break;
                                    case "n":
                                        break;
                                    default:
                                        Console.WriteLine("Please enter y or n");
                                        break;
                                }
                            } while (claimInput != "n" && claimInput != "y");
                        }
                        else
                        {
                            Console.WriteLine("There are no claims. Press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Please enter the ClaimID");
                        string claimID = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Please enter the claim type: Car, Home, or Theft");
                        ChallengeTwoRepo.Claim.ClaimTypes claimType = ChallengeTwoRepo.Claim.ClaimTypes.Car;
                        do
                        {
                            claimTypeSTR = Console.ReadLine().ToLower();
                            switch (claimTypeSTR)
                            {
                                case "car":
                                    claimType = ChallengeTwoRepo.Claim.ClaimTypes.Car;
                                    validClaimType = true;
                                    break;
                                case "home":
                                    claimType = ChallengeTwoRepo.Claim.ClaimTypes.Home;
                                    validClaimType = true;
                                    break;
                                case "theft":
                                    claimType = ChallengeTwoRepo.Claim.ClaimTypes.Theft;
                                    validClaimType = true;
                                    break;
                                default:
                                    Console.WriteLine("Please enter Car, Home, or Theft");
                                    validClaimType = false;
                                    break;
                            }
                        } while (!validClaimType);
                        Console.Clear();
                        Console.WriteLine("Please enter a claim description");
                        string description = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Please enter the amount of Damage");
                        string damage;
                        do
                        {
                            damage = Console.ReadLine().Replace("$", "");
                            decimal decimalCheck;
                            decimal.TryParse(damage, out decimalCheck);
                            if (decimal.Round(decimalCheck, 2) != decimalCheck || damage != Convert.ToString(decimalCheck))
                            {
                                Console.WriteLine("Please enter a valid number");
                                validDamageNumber = false;
                            }
                            else
                            {
                                validDamageNumber = true;
                            }
                        } while (!validDamageNumber);
                        Console.Clear();
                        Console.WriteLine("Please enter the date of the accident. Format MM/DD/YY");
                        do
                        {
                            string accidentDateSTR = Console.ReadLine();
                            successfulAccident = DateTime.TryParse(accidentDateSTR, out accidentDate);
                            if (successfulAccident)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid date");
                            }
                        } while (!successfulAccident);
                        Console.Clear();
                        Console.WriteLine("Please enter the date of the claim. Format MM/DD/YY");
                        do
                        {
                            string claimDateSTR = Console.ReadLine();
                            successfulClaim = DateTime.TryParse(claimDateSTR, out claimDate);
                            if (successfulClaim)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid date");
                            }
                        } while (!successfulAccident);
                        Console.Clear();
                        repo.AddClaim(claimID, claimType, description, damage, accidentDate, claimDate);
                        ChallengeTwoRepo.Claim preview = new ChallengeTwoRepo.Claim(claimID, claimType, description, damage, accidentDate, claimDate);
                        Console.WriteLine($"ClaimID: {preview.ClaimID}\n" +
                        $"Type: {preview.ClaimType}\n" +
                        $"Amount: ${double.Parse(preview.ClaimAmount).ToString("F")}\n" +
                        $"DateOfAccident: {preview.DateOfIncident.ToShortDateString()}\n" +
                        $"DateOfClaim: {preview.DateOfClaim.ToShortDateString()}");
                        if (preview.IsValid)
                        {
                            Console.WriteLine("This claim is valid.");
                        }
                        else
                        {
                            Console.WriteLine("This claim is not valid");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Please enter a number betwen 1-4");
                        break;
                }
            } while (userInput != "4");
        }
    }
}

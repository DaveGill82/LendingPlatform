using BlackFinch.Lending.Core;
using BlackFinch.Lending.Data;
using BlackFinch.Lending.Data.Entities;
using System;

namespace BlackFinchLendingConsole
{
    internal class Program
    {
        static IDataHelper DataHelper = new DataHelper();
        static IRulesHandler RulesHandler = new RulesHandler();

        static void Main(string[] args)
        {
            ProcessRequest();
        }

        static void ProcessRequest()
        {
            Console.Clear();

            decimal loanAmount = -1;
            decimal assetValue = -1;
            int creditScore = -1;

            var allApplicants = DataHelper.GetLoanApplicants();

            // Get application stats
            var successfulCount = allApplicants.Count(x => x.IsSuccess == true);
            var unSuccessfulCount = allApplicants.Count(x => x.IsSuccess == false);
            var totalLoanValues = allApplicants.FindAll(x => x.IsSuccess == true).Select(x => x.LoanAmount).Sum();

            // Calculate average LTV foe all applications, regardless of whether they are a success
            var averageLtv = allApplicants.Count > 0 ? allApplicants.Select(x => x.LoanToValue).Average() : 0;

            Console.WriteLine("Blackfinch Lending Platform");
            Console.WriteLine();
            Console.WriteLine($"Successful Applications to Date: {successfulCount}");
            Console.WriteLine($"UnSuccessful Applications to Date: {unSuccessfulCount}");
            Console.WriteLine($"Total Loans to Date: {totalLoanValues}");
            Console.WriteLine($"Average LTV: {averageLtv}");
            Console.WriteLine();
            Console.WriteLine("Create a new application");



            Console.WriteLine("Please enter the Loan Amount:");

            var strLoanAmount = Console.ReadLine();

            if (false == decimal.TryParse(strLoanAmount, out loanAmount))
            {
                ResetConsole("You must enter a valid loan amount.");
            }
            else
            {
                Console.WriteLine("Please enter the asset value:");
                var strAssetValue = Console.ReadLine();

                if (false == decimal.TryParse(strAssetValue, out assetValue))
                {
                    ResetConsole("You must enter a valid asset value.");
                }
                else
                {
                    Console.WriteLine("Please enter the credit score:");
                    var strCreditScore = Console.ReadLine();

                    if (false == int.TryParse(strCreditScore, out creditScore))
                    {
                        ResetConsole("You must enter a valid credit score.");
                    }
                    else
                    {
                        //All inputs are valid so create the loan application
                        var loanApplication = new LoanApplicant(loanAmount, assetValue, creditScore);

                        //pass the application to the rules handler to see if it is a successful
                        loanApplication.IsSuccess = RulesHandler.IsApplicationSuccess(loanAmount, assetValue, creditScore, loanApplication.LoanToValue);

                        //Add the application to the database
                        DataHelper.AddApplicant(loanApplication);

                        if (loanApplication.IsSuccess)
                            Console.WriteLine("Application Successful");
                        else
                            Console.WriteLine("Application UnSuccessful");

                        Console.WriteLine();
                        Console.WriteLine("Would you like to create another application (y/n)?");
                        
                        var strContinue = Console.ReadLine();

                        // Does the user want to add another application, if not the app will close
                        if (String.Compare(strContinue, "y", true) == 0)
                            ProcessRequest();
                    }
                }
            }
        }
        static void ResetConsole(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();           
            ProcessRequest();
        }
    }
}
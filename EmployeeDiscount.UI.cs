using System;
using System.Collections.Generic;
using EmployeeDiscountLibrary;
namespace ConsoleEmployeeDiscount_CSharp
{
    class Program
    {

        static void Main(string[] args)
        {
            
            decimal PurchaseSumBeforeDiscount = 0;
            decimal PurchaseSumAfterDiscount = 0;
           
            while (true)
            {    
                bool Switch = true;
                Console.Clear();
                Console.WriteLine("Employee Discount Application" );
                Console.WriteLine("Enter quit if you would like to Exit, or press Enter to Continue");
                string quit = Console.ReadLine();
                if (quit == "Q" || quit == "q" || quit == "quit" )
                { break; }
                bool Option;
                while (true)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine("are you management?");
                    var UserInput = (Console.ReadLine());
                    try
                    {
                        if (UserInput == "yes")
                        {
                            Option = true;
                            break;
                        }
                        else if (UserInput == "no")
                        {
                            Option = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nSorry invalid input let's try that again.");
                        }
                    }
                    catch
                    {
                    }
                }

                int YearsEmployed;
                while (true)
                {
                    Console.WriteLine("Enter years employed ");
                    try
                    {
                        var YearsInput = int.Parse(Console.ReadLine());
                        if (YearsInput <= 0)
                        {
                            Console.WriteLine("\nYou entered a value that was either 0 or below, let's try this again.");
                        }
                        else
                        {
                            YearsEmployed = YearsInput;
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\nYou entered a letter not a number, let's try this again.");
                    }
                }

                decimal SumOfPastPurchases;
                while (true)
                {
                    Console.WriteLine("Enter total amount of your past purchases ");
                    try
                    {
                        var SumOfPastPurchasesInput = decimal.Parse(Console.ReadLine());
                        if (SumOfPastPurchasesInput <= 0)
                        {
                            Console.WriteLine("\nYou entered a value that was either 0 or below, let's try this again.");
                        }
                        else
                        {
                            SumOfPastPurchases = SumOfPastPurchasesInput;
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\nYou entered a letter not a number, let's try this again.");
                    }
                }

                decimal SumOfCurrentPurchase;
                while (true)
                {
                    Console.WriteLine("Enter total amount of your Current purchases ");
                    try
                    {
                        var SumOfCurrentPurchaseInput = decimal.Parse(Console.ReadLine());
                        if (SumOfCurrentPurchaseInput <= 0)
                        {
                            Console.WriteLine("\nYou entered a value that was either 0 or below, let's try this again.");
                        }
                        else
                        {
                            SumOfCurrentPurchase = SumOfCurrentPurchaseInput;
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\nYou entered a letter not a number, let's try this again.");
                    }
                }


                var Account = new EmployeeDiscount(YearsEmployed, SumOfPastPurchases, SumOfCurrentPurchase);
                var EmployeeDiscounts = EmployeeDiscount.GetDiscount(Account.YearsEmployed, Option);
                var YTDdiscount = EmployeeDiscount.GetYTDdiscount(Account.SumOfPastPurchase, EmployeeDiscounts);
                var CurrentDiscount = EmployeeDiscount.getCurrentDiscount(Account.SumOfCurrentPurchase, EmployeeDiscounts);
                var SumOfDiscounts = EmployeeDiscount.getSumOfAllDiscounts(YTDdiscount, CurrentDiscount);
                var TodaysPurchaseDiscount = EmployeeDiscount.getCurrentPurchaseDiscount(SumOfDiscounts, CurrentDiscount, YTDdiscount);
                var TodaysPurchasePrice = EmployeeDiscount.getTodaysPurchasePrice(Account.SumOfCurrentPurchase, TodaysPurchaseDiscount);
                var SumOfAllEmployeePriceBeforeDiscount = TodaysPurchasePrice;
                Console.WriteLine("\n------------------------------------------------------");
                Console.WriteLine($"Employee discount percentage is {EmployeeDiscounts}");
                Console.WriteLine($"YTD Amount of discount in USD {YTDdiscount.ToString("C")}");
                Console.WriteLine($"Total Amount of today's purchase is { Account.SumOfCurrentPurchase.ToString("C")}");
                Console.WriteLine($"Todays purchase discount is {TodaysPurchaseDiscount.ToString("C")}");
                Console.WriteLine($"Todays total purchase price is {TodaysPurchasePrice.ToString("C")}");
                PurchaseSumBeforeDiscount = PurchaseSumBeforeDiscount + Account.SumOfCurrentPurchase;
                PurchaseSumAfterDiscount = PurchaseSumAfterDiscount + TodaysPurchasePrice;
                Console.WriteLine("\n-------------------------------------------------------------------------------");
                Console.WriteLine($"The Sum of all Purchases today before a discount is {PurchaseSumBeforeDiscount.ToString("C")}");
                Console.WriteLine($"The sum of all purchases today after a discount  is {PurchaseSumAfterDiscount.ToString("C")}");



                Console.WriteLine("\nAnother Employee (yes/no)?");
                string OpInput = Console.ReadLine();
               
                if (OpInput == "yes" || OpInput == "Yes" || OpInput == "y" || OpInput == "Y")
                {
                    Switch = true;
                }
                else if (OpInput == "no" || OpInput == "No" || OpInput == "n" || OpInput == "N")
                {
                    Console.WriteLine("\nGood-Bye!");
                    break;
                }
                

            }
      

        }


        
    }
}

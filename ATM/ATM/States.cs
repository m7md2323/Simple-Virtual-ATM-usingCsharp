using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class States
    {
        static ATMDataBase dataBase = new ATMDataBase();
        static Customer customers = new Customer();
        static public void loadFrontScreen()
        {
            for (int i = 0; i < 210; i++)
            {
                Write("#");
            }
            // Console.WriteLine();
            WriteLine(
                "                                                                 " +
                "###################--" +
                "HELLO AND WELCOME TO OUR ATM" +
                "--###################"
                );
        }

        static public void logInScreen()
        {
            WriteLine("PLEASE ENTER YOUR CUSTOMER-ID WITH YOUR PIN (IF YOU DONT HAVE AN ACCOUNT TYPE 1)");
            Write("CUSTOMER-ID : ");
            int customerID;
            //exception handling for the case of entering a string instead of a number
            try
            { 
                customerID = Convert.ToInt32(ReadLine()); 
            }
            catch (FormatException)
            {
                WriteLine("INVALID CUSTOMER-ID PLEASE ENTER A NUMBER");
                System.Threading.Thread.Sleep(2000);
                Clear();
                logInScreen();
                return;
            }
            //handling the case of new customer
            if (customerID == 1)
            {
                customers.BuildNewAccount();
                dataBase.sentDataToDataBase(customers.CustomerID, customers.CustomerPIN, customers.FullName());
                dataBase.updateAccountBalance(customers.CustomerID, 100);
            }
            //handling the case of existing customer
            else
            {
                Write("YOUR PIN NUMBER : ");
                int PIN;
                //exception handling for the case of entering a string instead of a number
                try
                {
                    PIN = Convert.ToInt32(ReadLine());
                }
                catch (FormatException)
                {
                    WriteLine("INVALID PIN PLEASE ENTER A NUMBER");
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    logInScreen();
                    return;
                }
                //handling the case of wrong customerID or PIN
                if (dataBase.CustomerValidator(customerID, PIN) != (byte)validatorKeys.PASS)
                {
                    System.Threading.Thread.Sleep(2500);
                    Clear();
                    logInScreen();
                }
                //handling the case of correct customerID and PIN
                else
                {
                    customers.CustomerID = customerID;
                    customers.CustomerPIN = PIN;
                    Console.WriteLine($"WELCOME MR {dataBase.CustomerID_Name[customerID].ToUpper()} TO OUR ATM");
                }
            }
        }

        static public void Menu()
        {
            //layouts
            WriteLine
            (
                "####################################################################################################" +
                "--MENU--" +
                "####################################################################################################"
            );
            WriteLine
            (
                "TO WITHDRAWN MONEY PRESS (1)\n" +
                "FOR ACCOUNT BALANCE PRESS (2)\n" +
                "TO DEPOSIT MONEY PRESS (3)\n" +
                "TO QUIT AND LOGOUT PRESS (0)"
            );
            //handling the menu selection
            int menuSelection;
            //exception handling for the case of entering a string instead of a number
            try
            {
                menuSelection = Convert.ToInt32(ReadLine());
            }
            catch (FormatException)
            {
                WriteLine("INVALID SELECTION PLEASE ENTER A NUMBER");
                System.Threading.Thread.Sleep(2000);
                Clear();
                Menu();
                return;
            }
            int amount;
            //handling the case of withdrawing money
            if (menuSelection == 1)
            {
                WriteLine("ENTER THE AMOUNT OF MONEY YOU WANT TO WITHDRAWN (NO MORE THAN 1000$)");
                
                //exception handling for the case of entering a string instead of a number
                try
                {
                    amount = Convert.ToInt32(ReadLine());
                }
                catch (FormatException)
                {
                    WriteLine("INVALID AMOUNT PLEASE ENTER A NUMBER");
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    Menu();
                    return;
                }
                if (amount >= 1 && amount <= 1000)
                {
                    if (amount <= dataBase.AccountBalance(customers.CustomerID))
                    {
                        dataBase.updateAccountBalance(customers.CustomerID, -amount);
                        WriteLine("WITHDRAWN PROSEESS WENT SUCCESSFULLY, THANKS FOR USING OUR ATM");
                    }
                    else WriteLine("NOT ENOGH BALANCE!!");
                }
                else 
                { 
                    WriteLine("INVALID AMOUNT PLEASE ENTER A NUMBER BETWEEN 1 AND 1000 !!");
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    Menu();
                }
            }
            //handling the case of checking account balance
            else if (menuSelection == 2)
            {
                Write("YOUR ACCOUNT BALANCE IS : ");
                WriteLine(dataBase.AccountBalance(customers.CustomerID) + "$");
                WriteLine("TO GET BACK TO MENU PRESS (1)\nTO QUIT PRESS (2)");
                if (Convert.ToInt16(ReadLine()) == 1) { Clear(); Menu(); }
                return;
            }
            //handling the case of depositing money
            else if (menuSelection == 3)
            {
                WriteLine("ENTER THE AMOUNT OF MONEY YOU WANT TO DEPOSIT (NO MORE THAN 500$)");
                //exception handling for the case of entering a string instead of a number
                try
                {
                    amount = Convert.ToInt32(ReadLine());
                }
                catch (FormatException)
                {
                    WriteLine("INVALID AMOUNT PLEASE ENTER A NUMBER");
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    Menu();
                    return;
                }
                //handling the case if the amount is between 1 and 500
                if (amount >= 1 && amount <= 500)
                {
                    dataBase.updateAccountBalance(customers.CustomerID, amount);
                    WriteLine("DEPOSIT PROSEESS WENT SUCCESSFULLY, THANKS FOR USING OUR ATM");
                }
                //handling the case if the amount is not valid
                else
                {
                    WriteLine("INVALID AMOUNT PLEASE ENTER A NUMBER BETWEEN 1 AND 500 !!");
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    Menu();
                }
            }
            //handling the case of quiting
            else if (menuSelection == 0)
            {
                WriteLine("QUITING!!....."); return;
            }
            //handling the case of invalid selection
            else
            {
                WriteLine("INVALID SELECTION (PLEASE ENTER 1,2,3,0 AS SHOWN)");
                //Make the user wait for 2 seconds before clearing the screen
                System.Threading.Thread.Sleep(2000);
                Clear();
                //Make the user enter the menu selection again
                Menu();
            }

        }
    }
}

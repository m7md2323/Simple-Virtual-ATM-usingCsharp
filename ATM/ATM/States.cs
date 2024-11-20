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
        private static ATMDataBase dataBase = new ATMDataBase();
        private static Customer customers = new Customer();
        static public void loadFrontScreen()
        {
            UserMessages.Instance.WriteLayout(Layout_Messages.FULL_LINE);
            UserMessages.Instance.WriteLayout(Layout_Messages.FRONT_SCREEN);
        }

        static public void logInScreen()
        {
            UserMessages.Instance.WriteLayout(Layout_Messages.LOG_IN_SCREEN);
            Write("CUSTOMER-ID : ");
            int customerID;
            //exception handling for the case of entering a string instead of a number
            try
            { 
                customerID = Convert.ToInt32(ReadLine()); 
            }
            catch (FormatException)
            {
                UserMessages.Instance.WriteException(Exception_Messages.INVALID_CUSTOMER_ID);
                System.Threading.Thread.Sleep(2000);
                Clear();
                logInScreen();
                return;
            }
            //handling the case of new customer
            if (customerID == 1)
            {
                if (!customers.BuildNewAccount())
                {
                    UserMessages.Instance.WriteException(Exception_Messages.INVALID_DESCRIPTION);
                    System.Threading.Thread.Sleep(5000);
                    Clear();
                    logInScreen();
                }
                else
                {
                    dataBase.SendDataToDataBase(customers.CustomerID, customers.CustomerPIN, customers.FullName());
                    dataBase.UpdateAccountBalance(customers.CustomerID, 100);
                }
            
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
                    UserMessages.Instance.WriteException(Exception_Messages.INVALID_PIN);
                    System.Threading.Thread.Sleep(2500);
                    Clear();
                    logInScreen();
                    return;
                }
                //handling the case of wrong customerID or PIN
                if (dataBase.CustomerValidator(customerID, PIN) != (byte)validatorKeys.PASS)
                {
                    System.Threading.Thread.Sleep(3000);
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
            UserMessages.Instance.WriteLayout(Layout_Messages.MENU_SCREEN);
            //handling the menu selection
            int menuSelection;
            //exception handling for the case of entering a string instead of a number
            try
            {
                menuSelection = Convert.ToInt32(ReadLine());
            }
            catch (FormatException)
            {
                UserMessages.Instance.WriteException(Exception_Messages.INVALID_CHOICE);
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
                    UserMessages.Instance.WriteException(Exception_Messages.INVALID_AMOUNT);
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    Menu();
                    return;
                }
                if (amount >= 1 && amount <= 1000)
                {
                    if (amount <= dataBase.AccountBalance(customers.CustomerID))
                    {
                        dataBase.UpdateAccountBalance(customers.CustomerID, -amount);
                        UserMessages.Instance.WriteLayout(Layout_Messages.SUCCESSFUL_PROSSES);
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
                Clear();
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
                    UserMessages.Instance.WriteException(Exception_Messages.INVALID_AMOUNT);
                    System.Threading.Thread.Sleep(2000);
                    Clear();
                    Menu();
                    return;
                }
                //handling the case if the amount is between 1 and 500
                if (amount >= 1 && amount <= 500)
                {
                    dataBase.UpdateAccountBalance(customers.CustomerID, amount);
                    UserMessages.Instance.WriteLayout(Layout_Messages.SUCCESSFUL_PROSSES);
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
            else if (menuSelection == 4)
            {
                Console.WriteLine("SORRY CURRENTLY NOT AVALIABLE!!");
            }
            else if (menuSelection == 5)
            {
                WriteLine("QUITING!!....."); return;
            }
            //handling the case of invalid selection
            else
            {
                UserMessages.Instance.WriteException(Exception_Messages.INVALID_CHOICE);
                //Make the user wait for 2 seconds before clearing the screen
                System.Threading.Thread.Sleep(2000);
                Clear();
                //Make the user enter the menu selection again
                Menu();
            }

        }
    }
}

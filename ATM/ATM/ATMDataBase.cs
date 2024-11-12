using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    enum validatorKeys
    {
        WRONG_CUSTOMER_ID,
        WRONG_PIN,
        PASS
    }
    internal class ATMDataBase
    {
        public Dictionary<int, int> CustomerID_PIN = new Dictionary<int, int>();
        public Dictionary<int, string> CustomerID_Name = new Dictionary<int, string>();
        public Dictionary<int, int> CustomerID_Balance = new Dictionary<int, int>();

        public bool checkIfCustomerIDIsCorrect(int customerID)
        {
            if (!CustomerID_PIN.ContainsKey(customerID)) { Console.WriteLine("SORRY YOUR CUSTOMER-ID IS WRONG, PLEASE REGESTER IF YOUR ARE NEW, IF NOT TRY AGAIN"); return false; }
            return true;
        }

        public void sentDataToDataBase(int customerID, int PIN, string FullName)
        {
            CustomerID_PIN.Add(customerID, PIN);
            CustomerID_Name.Add(customerID, FullName);
            CustomerID_Balance.Add(customerID, 0);
        }

        public int AccountBalance(int customerID)
        {
            return CustomerID_Balance[customerID];
        }
        public byte CustomerValidator(int customerID, int PIN)
        {
            if (!this.CustomerID_PIN.ContainsKey(customerID))
            {
                Console.WriteLine("THE CUSTOMER-ID IS WRONG PLEASE TRY AGAIN"); return (byte)validatorKeys.WRONG_CUSTOMER_ID;
            }
            if (this.CustomerID_PIN[customerID] != PIN)
            {
                Console.WriteLine("THE PIN IS WRONG PLEASE TRY AGAIN"); return (byte)validatorKeys.WRONG_PIN;
            }
            return (byte)validatorKeys.PASS;
        }
        public void updateAccountBalance(int customerID, int amount)
        {
            CustomerID_Balance[customerID] += amount;
        }
        public string retrieveFromDataBase()
        {
            return "";
        }
    }
}

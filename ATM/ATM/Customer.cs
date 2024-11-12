using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Customer
    {
        string firstName;
        string lastName;
        int age;
        int accountBalance;
        int customerID;
        int CustomerID_PIN;

        static int CustomerCounter = 142;
        public Customer()
        {
            firstName = null;
            lastName = null;
            age = 0;
            accountBalance = 100;
        }

        public string FirstName
        {
            set { firstName = value; }
            get { return firstName; }
        }

        public string LastName
        {
            set { lastName = value; }
            get { return lastName; }
        }
        public int CustomerPIN
        {
            set { CustomerID_PIN = value; }
            get { return CustomerID_PIN; }
        }
        public int CustomerID
        {
            set { customerID = value; }
            get { return customerID; }
        }
        public int Age
        {
            set { age = value; }
            get { return age; }
        }

        public string FullName()
        {
            return firstName + " " + lastName;
        }
        public void BuildNewAccount()
        {
            Random rand = new Random();// to generate PIN's
            Write("PLEASE ENTER THE INFORMATION BELOW :\nFIRST NAME : ");
            FirstName = ReadLine();
            Write("LAST NAME : ");
            LastName = ReadLine();
            Write("AGE : ");
            Age = Convert.ToInt32(ReadLine());
            customerID = CustomerCounter++;
            WriteLine("MR " + firstName + " " + lastName + " WITH CUSTOMER ID " + CustomerID);
            CustomerPIN = rand.Next(111, 999);
            WriteLine("YOUR PIN FOR YOUR NEW ACCOUNT IS " + CustomerPIN + " (PLEASE SAVE IT AND DON'T SHARE IT WITH ANYONE!!)");

            WriteLine
                (
                "                                                 " +
                "########--" +
                "THANKS FOR REGESTERING TO OUR BANK, NOW YOU CAN WITHDRAWN OR INSERT MONEY AS YOU LIKE" +
                "--########"
                );
            for (int i = 0; i < 210; i++)
            {
                Write("#");
            }
            WriteLine();

        }

    }
}

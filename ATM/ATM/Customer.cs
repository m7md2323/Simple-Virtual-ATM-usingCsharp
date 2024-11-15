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
        int customerID;
        int CustomerID_PIN;

        static int CustomerCounter = 2;
        public Customer()
        {
            firstName = null;
            lastName = null;
            age = 0;
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
        public bool BuildNewAccount()
        {
            Random rand = new Random();// to generate PIN's
            Write("PLEASE ENTER THE INFORMATION BELOW :\nFIRST NAME : ");

             FirstName = ReadLine();
             Write("LAST NAME : ");
             LastName = ReadLine();
            
            //exception handling for the case of entering a string instead of a number
            try
            {
                Write("AGE : ");
                Age = Convert.ToInt32(ReadLine());
            }
            catch (FormatException)
            {
                UserMessages.Instance.WriteException(Exception_Messages.INVALID_AGE);
                return false;
            }

            if (Age < 18) { UserMessages.Instance.WriteException(Exception_Messages.INVALID_AGE); return false; }
            customerID = CustomerCounter++;
            WriteLine("MR " + firstName + " " + lastName + " WITH CUSTOMER ID " + CustomerID);
            CustomerPIN = rand.Next(111, 999);
            WriteLine("YOUR PIN FOR YOUR NEW ACCOUNT IS " + CustomerPIN + " (PLEASE SAVE IT AND DON'T SHARE IT WITH ANYONE!!)");

            UserMessages.Instance.WriteLayout(Layout_Messages.THANKS_FOR_REGESTERING_MESSAGE);
            UserMessages.Instance.WriteLayout(Layout_Messages.FULL_LINE);
            return true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public enum Exception_Messages
    {
        INVALID_CUSTOMER_ID,
        INVALID_PIN,
        INVALID_AMOUNT,
        INVALID_CHOICE,
        INVALID_AGE,
        INVALID_NAME,
        INVALID_DESCRIPTION,
        CUSTOMER_ID_NOT_FOUND
    }
    public enum Layout_Messages
    {
        LOG_IN_SCREEN,
        FRONT_SCREEN,
        MENU_SCREEN,
        THANKS_FOR_REGESTERING_MESSAGE,
        FULL_LINE,
        SUCCESSFUL_PROSSES

    }
    internal class UserMessages
    {
        //for singleton pattern
        private static bool instanceExist = false;
        private static UserMessages instanceObject;

        private string[] errorMessages;
        private string[] layoutMessages;
        private UserMessages()
        {
            MessagesInitializer();
        }
        //for singleton pattern
        //this will insure that there is only one instance of the class,
        //because we don't want to have multiple instances of this class
        public static UserMessages Instance {
            get 
            { 
                if(!instanceExist)
                {
                    instanceExist = true;
                    instanceObject=new UserMessages();
                    return instanceObject;
                }
                else return instanceObject;
            }
        }
        private void MessagesInitializer()
        {
            errorMessages = new string[8];
            errorMessages[(int)Exception_Messages.INVALID_CUSTOMER_ID] = "INVALID CUSTOMER ID PLEASE ENTER A NUMBER";
            errorMessages[(int)Exception_Messages.INVALID_PIN] = "INVALID PIN PLEASE ENTER A NUMBER";
            errorMessages[(int)Exception_Messages.INVALID_AMOUNT] = "INVALID AMOUNT PLEASE ENTER A NUMBER";
            errorMessages[(int)Exception_Messages.INVALID_AGE] = "SORRY YOU CAN'T CREATE AN ACCOUNT, YOU SHOULD BE 18 YEARS OLD OR ABOVE!!";
            errorMessages[(int)Exception_Messages.INVALID_CHOICE] = "INVALID CHOICE PLEASE ENTER A NUMBER (1,2,3,4,5)";
            errorMessages[(int)Exception_Messages.INVALID_NAME] = "INVALID NAME PLEASE ENTER A STRING";
            errorMessages[(int)Exception_Messages.INVALID_DESCRIPTION] = "INVALID INFORMATION!!";
            errorMessages[(int)Exception_Messages.CUSTOMER_ID_NOT_FOUND] = "CUSTOMER ID NOT FOUND, PLEASE ENTER AN EXISTING CUSTOMER";

            layoutMessages = new string[6];
            layoutMessages[(int)Layout_Messages.LOG_IN_SCREEN] = "PLEASE ENTER YOUR CUSTOMER-ID WITH YOUR PIN (IF YOU DONT HAVE AN ACCOUNT TYPE 1)";

            layoutMessages[(int)Layout_Messages.FRONT_SCREEN] = "                                                                 " +
                "###################--" +
                "HELLO AND WELCOME TO OUR ATM" +
                "--###################";

            layoutMessages[(int)Layout_Messages.MENU_SCREEN] =
                "####################################################################################################" +
                "--MENU--" +
                "####################################################################################################" +
                "\n1-WITHDRAW\n2-ACCOUNT BALANCE\n3-DEPOSIT\n4-TRANSFER\n5-EXIT";

            layoutMessages[(int)Layout_Messages.THANKS_FOR_REGESTERING_MESSAGE] =
                "                                                 " +
                "########--" +
                "THANKS FOR REGESTERING TO OUR BANK, NOW YOU CAN WITHDRAWN OR INSERT MONEY AS YOU LIKE" +
                "--########";

            layoutMessages[(int)Layout_Messages.FULL_LINE] =
            "#########################################################################################################" +
            "#######################################################################################################";
            layoutMessages[(int)Layout_Messages.SUCCESSFUL_PROSSES] = "\"YOUR PROSEESS WENT SUCCESSFULLY, THANKS FOR USING OUR ATM\"";
        }
        public void WriteException(Exception_Messages message)
        {
            Console.WriteLine(errorMessages[(int)message]);
        }
        public void WriteLayout(Layout_Messages message)
        {
            Console.WriteLine(layoutMessages[(int)message]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsPro
{
    internal class Messages
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome...");
            Console.WriteLine("------------");
            Console.WriteLine("This app makes user add Contacts and Serach into them.");
            Console.WriteLine("Then you can delete or add and choose Favorite Contacts.");
            Console.WriteLine("------------");
        }
        public static void InvalidAge()
        {
            Console.WriteLine();
            Console.WriteLine("Please type an Integer Number, also Age must be Greater than Zero (0).");
        }
        public static void InvalidPhoneNum(string firstName,string lastName)
        {
            Console.WriteLine();
            Console.WriteLine($"This Phone Number is belong to : {firstName} {lastName}.");
            Console.WriteLine("Please type another Phone Number.");
            Console.WriteLine();
        }
        public static void InvalidMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Please type a Valid Answer !");
            Console.WriteLine();
        }
        public static void InvalidNumber()
        {
            Console.WriteLine("(Pick a number from List.)");
        }
        public static void MainSection()
        {
            Console.WriteLine();
            Console.WriteLine("Now you can Type a number to use features of this App.");
            Console.WriteLine("1.Add Contact. \n2.Remove Contact. \n3.Search Contact. \n4.Lists. \n5.End of Program.");
            Console.Write("Type: ");
        }
        public static void RemoveSection()
        {
            Console.WriteLine();
            Console.WriteLine("1.Remove Contact from List. \n2.Remove Contact from Favorite List. \n3.Return to Main Menu.");
            Console.Write("Type: ");
        }
        public static void AddSection()
        {
            Console.WriteLine();
            Console.WriteLine("1.Add Contact to List. \n2.Add Contact to Favorite List.\n3.Return to Main Menu.");
            Console.Write("Type: ");
        }
        public static void OperationCancelled()
        {
            Console.WriteLine();
            Console.WriteLine("!!! Operation Cancelled !!!");
            Console.WriteLine();
        }
        public static void EmptyList()
        {
            Console.WriteLine();
            Console.WriteLine("List is Empty !");
            Console.WriteLine();
        }
        public static void Cancell()
        {
            Console.WriteLine("Type: (Cancel) to Terminate Operation!");
        }
    }
}

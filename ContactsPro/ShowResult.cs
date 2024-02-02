using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsPro
{
    internal class ShowResult
    {
        public static void AllResult(List<Contacts> Contacts)
        {
            int count = 0;
            Console.WriteLine("List:-----ALL RESULT-----");
            Console.WriteLine("_____________________________________");
            foreach (var contact in Contacts)
            {
                count++;
                Console.WriteLine();
                Console.WriteLine($"{count}. Full Name : {contact.FirstName} {contact.LastName} // Age: {contact.Age}" +
                    $" // Phone Number: {contact.PhoneNum} // City: {contact.City} // Favorite Contact: {contact.FavoriteContact}");
            }
            Console.WriteLine("_____________________________________");
            Console.WriteLine($"There is ({count}) Contacts in the List.");
            Console.WriteLine();

        }
        public static int FavoriteResult(List<Contacts> Contacts)
        {
            int count = 0;
            Console.WriteLine("List:-----FAVORITE RESULT-----");
            Console.WriteLine("_____________________________________");
            foreach (var contact in Contacts)
            {
                if (contact.FavoriteContact == true)
                {
                    count++;
                    Console.WriteLine();
                    Console.WriteLine($"{count}. Full Name : {contact.FirstName} {contact.LastName} // Age: {contact.Age}" +
                        $" // Phone Number: {contact.PhoneNum} // City: {contact.City} // Favorite Contact: {contact.FavoriteContact}"); 
                }
            }
            Console.WriteLine("_____________________________________");
            Console.WriteLine($"There is ({count}) Contacts in the List.");
            Console.WriteLine();
            return count;
        }
        public static int NonFavoriteResult(List<Contacts> Contacts)
        {
            int count = 0;
            Console.WriteLine("List:-----NON FAVORITE RESULT-----");
            Console.WriteLine("_____________________________________");
            foreach (var contact in Contacts)
            {
                if (contact.FavoriteContact == false)
                {
                    count++;
                    Console.WriteLine();
                    Console.WriteLine($"{count}. Full Name : {contact.FirstName} {contact.LastName} // Age: {contact.Age}" +
                        $" // Phone Number: {contact.PhoneNum} // City: {contact.City} // Favorite Contact: {contact.FavoriteContact}");
                }
            }
            Console.WriteLine("_____________________________________");
            Console.WriteLine($"There is ({count}) Contacts in the List.");
            Console.WriteLine();
            return count;
        }
    }
}

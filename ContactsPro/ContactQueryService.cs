using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsPro
{
    internal class ContactQueryService
    {
        public static void NumberOrSkip()
        {
            var Contacts = new List<Contacts>();
            int numberOfContacts;
            while (true)
            {
                string result = IO_Service.NumberOrSkipResult();
                if (int.TryParse(result, out int number))
                {
                    (Contacts, numberOfContacts) = ContactQueryService.IfNumber(number, Contacts);
                    while (true)
                    {
                        (Contacts, numberOfContacts) = ContactQueryService.MainMenu(Contacts, numberOfContacts);
                    }
                }
                else if (result.ToLower() == "skip")
                {
                    (Contacts, numberOfContacts) = ContactQueryService.IfSkip(Contacts);
                    while (true)
                    {
                        (Contacts, numberOfContacts) = ContactQueryService.MainMenu(Contacts, numberOfContacts);
                    }

                }
                else
                {
                    Messages.InvalidMessage();
                }
            }
        }
        public static (List<Contacts>, int) IfNumber(int number, List<Contacts> Contacts)
        {
            int i;
            for (i = 0; i < number; )
            {
                Console.WriteLine();
                i++;
                var contact = new Contacts();
                Console.WriteLine($"Contact Number {i}.");
                Console.Write("First Name: ");
                contact.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine();
                while (true)
                {
                    Console.Write("Age: ");
                    string ageText = Console.ReadLine();
                    int.TryParse(ageText, out int age);
                    if (age > 0 )
                    {
                        contact.Age = age;
                        break;
                    }
                    else
                    {
                        Messages.InvalidAge();
                    }
                }
                do
                {
                    Console.Write("Phone Number: ");
                    contact.PhoneNum = Console.ReadLine();

                    foreach (var person in Contacts)
                    {
                        if (person.PhoneNum == contact.PhoneNum)
                        {
                            Messages.InvalidPhoneNum(person.FirstName, person.LastName);
                            contact.PhoneNum = string.Empty;
                            break;
                        }

                    }

                } while (contact.PhoneNum == string.Empty);
             

                Console.Write("City: ");
                contact.City = Console.ReadLine();

                while (true)
                {
                    Console.Write("Favorite Contact? (Yes/No) : ");
                    string favoriteResult = Console.ReadLine();
                    if (favoriteResult.ToLower() == "yes")
                    {
                        contact.FavoriteContact = true;
                        break;
                    }
                    else if (favoriteResult.ToLower() == "no")
                    {
                        contact.FavoriteContact = false;
                        break;
                    }
                    else
                    {
                        Messages.InvalidMessage();
                    }
                }
                Contacts.Add(contact);
                Console.WriteLine($"Contact: {contact.FirstName} {contact.LastName} Successfully added to List .");

            }
            return (Contacts, i);
        }
        public static (List<Contacts>,int) IfSkip(List<Contacts> Contacts)
        {
            Console.WriteLine();
            int i = 0;
            string result;
            do
            {
                i++;
                var contact = new Contacts();
                Console.WriteLine($"Contact Number {i}.");
                Console.Write("First Name: ");
                contact.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine();
                while (true)
                {
                    Console.Write("Age: ");
                    string ageText = Console.ReadLine();
                    int.TryParse(ageText, out int age);
                    if (age > 0)
                    {
                        contact.Age = age;
                        break;
                    }
                    else
                    {
                        Messages.InvalidAge();
                    }
                }

                do
                {
                    Console.Write("Phone Number: ");
                    contact.PhoneNum = Console.ReadLine();

                    foreach (var person in Contacts)
                    {
                        if (person.PhoneNum == contact.PhoneNum)
                        {
                            Messages.InvalidPhoneNum(person.FirstName, person.LastName);
                            contact.PhoneNum = string.Empty;
                            break;
                        }

                    }

                } while (contact.PhoneNum == string.Empty);

                Console.Write("City: ");
                contact.City = Console.ReadLine();
                while (true)
                {
                    Console.Write("Favorite Contact? (Yes/No) : ");
                    string favoriteResult = Console.ReadLine();
                    if (favoriteResult.ToLower() == "yes")
                    {
                        contact.FavoriteContact = true;
                        break;
                    }
                    else if (favoriteResult.ToLower() == "no")
                    {
                        contact.FavoriteContact = false;
                        break;
                    }
                    else
                    {
                        Messages.InvalidMessage();
                    }
                }
                Contacts.Add(contact);
                Console.WriteLine($"Contact: {contact.FirstName} {contact.LastName} Successfully added to List .");
                Console.WriteLine();
                result = IO_Service.AnotherContact();

            } while (result == "yes");
            return (Contacts, i);
        }
        public static (List<Contacts>, int) MainMenu(List<Contacts> Contacts,int numberOfContacts)
        {
            Messages.MainSection();
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    
                    (Contacts, numberOfContacts) = ContactCommandService.AddSection(Contacts, numberOfContacts);
                    break;
                case "2":
                    (Contacts, numberOfContacts) = ContactCommandService.RemoveSection(Contacts, numberOfContacts);
                    break;
                

            }
            return (Contacts, numberOfContacts);
            
        }   
    }       
}

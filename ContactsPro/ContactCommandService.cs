using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ContactsPro
{
    internal class ContactCommandService
    {
        public static (List<Contacts>, int) AddSection(List<Contacts> Contacts, int numberOfContacts)
        {
            string result = IO_Service.AddSectionResult();
            switch (result)
            {
                case "1":
                    string showResult = IO_Service.ContactsShow();
                    if (showResult == "yes")
                    {
                        ShowResult.AllResult(Contacts);
                    }
                    (Contacts, numberOfContacts) = ContactCommandService.AddContact(Contacts, numberOfContacts);
                    break;
                case "2":
                    Contacts = ContactCommandService.AddFavorite(Contacts);
                    break;
                case "3":
                    break;

            }
            return (Contacts, numberOfContacts);
        }
        public static (List<Contacts>,int) AddContact(List<Contacts> Contacts, int numberOfContacts)
        {
            string resultLoop;
            do
            {
                numberOfContacts++;
                var contact = new Contacts();
                Messages.Cancell();
                Console.WriteLine();
                Console.WriteLine($"Contact Number {numberOfContacts}.");
                //FirstName
                Console.Write("First Name: ");
                contact.FirstName = Console.ReadLine();
                //Cancel System
                if (contact.FirstName.ToLower() == "cancel")
                {
                    Messages.OperationCancelled();
                    break;
                }
                //LastName
                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine();
                //Cancel System
                if (contact.LastName.ToLower() == "cancel")
                {
                    Messages.OperationCancelled();
                    break;
                }
                //Age
                string ageText;
                while (true)
                {
                    Console.Write("Age: ");
                    ageText = Console.ReadLine();
                    if (int.TryParse(ageText, out int age))
                    {
                        contact.Age = age;
                        break;
                    }
                    //Cancel System
                    else if (ageText.ToLower() == "cancel")
                    {
                        break;
                    }
                    else
                    {
                        Messages.InvalidAge();
                    }
                }
                //Cancel System
                if (ageText.ToLower() == "cancel")
                {
                    Messages.OperationCancelled();
                    break;
                }
                //PhoneNumber
                do
                {
                    Console.Write("Phone Number: ");
                    contact.PhoneNum = Console.ReadLine();
                    //Cancel System
                    if (contact.PhoneNum.ToLower() == "cancel")
                    {
                        break;
                    }

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
                //Cancel System
                if (contact.PhoneNum.ToLower() == "cancel")
                {
                    Messages.OperationCancelled();
                    break;
                }
                //City
                Console.Write("City: ");
                contact.City = Console.ReadLine();
                //Cancel System City
                if (contact.City.ToLower() == "cancel")
                {
                    Messages.OperationCancelled();
                    break;
                }
                //FavoriteContact
                string favoriteResult;
                while (true)
                {
                    Console.Write("Favorite Contact? (Yes/No) : ");
                    favoriteResult = Console.ReadLine();
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
                    //Cancel System Favorite Contact
                    else if (favoriteResult.ToLower() == "cancel")
                    {
                        break;
                    }
                    else
                    {
                        Messages.InvalidMessage();
                    }
                }
                //Cancel System Favorite Contact
                if (favoriteResult.ToLower() == "cancel")
                {
                    Messages.OperationCancelled();
                    break;
                }
                //Sure system
                string resultSure = IO_Service.SureResult();
                if (resultSure == "yes")
                {
                    Contacts.Add(contact);
                    Console.WriteLine($"Contact: {contact.FirstName} {contact.LastName} Successfully added to List .");
                    Console.WriteLine();
                }
                else
                {
                    Messages.OperationCancelled();
                    break;
                }
                resultLoop = IO_Service.AnotherContact();

            } while (resultLoop == "yes");
            return (Contacts, numberOfContacts);
        }
        public static List<Contacts> AddFavorite(List<Contacts> Contacts)
        {
            while (true)
            {
                int countNonFavorite = ShowResult.NonFavoriteResult(Contacts);
                if (countNonFavorite == 0)
                {
                    Messages.EmptyList();
                    break;
                }
                else if (countNonFavorite > 0)
                {
                    int resultNumber = IO_Service.NonFavoriteNumber(countNonFavorite);
                    int count = 0;
                    foreach (var contact in Contacts)
                    {
                        if (resultNumber == -1)
                        {
                            Messages.OperationCancelled();
                            break;
                        }
                        else if (contact.FavoriteContact == false)
                        {
                            count++;
                            if (count == resultNumber)
                            {
                                Console.WriteLine();
                                Console.WriteLine("You chose:");
                                Console.WriteLine($"{count}. Full Name : {contact.FirstName} {contact.LastName} // Age: {contact.Age}" +
                                    $" // Phone Number: {contact.PhoneNum} // City: {contact.City} // Favorite Contact: {contact.FavoriteContact}");
                                string resultSure = IO_Service.SureResult();
                                if (resultSure == "yes")
                                {
                                    Console.WriteLine($"Contact: {contact.FirstName} {contact.LastName} Successfully added to Favorite List .");
                                    contact.FavoriteContact = true;
                                    break;
                                }
                                else
                                {
                                    Messages.OperationCancelled();
                                    break;
                                }
                            }
                        }
                    }
                    break;
                } 
            }
            return Contacts;
        }
        public static (List<Contacts>, int) RemoveSection(List<Contacts> Contacts, int numberOfContacts)
        {
            string result = IO_Service.RemoveSectionResult();
            switch (result)
            {
                case "1":
                    ShowResult.AllResult(Contacts);
                    if (numberOfContacts == 0)
                    {
                        Messages.EmptyList();
                        break;
                    }
                    else
                    {
                        int removeNumber = IO_Service.RemoveContactNumber(numberOfContacts);
                        (Contacts, numberOfContacts) = ContactCommandService.RemoveContact(Contacts, numberOfContacts, removeNumber);
                        break;
                    }
                    
                case "2":
                    Contacts = ContactCommandService.RemoveFavorite(Contacts);
                    break;
                case "3":
                    break;

            }
            return (Contacts, numberOfContacts);
          
        }
        public static (List<Contacts>, int) RemoveContact(List<Contacts> Contacts, int numberOfContacts, int removeNumber)
        {
            int count = 0;
            foreach (var contact in Contacts)
            {
                count++;
                if (count == removeNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("You chose:");
                    Console.WriteLine($"{count}. Full Name : {contact.FirstName} {contact.LastName} // Age: {contact.Age}" +
                        $" // Phone Number: {contact.PhoneNum} // City: {contact.City} // Favorite Contact: {contact.FavoriteContact}");
                    string resultSure = IO_Service.SureResult();
                    if (resultSure == "yes")
                    {
                        Console.WriteLine($"Contact: {contact.FirstName} {contact.LastName} Successfully removed from List .");
                        Contacts.Remove(contact);
                        numberOfContacts -= numberOfContacts;
                        break;
                    }
                    else
                    {
                        Messages.OperationCancelled();
                        break;
                    }

                }
                else if (removeNumber == -1)
                {
                    Messages.OperationCancelled();
                    break;
                }

            }
            Console.WriteLine();
            
            return (Contacts, numberOfContacts);
        }
        public static List<Contacts> RemoveFavorite(List<Contacts> Contacts)
        {
            while (true)
            {
                int countFavorite = ShowResult.FavoriteResult(Contacts);
                if (countFavorite == 0)
                {
                    Messages.EmptyList();
                    break;
                }
                else if (countFavorite > 0)
                {
                    int resultNumber = IO_Service.FavoriteNumber(countFavorite);
                    int count = 0;
                    foreach (var contact in Contacts)
                    {
                        if (resultNumber == -1)
                        {
                            Messages.OperationCancelled();
                            break;
                        }
                        else if (contact.FavoriteContact == true)
                        {
                            count++;
                            if (count == resultNumber)
                            {
                                Console.WriteLine();
                                Console.WriteLine("You chose:");
                                Console.WriteLine($"{count}. Full Name : {contact.FirstName} {contact.LastName} // Age: {contact.Age}" +
                                    $" // Phone Number: {contact.PhoneNum} // City: {contact.City} // Favorite Contact: {contact.FavoriteContact}");
                                string resultSure = IO_Service.SureResult();
                                if (resultSure == "yes")
                                {
                                    Console.WriteLine($"Contact: {contact.FirstName} {contact.LastName} Successfully added to Favorite List .");
                                    contact.FavoriteContact = false;
                                    break;
                                }
                                else
                                {
                                    Messages.OperationCancelled();
                                    break;
                                }
                            }
                        }
                    }
                    break;
                }
            }
            return Contacts;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsPro
{
    internal class IO_Service
    {
        public static string NumberOrSkipResult()
        {
            Console.WriteLine("How many contact do you want to add? Type: Number.");
            Console.WriteLine("You can also skip this feature. Type: skip");
            Console.Write("Type: ");
            string output = Console.ReadLine();
            return output;
            
        }
        public static string AnotherContact()
        {
            string output;
            do
            {
                Console.Write("Do you want to add another Contact? (Yes/No) : ");
                output = Console.ReadLine();
                if (output.ToLower() == "yes" || output.ToLower() == "no")
                {
                    break;
                }
                else
                {
                    Messages.InvalidMessage();
                } 
            } while (true);
            return output.ToLower();
            
        }
        public static string ContactsShow()
        {
            string output;
            while (true)
            {
                Console.WriteLine("Do you want to see all Contacts first ? (Yes/No): ");
                output = Console.ReadLine();
                if (output.ToLower() == "yes")
                {
                    break;
                }
                else if (output.ToLower() == "no")
                {
                    break;
                }
                else
                {
                    Messages.InvalidMessage();
                } 
            }
            return output.ToLower();
        }
        public static string AddSectionResult()
        {
            string output;
            while (true)
            {
                Messages.AddSection();
                output = Console.ReadLine();
                if (output == "1" || output == "2" || output == "3")
                {
                    break;
                }
                else
                {
                    Messages.InvalidMessage();
                }
            }
            return output;
        }
        public static string RemoveSectionResult()
        {
            string output;
            while (true)
            {
                Messages.RemoveSection();
                 output = Console.ReadLine();
                if (output == "1" || output == "2" || output == "3")
                {
                    break;
                }
                else 
                {
                    Messages.InvalidMessage(); 
                }
            }
            return output;
        }
        public static int RemoveContactNumber(int numberOfContacts)
        {
            int output;
            while (true)
            {
                Messages.Cancell();
                Console.Write("To Remove Type a Number : ");
                string textOutput = Console.ReadLine(); 
                if (int.TryParse(textOutput, out output ) && output <= numberOfContacts && output > 0)
                {
                    break;
                }
                else if (textOutput.ToLower() == "cancel")
                {
                    output = -1;
                    break;
                }
                else
                {
                    Messages.InvalidMessage();
                    Messages.InvalidNumber();
                }
            }
            return output;

        }
        public static int NonFavoriteNumber(int countNonFavorite)
        {
            int output;
            while (true)
            {
                Messages.Cancell();
                Console.Write("Add to Favorite (Type a Number) : ");
                string textOutput = Console.ReadLine();
                if (int.TryParse(textOutput, out output) && output <= countNonFavorite && output > 0)
                {
                    break;
                }
                else if (textOutput.ToLower() == "cancel")
                {
                    output = -1;
                    break;
                }
                else
                {
                    Messages.InvalidMessage();
                    Messages.InvalidNumber();
                }
            }
            return output;

        }
        public static int FavoriteNumber(int countFavorite)
        {
            int output;
            while (true)
            {
                Messages.Cancell();
                Console.Write("Remove from Favorite (Type a Number) : ");
                string textOutput = Console.ReadLine();
                if (int.TryParse(textOutput, out output) && output <= countFavorite && output > 0)
                {
                    break;
                }
                else if (textOutput.ToLower() == "cancel")
                {
                    output = -1;
                    break;
                }
                else
                {
                    Messages.InvalidMessage();
                    Messages.InvalidNumber();
                }
            }
            return output;

        }

        public static string SureResult()
        {
            string output;
            while (true)
            {
                Console.WriteLine();
                Console.Write("Are you sure?! (Yes/No) :");
                output = Console.ReadLine();
                if (output.ToLower() == "yes")
                {
                    break;
                }
                else if (output.ToLower() == "no")
                {
                    break;
                }
                else
                {
                    Messages.InvalidMessage();
                } 
            }
            return output.ToLower();
        }

    }
}

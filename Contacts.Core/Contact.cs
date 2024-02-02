using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsPro
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNum { get; set; } = string.Empty;
        public string City { get; set; }
        public bool FavoriteContact { get; set; }

        public static List<Contact> contacts { get; set; } = new List<Contact>();
    }
}

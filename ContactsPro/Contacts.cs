using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsPro
{
    internal class Contacts
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNum { get; set; } = string.Empty;
        public string City { get; set; }
        public bool FavoriteContact { get; set; }
    }
}

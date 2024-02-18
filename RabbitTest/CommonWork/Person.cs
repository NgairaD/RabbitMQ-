using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWork
{
    public class Person
    {
        public String Name { get; set; }
        public String Email { get; set; }

        public Person(String Name, String Email)
        {
            this.Email = Email;
            this.Name = Name;
        }
    }
}

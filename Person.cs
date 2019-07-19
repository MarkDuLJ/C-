using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalClass
{
    class Person
    {
        static public int count;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public class PersonDataCollection
        {
            public BindingList<Person> PersonInfoLists { get; set; } = new BindingList<Person>();
        }
    }
}

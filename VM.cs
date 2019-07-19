using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalClass
{
    class VM
    {
        Person Myinfo = new Person() { Name = "Mark", Age = 35, Address = "Erb Street", PhoneNumber = 12345 };
        Person Freiend1 = new Person() { Name = "Ryan", Age = 24, Address = "Webber Street", PhoneNumber = 23456 };
        Person Friend2 = new Person() { Name = "Jamie", Age = 15, Address = "Bridgeport Street", PhoneNumber = 34567 };

        //public BindingList<PersonalData> PersonalDataList { get; set; } = new BindingList<PersonalData>();
        //public PersonalDataCollection Persons = new PersonalDataCollection();

        public BindingList<Person> P = new BindingList<Person>();
        public void AddNew()
        {
            P.Add(Myinfo);
            P.Add(Freiend1);
            P.Add(Friend2);
        }

        
        //        private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}

using AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PackageVisibility
{
    class Owner : OwnerIF
    {
        private string name;

        public Owner(string name)
        {
            this.name = name;
        }


        // Send a message to multiple employees
        public void send(string message, List<Employee> recipients)
        {
            Console.WriteLine("Hello, it's the owner ");
            foreach (Employee em in recipients)
            {
                Console.WriteLine(message + ", " + em.getName());
            }
            Console.WriteLine("\n");
        }
        public void delegateSend(Manager m, string message, List<Employee> recipients)
        {
            m.setOwner(this); // we know which instance of Owner called
            m.getOwner().send(message, recipients);
        }


    }
}

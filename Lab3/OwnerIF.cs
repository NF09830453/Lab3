using AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageVisibility
{
    internal interface OwnerIF
    {
        public void send(string message, List<Employee> recipients);
    }
}

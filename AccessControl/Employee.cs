using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl
{
    public class Employee
    {
        PerformIF pf;
        // All shared attributes must be private
        private string name; // supposed to be private (I think) public for testing
        private int age;
        private string title;
        private double salary; // accountant needs access to

        private int likertScaleValue;

        private double startingStipend;

        // task list
        public List<TaskItem> tasks = new List<TaskItem>();


        //public Blacksmith? bsmithDelegator { get; set; }

        // Constructor
        public Employee(string name, int age, string title)
        {
            this.name = name;
            this.age = age;
            this.title = title;
            if (title.ToLower() == "manager")
            {
                this.salary = 50000;
            }
            else if (title.ToLower() == "accountant")
            {
                this.salary = 45000;
            }
            else if (title.ToLower() == "blacksmith")
            {
                this.salary = 35000;
            }
            else
            {
                this.salary = 0;
            }
        }

        // Getter for Name
        public string getName()
        {
            return name;
        }

        // Setter for Name
        public void setName(string nameUpdate)
        {
            name = nameUpdate;
        }

        // Getter for Salary
        public double getSalary()
        {
            return salary;
        }

        // Setter for Salary
        internal void setSalary(double salaryUpdate)
        {
            this.salary = salaryUpdate;
        }

        // Getter for Title
        public string getTitle()
        {
            return title;
        }
        public int getLikertScaleValue()
        {
            return likertScaleValue;
        }

        // Setter for Likert Scale Value
        public void setLikertScaleValue(int evaluatedValue)
        {
            likertScaleValue = evaluatedValue;
        }

        public void setPerform(PerformIF b)
        {
            this.pf = b;
        }

        public PerformIF getPerform()
        {
            return pf;
        }

    }
}

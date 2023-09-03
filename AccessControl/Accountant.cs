using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl {
    public class Accountant : Employee, AccBlackIF
    {
  
        Accountant? accountantDelegator; // nullable
        public Accountant(string name, int age, string title) : base(name, age, title)
        {
        }

        public void update(Employee em, double newSalary)
        {
            // update employee's salary
            // only accountant can do this
            Console.WriteLine("SALARY UPDATE\nOld salary: " + em.getSalary());
            em.setSalary(newSalary);
            Console.WriteLine("New salary: " + em.getSalary());
            Console.WriteLine(em.getTitle() + " " + em.getName() + "'s salary was updated by " + this.getTitle() + " " + this.getName() + "\n");
        }

        private void doDelegatedUpdate(Employee em, double newSalary)
        {
            if (accountantDelegator != null)
            {
                Console.WriteLine("\nDelegated by " + accountantDelegator.getTitle() + " " + accountantDelegator.getName());
                this.update(em, newSalary);
                accountantDelegator = null; // clear delegator if job is done
            }
            else
            {
                Console.WriteLine("No delegator. Unable to Update " + em.getName() + "'s salary.");
            }
        }

        public void delegateUpdate(Accountant a, Employee em, double newSalary)
        {
            a.accountantDelegator = this;
            a.doDelegatedUpdate(em, newSalary);
        }


     /*  public int getLikertScaleValue()
        {
            return likertScaleValue;
        }

        // Setter for Likert Scale Value
        public void setLikertScaleValue(int evaluatedValue)
        {
            likertScaleValue = evaluatedValue;
        }*/
    }

}


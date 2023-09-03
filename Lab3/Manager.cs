using AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PackageVisibility
{
    class Manager: Employee
    {
        
        OwnerIF owner;
        Employee emp;
        AccBlackIF accBlack;
        int delegatedVal;
 
        public Manager? managerDelegator { get; set; } // ? indicates nullable 
        public Manager(string name, int age, string title, Owner o) : base(name, age, title)
        {
            this.owner = o;
        }
        public void setOwner(Owner o)
        {
            this.owner = o;
        }

        public OwnerIF getOwner()
        {
            return owner;
        }

        public void evaluate(AccBlackIF ab, int likertValue)
        {
            if (managerDelegator != null)
            {
                Console.WriteLine("\nDelegated by " + managerDelegator.getTitle() + " " + managerDelegator.getName());
                managerDelegator = null; // clear delegator once job done 
                this.evaluate(accBlack, delegatedVal);

            }
            emp = (Employee) ab;
            // Likert scale value between 1 and 5
            Console.WriteLine("LIKERT SCALE EVALUATION");
            emp.setLikertScaleValue(likertValue);
            Console.WriteLine(emp.getTitle() + " " + emp.getName() + "'s score: " + emp.getLikertScaleValue());
            Console.WriteLine("Evaluated by: " + this.getTitle() + " " + this.getName() + "\n");



        }


        /*private void doDelegatedEvaluation(AccBlackIF ab, int likertValue)
        {
            if (managerDelegator != null)
            {
                Console.WriteLine("\nDelegated by " + managerDelegator.getTitle() + " " + managerDelegator.getName());
                this.evaluate(ab, likertValue);
                managerDelegator = null; // clear delegator once job done 
            }
            else
            {
                Console.WriteLine("No delegator. Unable to Send message(s).\n");
                return;
            }
            return;
        }*/

        public void delegateEvaluation(Manager m, AccBlackIF ab, int likertValue)
        {
            m.managerDelegator = this;
            m.accBlack = ab;
            m.delegatedVal = likertValue;
        }
    }
}

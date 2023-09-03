using AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageVisibility
{
    class Blacksmith : Employee, AccBlackIF, PerformIF
    {
 
        private int likertScaleValue;
        public Blacksmith(string name, int age, string title) : base(name, age, title)
        {
 
        }

        public void perform()
        {
            // Greg not only performs his own task t1
            // but also the task t2 from Amy. In other words,
            // calling Greg’s perform method will do both tasks and
            // prompt two simple messages related to the tasks.
            Console.WriteLine("Performing task(s) ... ");
            foreach (TaskItem t in tasks)
            {
                Console.WriteLine(t.id + " " + t.desc + " " + t.dueDate);
            }
            Console.WriteLine("Completed by " + this.getName()+ "\n");
        }


        public void queueTask(TaskItem t)
        {
           this.tasks.Add(t);
        }

        public void delegatePerform(Employee em, TaskItem t)
        {
            em.setPerform(this);
            
            em.tasks.Add(t);

            // Remove task from delegator's list since delegatee will do it for them
            if (this.tasks.Contains(t))
            {
                this.tasks.Remove(t);
            }
            // Delegatee performs task
            em.getPerform().perform();
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

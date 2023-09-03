// See https://aka.ms/new-console-template for more information
using AccessControl;
using PackageVisibility;

public class Program
{
    public static void Main(string[] args)
    {
        Owner owner = new Owner("Craig");

        // Managers
        Manager john = new Manager("John", 55, "Manager", owner);
        Manager mary = new Manager("Mary", 35, "Manager", owner);

        // Accountants
        Accountant jane = new Accountant("Jane", 30, "Accountant");
        Accountant joe = new Accountant("Joe", 31, "Accountant");

        // Blacksmiths
        Blacksmith jack = new Blacksmith("Jack", 28, "Blacksmith");
        Console.WriteLine(jack.getName() + "'s starting stipend: " + jack.getSalary()); // output -> 35000 
        Blacksmith katie = new Blacksmith("Katie", 33, "Blacksmith");
        Blacksmith amy = new Blacksmith("Amy", 33, "Blacksmith");
        Blacksmith lin = new Blacksmith("Lin", 33, "Blacksmith");
        Blacksmith greg = new Blacksmith("Greg", 33, "Blacksmith");


        

        // Owner method test
        // Craig sends a message “Good Job” to employees John, Jane and Jack through the accepted argument
        List<Employee> recipients = new List<Employee> { john, jane, jack };
        owner.send("Good Job", recipients);
        owner.delegateSend(mary, "Nice work", recipients);


       

        // Greg not only performs his own task t1
        // but also the task t2 from Amy. In other words,
        // calling Greg’s perform method will do both tasks and
        // prompt two simple messages related to the tasks.

        greg.queueTask(new TaskItem(1, "task one", new DateOnly(2023, 9, 1)));
        Console.WriteLine(greg.tasks.Count);
        amy.delegatePerform(greg, new TaskItem(2, "task two", new DateOnly(2023, 9, 2)));
        Console.WriteLine(greg.tasks.Count == 0);
        Console.WriteLine(amy.tasks.Count == 0);


        //Jane updates Greg's salary
        jane.update(greg, greg.getSalary() + 1000);

        jane.delegateUpdate(joe, katie, katie.getSalary() + 8232);



        // Originally, John and Mary should evaluate Jack and Katie.
        john.evaluate(jack,  4);
        mary.evaluate(katie, 5);
        // However, John receives an urgent notice to go out of town and asks Mary for help.
        // Finally, run Mary’s “evaluate” method that assigns the individual Likert scales for Jack and Katie as 4 and 5

        john.delegateEvaluation(mary, jack, 4);
        mary.evaluate(katie, 5);


        
        
    }
}

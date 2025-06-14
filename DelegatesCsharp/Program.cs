using System.Reflection;

namespace DelegatesCsharp;

public delegate void WorkPerformedHandler(int hours, WorkType workType);
public delegate void CallbackMethodHandler(string message);
public delegate void DoSomeMethodHandler(string message);

class Program
{
    static void Main(string[] args)
    {
        WorkPerformedHandler del1 = new WorkPerformedHandler(Manager_WorkPerformed);
        del1.Invoke(10, WorkType.Golf);
        // del1.Invoke(50, WorkType.GotoMeetings);

        Console.WriteLine("\n");

        Program obj = new Program();
        CallbackMethodHandler del2 = new CallbackMethodHandler(obj.CallbackMethod);
        // Here, I am calling the DoSomework function and I want the 
        // DoSomework function to call the delegate at some point of time 
        // which will invoke the CallbackMethod method
        DoSomework(del2);

        Console.WriteLine("\n");

        SomeClass obj2 = new SomeClass();
        DoSomeMethodHandler del3 = new DoSomeMethodHandler(obj2.DoSomework);

        MethodInfo Method = del3.Method;
        object? Target = del3.Target;
        Delegate[] InvocationList = del3.GetInvocationList();

        Console.WriteLine($"Method Property: {Method}");
        Console.WriteLine($"Target Property: {Target}");

        foreach (var item in InvocationList)
        {
            Console.WriteLine($"InvocationList: {item}");
        }
    }

    public static void Manager_WorkPerformed(int workHours, WorkType wType)
    {
        Console.WriteLine("Work Performed by Event Handler");
        Console.WriteLine($"Work Hours: {workHours}, Work Type: {wType}");
    }


    public static void DoSomework(CallbackMethodHandler del)
    {
        Console.WriteLine("Processing some Task");
        del("Achmad");
    }

    public void CallbackMethod(String message)
    {
        Console.WriteLine("CallbackMethod Executed");
        Console.WriteLine($"Hello: {message}, Good Morning");
    }
}

public enum WorkType
{
    Golf,
    GotoMeetings,
    GenerateReports
}

public class SomeClass
{
    public void DoSomework(string message)
    {
        Console.WriteLine("DoSomework Executed");
        Console.WriteLine($"Hello: {message}, Good Morning");
    }
}
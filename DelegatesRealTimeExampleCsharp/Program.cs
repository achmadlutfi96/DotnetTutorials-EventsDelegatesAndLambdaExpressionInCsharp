namespace DelegatesRealTimeExampleCsharp;

class Program
{
    static void Main(string[] args)
    {
        WorkPerformedHandler del1 = new WorkPerformedHandler(Worker_WorkPerformed);
        WorkCompletedHandler del2 = new WorkCompletedHandler(Worker_WorkCompleted);

        Worker worker = new Worker();
        worker.DoWork(5, "Generating Report", del1, del2);
    }

    //Delegate Signature must match with the method signature
    static void Worker_WorkPerformed(int hours, string workType)
    {
        Console.WriteLine($"{hours} Hours compelted for {workType}");
    }
    static void Worker_WorkCompleted(string workType)
    {
        Console.WriteLine($"{workType} work compelted");
    }
}

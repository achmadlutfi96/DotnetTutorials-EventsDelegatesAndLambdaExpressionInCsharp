using System;

namespace DelegatesRealTimeExampleCsharp;

public delegate void WorkPerformedHandler(int hours, string workType);
public delegate void WorkCompletedHandler(string workTyp);
public class Worker
{
    public void DoWork(int hours, string workType, WorkPerformedHandler del1, WorkCompletedHandler del2)
    {
        //Do Work here and notify the consumer that work has been performed
        for (int i = 0; i < hours; i++)
        {
            //Do Some Processing
            Thread.Sleep(1000);
            //Notfiy how much works have been done
            del1(i + 1, workType);
        }
        //Notfiy the consumer that work has been completed
        del2(workType);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Activities
{
    
    public class Activity
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }

    public class Program
    {        
         static void Main()
        {
            int[] startTime = new int[] { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
            int[] finishTime = new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            List<Activity> activities = new List<Activity>();            

            for (int i = 0; i < startTime.Length; i++)
            {
                activities.Add(new Activity
                {
                    StartTime = startTime[i],
                    EndTime = finishTime[i]
                });
            }

            activities = activities.OrderBy(x => x.EndTime).ToList();

            var lastActivity = activities.First();
            Console.WriteLine($"{lastActivity.StartTime} - {lastActivity.EndTime}");

            for (int i = 1; i < activities.Count; i++)
            {
                var currentActivity = activities[i];
                if (lastActivity.EndTime < currentActivity.StartTime)
                {
                    lastActivity = currentActivity;
                    Console.WriteLine($"{lastActivity.StartTime} - {lastActivity.EndTime}");
                }
            }


        }
    }
}

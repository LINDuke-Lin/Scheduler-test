using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Quartz.Logging.OperationName;

namespace Scheduler_test
{
    internal class Program
    {


        static void Main(string[] args)
        {
            var props = new NameValueCollection();
            StdSchedulerFactory schedFact = new StdSchedulerFactory(props);

            IScheduler sched = schedFact.GetScheduler().Result;
            sched.Start();

            IJobDetail job = JobBuilder.Create<DogJob>()
                .WithIdentity("myJob", "group1") // name "myJob", group "group1"
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myJob", "group1")
               // .WithCronSchedule("10,20,30,40,50 * * * * ?")
                .WithCronSchedule("0 10,30 12,13 * * ?")
                .ForJob(job)
                .Build();

            sched.ScheduleJob(job, trigger);

            Task.Run(async () =>
            {

                while (true)
                {
                    var now = DateTime.Now;
                    Console.WriteLine(now.ToString("G"));

                    await Task.Delay(1000);
                }
            });
            Console.ReadKey();
        }
    }
}

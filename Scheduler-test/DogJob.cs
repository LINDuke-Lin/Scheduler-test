using Quartz;
using System;
using System.Threading.Tasks;

namespace Scheduler_test
{
    internal class DogJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
             Console.WriteLine($"{DateTime.Now.ToString("G")}汪汪!");
            return Task.CompletedTask;
        }
    }
}

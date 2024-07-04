using Infrastructure.Processing.Outbox;
using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;

namespace Infrastructure.Configuration.Quartz
{
    internal class QuartzStartup
    {
        public static void Initialize()
        {
            var configuration = new NameValueCollection
            {
                { "quartz.scheduler.instanceName", "App" }
            };

            var factory = new StdSchedulerFactory(configuration);

            IScheduler scheduler = factory.GetScheduler().GetAwaiter().GetResult();

            scheduler.Start().GetAwaiter().GetResult();

            var job = JobBuilder.Create<ProcessOutboxJob>().Build();

            var trigger = TriggerBuilder.Create()
                .StartNow()
                .WithCronSchedule("0/2 * * ? * *")
                .Build();

            scheduler.ScheduleJob(job, trigger).GetAwaiter().GetResult();
        }
    }
}

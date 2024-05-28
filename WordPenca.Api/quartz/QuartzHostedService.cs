
using Quartz;

namespace WordPenca.Api.quartz
{
    public class MyQuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly ILogger<MyQuartzHostedService> _logger;
        public IScheduler Scheduler { get; set; }

        public MyQuartzHostedService(ISchedulerFactory schedulerFactory, ILogger<MyQuartzHostedService> logger)
        {
            _schedulerFactory = schedulerFactory;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Quartz Hosted Service starting");

            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);

            var jobDetail = JobBuilder.Create<GetMatchesJob>()
                                      .WithIdentity("GetMatchesJob")
                                      .Build();

            var trigger = TriggerBuilder.Create()
                                        .WithIdentity("GetMatchesJobTrigger")
                                        .WithCronSchedule("0/10 * * * * ?") // Cada 6 segundos
                                        .Build();

            await Scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Quartz Hosted Service stopping");
            await Scheduler?.Shutdown(cancellationToken);
        }
    }
}
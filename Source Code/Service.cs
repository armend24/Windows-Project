using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Service
{
    class Service
    {
        private readonly ILogger<Service> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public Service(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
            _logger = serviceProvider.GetRequiredService<ILogger<Service>>();
            
        }

        public async Task Start()
        {
            _logger.LogInformation("Service started");
            await Planner();

        }

        public void Stop()
        {
            _logger.LogInformation("Service stopped");
            

        }   


        async Task Planner()
        {

            if (!int.TryParse(_configuration["MonitoringFrequency"], out var frequency))
                frequency = 2; //if convertion fails, set default value to 2 

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            scheduler.JobFactory = new VezhguesiJobFactory(_serviceProvider);

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<Vezhgues>()
                .WithIdentity("Vezhguesi i files")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("File monitoring frequency")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(frequency).RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);  

        }

    }
}

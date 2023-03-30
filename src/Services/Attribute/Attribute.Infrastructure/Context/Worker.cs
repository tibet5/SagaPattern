﻿using EasyNetQ.AutoSubscribe;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Attribute.Infrastructure.Context
{
    public class Worker : BackgroundService
    {
        private readonly AutoSubscriber _autoSubscriber;
        public Worker(AutoSubscriber autoSubscriber)
        {
            _autoSubscriber = autoSubscriber;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _autoSubscriber.SubscribeAsync(new Assembly[] { Assembly.GetExecutingAssembly() }, stoppingToken);
        }
    }
}

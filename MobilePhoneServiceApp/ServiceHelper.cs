﻿using Microsoft.Extensions.DependencyInjection;

namespace MobilePhoneServiceApp
{
    public class ServiceHelper
    {
        private static ServiceProvider _serviceProvider;
        public static ServiceProvider ServiceProvider => _serviceProvider;

        public static T GetService<T>() where T : class => _serviceProvider.GetRequiredService<T>();

        public static void CreateServiceProvider()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Add DbContext
            services.AddDbContext<TestDbContext>();

            services.AddSingleton<MainWindow>();
        }
    }
}
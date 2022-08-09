using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WorkdayCalender.Core.Interfaces.Repositories;
using WorkdayCalender.Core.Interfaces.Services;
using WorkdayCalender.Core.Services;
using WorkdayCalender.Infastructure.Context;
using WorkdayCalender.Infastructure.Repositories;

namespace WorkdayCalender.Api
{
    public static class DependencyInjection
    {

        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddDbContext<WorkdayCalenderDbContext>(opt => opt.UseInMemoryDatabase("InMem"));

            services.AddScoped<IHolidayService, HolidayService>();
            services.AddScoped<IWorkDayCalculationService, WorkDayCalculationService>();
            services.AddScoped<ICalculationService, CalculationService>();
            services.AddScoped<IWorkdayCalenderRepository, WorkdayCalenderRepository>();

            return services;
        }

    }
}

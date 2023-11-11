using Capstone.Pages.DB;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Capstone
{
    
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DBClass>();
            
        }
    }
}

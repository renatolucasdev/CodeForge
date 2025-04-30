using BasicCustomerService.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicCustomerService.Configuration
{
    public static class DbContextConfiguration
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            
            builder.Services.AddDbContext<ApiDbContext>(options =>
            { 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            return builder;
        }
    }
}

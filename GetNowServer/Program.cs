using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GetNowServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

// Scaffold-DbContext "server=localhost; port=3306; database=picknow; user=root; password=root; Persist Security Info=False; Connect Timeout=300" Pomelo.EntityFrameworkCore.MySql -OutputDir Models -Context MyDbContext -f

/* cmd (run as Administrator):
 * mysqldump - u'root' - proot picknow > picknow.sql
 */
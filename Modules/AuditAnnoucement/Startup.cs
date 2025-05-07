using AuditAnnoucement.Drivers;
using AuditAnnoucement.Handlers;
using AuditAnnoucement.Migrations;
using AuditAnnoucement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace AuditAnnoucement
{
    public sealed class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services
                .AddContentPart<AuditAnnoucementPart>()
                .UseDisplayDriver<AuditAnnoucementPartDisplayDriver>()
                .AddHandler<AuditAnnoucementPartHandler>();

            services
                .AddScoped<IDataMigration, AuditAnnoucementMigration>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "AuditAnnoucement",
                areaName: "AuditAnnoucement",
                // pattern: "AuditAnnoucement/{controller=Home}/{action=Index}/{id?}"
                pattern: "",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}

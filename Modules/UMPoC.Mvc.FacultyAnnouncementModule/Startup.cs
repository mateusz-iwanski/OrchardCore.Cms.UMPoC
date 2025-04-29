using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Security.Permissions;
using UMPoC.Mvc.FacultyAnnouncementModule.Drivers;
using UMPoC.Mvc.FacultyAnnouncementModule.Handlers;
using UMPoC.Mvc.FacultyAnnouncementModule.Migrations;
using UMPoC.Mvc.FacultyAnnouncementModule.Models;

namespace UMPoC.Mvc.FacultyAnnouncementModule
{
    public sealed class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            //services.AddScoped<IDataMigration, UMPoC.Mvc.FacultyAnnouncementModule.Migrations.FacultyAnnouncementRemovalMigration>();

            services.AddContentPart<FacultyAnnouncementPart>()
                .UseDisplayDriver<FacultyAnnouncementDisplayDriver>(); // jeœli masz DisplayDriver osobno

            // Rejestracja handlera do automatycznego ustawiania CreatedBy/ModifiedBy
            services.AddScoped<IContentPartHandler, FacultyAnnouncementHandler>();

            // register IDataMigration for the FacultyAnnouncementPart for orchard core migration system
            // OC migration system will call the Create method of the FacultyAnnouncementMigrations class
            services.AddScoped<IDataMigration, FacultyAnnouncementMigrations>();

            services.AddScoped<IPermissionProvider, Permissions>();

            services.AddScoped<IContentPartHandler, FacultyAnnouncementHandler>();

            services.AddScoped<IContentPartDisplayDriver, FacultyAnnouncementDisplayDriver>();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Add("/Views/UMPoC.Mvc.FacultyAnnouncementModule/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/UMPoC.Mvc.FacultyAnnouncementModule/Part/{0}.cshtml");
            });


        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "FacultyAnnouncementModule",
                areaName: "UMPoC.Mvc.FacultyAnnouncementModule",
                pattern: "FacultyAnnouncement/{controller=Home}/{action=Index}/{id?}"
            );
        }
    }
}

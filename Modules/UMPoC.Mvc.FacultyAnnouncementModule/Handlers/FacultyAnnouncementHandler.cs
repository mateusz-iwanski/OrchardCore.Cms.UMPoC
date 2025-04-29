using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentManagement;
using UMPoC.Mvc.FacultyAnnouncementModule.Models;

namespace UMPoC.Mvc.FacultyAnnouncementModule.Handlers
{
    public class FacultyAnnouncementHandler : ContentPartHandler<FacultyAnnouncementPart>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FacultyAnnouncementHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override Task InitializingAsync(InitializingContentContext context, FacultyAnnouncementPart part)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";

            part.CreatedBy = userName;
            part.CreatedUtc = DateTime.UtcNow;

            return Task.CompletedTask;
        }

        public override Task UpdatingAsync(UpdateContentContext context, FacultyAnnouncementPart part)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";

            part.ModifiedBy = userName;
            part.ModifiedUtc = DateTime.UtcNow;

            return Task.CompletedTask;
        }
    }
}

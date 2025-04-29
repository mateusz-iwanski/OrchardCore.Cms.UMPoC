using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.ContentFields.Settings; // Nadal potrzebne dla BooleanField
using UMPoC.Mvc.FacultyAnnouncementModule.Models;

namespace UMPoC.Mvc.FacultyAnnouncementModule.Migrations
{
    public class FacultyAnnouncementMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public FacultyAnnouncementMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public async Task<int> CreateAsync()
        {
            await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(FacultyAnnouncementPart), part => part
                .Attachable()
                .WithField("IsReviewed", field => field
                    .OfType("BooleanField")
                    .WithDisplayName("Reviewed")
                    .WithSettings(new BooleanFieldSettings
                    {
                        Label = "Reviewed"
                    })
                )
                .WithDescription("Faculty announcement audit part with audit and review fields.")
            );

            return 1;
        }

        public async Task<int> UpdateFrom1Async()
        {
            await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(FacultyAnnouncementPart), part => part
                .Attachable()
                .WithField("Note", field => field
                    .OfType("HtmlField")
                    .WithDisplayName("Note")
                    .WithSettings(new HtmlFieldSettings
                    {
                        Hint = "A short note related to the announcement."
                    })
                )
                .WithField("IsReviewed", field => field
                    .OfType("BooleanField")
                    .WithDisplayName("Reviewed")
                    .WithSettings(new BooleanFieldSettings
                    {
                        Label = "Reviewed"
                    })
                )
                .WithDescription("Faculty announcement audit part with audit and review fields.")
            );

            return 2;
        }
    }
}

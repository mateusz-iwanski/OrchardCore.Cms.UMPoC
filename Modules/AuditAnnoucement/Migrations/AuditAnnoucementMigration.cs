using AuditAnnoucement.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAnnoucement.Migrations
{
    class AuditAnnoucementMigration : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public AuditAnnoucementMigration(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public async Task<int> CreateAsync()
        {
            await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(AuditAnnoucementPart), part => part
                .Attachable()
                .WithField("Note", field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Note")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "A short note related to the announcement."
                    })
                    .WithEditor("TextArea")
                )
                .WithDescription("Audit announcement part with audit and review fields.")
            );
            return 1;
        }
    }
}

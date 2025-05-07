using AuditAnnoucement.Models;
using OrchardCore.ContentManagement.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AuditAnnoucement.Handlers
{
    public class AuditAnnoucementPartHandler : ContentPartHandler<AuditAnnoucementPart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, AuditAnnoucementPart part)
        {
            // Pobierz wartość pola "Tytul" jako JsonDynamicObject
            var titleField = context.ContentItem.Content?.WydzialPodatkowyOgloszeniaDodaj?.Tytul as dynamic;


            var titleNode = titleField?.Node as JsonObject;
            var title = titleNode?.TryGetPropertyValue("Text", out var textNode) == true ? textNode.GetValue<string>() : null;


            // Pobierz wartość CreatedBy z AuditAnnoucementPart
            var createdBy = part.CreatedBy;

            // Przygotuj DisplayText
            if (!string.IsNullOrEmpty(title))
            {
                // Ogranicz tytuł do 20 znaków i dodaj "..." jeśli jest dłuższy
                var truncatedTitle = title.Length > 20 ? title.Substring(0, 20) + "..." : title;

                // Ustaw DisplayText na "truncatedTitle - CreatedBy"
                context.ContentItem.DisplayText = $"{truncatedTitle} - {createdBy}";
            }

            return base.UpdatedAsync(context, part);
        }


    }
}

using AuditAnnoucement.Models;
using AuditAnnoucement.ViewModels;
using Microsoft.AspNetCore.Http;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAnnoucement.Drivers
{
    // musi być publiczna
    public class AuditAnnoucementPartDisplayDriver : ContentPartDisplayDriver<AuditAnnoucementPart>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditAnnoucementPartDisplayDriver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // create shape for AuditAnnoucementPart
        public override IDisplayResult Display(AuditAnnoucementPart part, BuildPartDisplayContext context)
        {
            return Initialize<AuditAnnoucementPartViewModel>(
                GetDisplayShapeType(context),
                viewModel => PopulateViewModelAsync(part, viewModel))
            .Location("Detail", "Content:5")
            .Location("Summary", "Content:5");
        }


        public override IDisplayResult Edit(AuditAnnoucementPart part, BuildPartEditorContext context)
        {
            return Initialize<AuditAnnoucementPartViewModel>(
                GetEditorShapeType(context),
                model => PopulateViewModelAsync(part, model))
            .Location("Content:5");
        }

        // write update method for AuditAnnoucementPart
        public override async Task<IDisplayResult> UpdateAsync(AuditAnnoucementPart part, UpdatePartEditorContext context)
        {
            // Create a new instance of the view model
            var viewModel = new AuditAnnoucementPartViewModel();

            // Ustaw Prefix na pusty ciąg znaków, jeśli nie używasz prefiksów
            //Prefix w Orchard Core to wartość, która określa „namespace” formularza HTML generowanego dla konkretnego ContentPart – zapewnia
            //unikalność nazw pól w POST, umożliwiając poprawny binding do modelu.Domyślnie jest to nazwa typu parta i używany jest przez asp
            //for oraz TryUpdateModelAsync, by mapować dane z formularza do odpowiednich właściwości modelu.
            if (await context.Updater.TryUpdateModelAsync(viewModel, Prefix))
            {
                // Pobierz nazwę bieżącego użytkownika
                var username = _httpContextAccessor.HttpContext.User.Identity.Name ?? "Anonimowy";

                if (part.CreatedUtc == default(DateTime))
                {
                    // Jeśli to nowy element, ustaw CreatedBy i CreatedUtc
                    part.CreatedBy = username;
                    part.CreatedUtc = DateTime.UtcNow;
                }

                // Ustaw zawsze ModifiedBy i ModifiedUtc
                part.ModifiedBy = username;
                part.ModifiedUtc = DateTime.UtcNow;

                // Przypisz pozostałe wartości z ViewModelu
                part.Note = viewModel.Note;
                part.StatusAfterReview = viewModel.StatusAfterReview;
            }


            // Return the editor shape to re-render the editor with any validation errors
            return Edit(part, context);
        }


        // przypisywanie wartości
        private static void PopulateViewModelAsync(AuditAnnoucementPart part, AuditAnnoucementPartViewModel viewModel)
        {
            viewModel.CreatedBy = part.CreatedBy;
            viewModel.CreatedUtc = part.CreatedUtc;
            viewModel.ModifiedBy = part.ModifiedBy;
            viewModel.ModifiedUtc = part.ModifiedUtc;
            viewModel.Note = part.Note;
            viewModel.StatusAfterReview = part.StatusAfterReview;
        }
    }
}

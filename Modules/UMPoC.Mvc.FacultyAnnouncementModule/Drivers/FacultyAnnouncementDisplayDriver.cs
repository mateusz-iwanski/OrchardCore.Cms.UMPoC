using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;
using UMPoC.Mvc.FacultyAnnouncementModule.Models;
using UMPoC.Mvc.FacultyAnnouncementModule.ViewModels;

namespace UMPoC.Mvc.FacultyAnnouncementModule.Drivers
{
    public class FacultyAnnouncementDisplayDriver : ContentPartDisplayDriver<FacultyAnnouncementPart>
    {
        public override IDisplayResult Display(FacultyAnnouncementPart part, BuildPartDisplayContext context)
        {
            return Initialize<FacultyAnnouncementPartViewModel>("UMPoC.Mvc.FacultyAnnouncementModule.Part.Parts_FacultyAnnouncement_Display", model =>
            {
                model.CreatedBy = part.CreatedBy;
                model.CreatedUtc = part.CreatedUtc;
                model.ModifiedBy = part.ModifiedBy;
                model.ModifiedUtc = part.ModifiedUtc;
                model.Audit = part.Audit;
            }).Location("Detail", "Content");
        }

        public override IDisplayResult Edit(FacultyAnnouncementPart part, BuildPartEditorContext context)
        {
            return Initialize<FacultyAnnouncementPartViewModel>("UMPoC.Mvc.FacultyAnnouncementModule.Part.Parts_FacultyAnnouncement_Edit", model =>
            {
                model.CreatedBy = part.CreatedBy;
                model.CreatedUtc = part.CreatedUtc;
                model.ModifiedBy = part.ModifiedBy;
                model.ModifiedUtc = part.ModifiedUtc;
                model.Audit = part.Audit;
            }).Location("Parts", "Content");
        }
    }
}

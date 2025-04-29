using System;

namespace UMPoC.Mvc.FacultyAnnouncementModule.ViewModels
{
    public class FacultyAnnouncementPartViewModel
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedUtc { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedUtc { get; set; }
        public bool Audit { get; set; }
    }
}

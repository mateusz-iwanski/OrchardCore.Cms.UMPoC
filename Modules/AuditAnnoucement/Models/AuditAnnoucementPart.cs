using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAnnoucement.Models
{
    class AuditAnnoucementPart : ContentPart
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedUtc { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedUtc { get; set; }

        public TextField Note { get; set; }
        
        public ReviewStatus StatusAfterReview { get; set; }
    }

    public enum ReviewStatus
    {
        NotReviewed,
        InReview,
        Approved,
        Published,
        Rejected
    }
}

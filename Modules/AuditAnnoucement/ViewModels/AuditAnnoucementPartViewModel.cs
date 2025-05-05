using AuditAnnoucement.Models;
using OrchardCore.ContentFields.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAnnoucement.ViewModels
{
    // musi być publiczna
    public class AuditAnnoucementPartViewModel
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedUtc { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedUtc { get; set; }

        public TextField Note { get; set; }

        public ReviewStatus StatusAfterReview { get; set; }
    }
}

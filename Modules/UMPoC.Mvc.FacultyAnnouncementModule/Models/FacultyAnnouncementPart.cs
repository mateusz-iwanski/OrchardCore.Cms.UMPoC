using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;

namespace UMPoC.Mvc.FacultyAnnouncementModule.Models
{

    /// <summary>
    /// Represents a content part for faculty announcements, including audit information such as
    /// who created or modified the content, and review history entries.
    /// </summary>
    public class FacultyAnnouncementPart : ContentPart
    {
        /// <summary>
        /// Gets or sets the username or identifier of the user who created the content item.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UTC timestamp indicating when the content item was created.
        /// </summary>
        public DateTime CreatedUtc { get; set; }

        /// <summary>
        /// Gets or sets the username or identifier of the user who last modified the content item.
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the UTC timestamp indicating when the content item was last modified. 
        /// Null if the content item was never modified after creation.
        /// </summary>
        public DateTime? ModifiedUtc { get; set; }

        /// <summary>
        /// Gets or sets an optional note explaining the reason or context for the last modification.
        /// </summary>
        public string ChangeNote { get; set; }

        /// <summary>
        /// Gets or sets a list of names of fields that were changed during the last update.
        /// </summary>
        public List<string> LastChangedFields { get; set; } = new();

        /// <summary>
        /// Gets or sets a value indicating whether auditing is enabled for this content part.
        /// Auditing tracks who, when, and what changes were made to the content.
        /// </summary>
        public bool Audit { get; set; }

        /// <summary>
        /// Gets or sets the collection of review audit entries recording the review history of the content.
        /// </summary>
        public List<ReviewAuditEntry> ReviewAuditEntries { get; set; } = new();
    }

    /// <summary>
    /// Represents a single entry in the review history, capturing details of a review action
    /// such as the reviewer, date, resulting status, and optional notes.
    /// </summary>
    public class ReviewAuditEntry
    {
        /// <summary>
        /// Gets or sets the username or identifier of the reviewer.
        /// </summary>
        public string ReviewedBy { get; set; }

        /// <summary>
        /// Gets or sets the UTC timestamp indicating when the review was performed.
        /// </summary>
        public DateTime ReviewedDate { get; set; }

        /// <summary>
        /// Gets or sets the resulting review status after the review was completed.
        /// </summary>
        public ReviewStatus StatusAfterReview { get; set; }

        /// <summary>
        /// Gets or sets an optional note explaining the decision or context of the review.
        /// </summary>
        public string Note { get; set; }
    }

    /// <summary>
    /// Specifies the possible statuses of a content item during and after review.
    /// </summary>
    public enum ReviewStatus
    {
        /// <summary>
        /// Content has not been reviewed yet.
        /// </summary>
        NotReviewed,

        /// <summary>
        /// Content is currently under review.
        /// </summary>
        InReview,

        /// <summary>
        /// Content has been approved after review.
        /// </summary>
        Approved,

        /// <summary>
        /// Content has been approved and published.
        /// </summary>
        Published,

        /// <summary>
        /// Content has been reviewed and rejected.
        /// </summary>
        Rejected
    }
}

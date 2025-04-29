using OrchardCore.Security.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UMPoC.Mvc.FacultyAnnouncementModule
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageFacultyAnnouncements = new Permission("ManageFacultyAnnouncements", "Manage Faculty Announcements");

        public static readonly Permission EditFacultyAnnouncement = new Permission("EditFacultyAnnouncement", "Edit Faculty Announcement");
        public static readonly Permission CreateFacultyAnnouncement = new Permission("CreateFacultyAnnouncement", "Create Faculty Announcement");
        public static readonly Permission DeleteFacultyAnnouncement = new Permission("DeleteFacultyAnnouncement", "Delete Faculty Announcement");

        public static readonly Permission PublishFacultyAnnouncement = new Permission("PublishFacultyAnnouncement", "Publish Faculty Announcement");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult<IEnumerable<Permission>>(new[]
            {
                ManageFacultyAnnouncements,
                EditFacultyAnnouncement,
                CreateFacultyAnnouncement,
                DeleteFacultyAnnouncement
            });
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator", // <-- tutaj STRING, bez StandardRoles
                    Permissions = new[]
                    {
                        ManageFacultyAnnouncements,
                        EditFacultyAnnouncement,
                        CreateFacultyAnnouncement,
                        DeleteFacultyAnnouncement
                    }
                }
            };
        }
    }
}

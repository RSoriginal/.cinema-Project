using Cinema.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cinema.UI.Areas.Admin.ViewModels
{
    public class ChangeRoleViewModel
    {
        public Guid? UserId { get; set; }
        public string? UserEmail { get; set; }
        public List<CinemaRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<CinemaRole>();
            UserRoles = new List<string>();
        }
    }
}

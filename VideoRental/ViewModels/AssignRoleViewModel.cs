using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using WebMvcPruebaMosh.Areas.Identity.Data;

namespace WebMvcPruebaMosh.ViewModels
{
    public class AssignRoleViewModel
    {
        public List<User> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public string SelectedUserId { get; set; }
        public string SelectedRole { get; set; }
    }
}
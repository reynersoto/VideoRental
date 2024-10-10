using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMvcPruebaMosh.Areas.Identity.Data;
using WebMvcPruebaMosh.ViewModels; // Cambia por el namespace donde tengas tus modelos

public class UserRoleController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRoleController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // Método para mostrar la lista de usuarios y roles
    public async Task<IActionResult> AssignRole()
    {
        var users = _userManager.Users.ToList();
        var roles = _roleManager.Roles.ToList();

        // Retornar la lista de usuarios y roles a la vista
        return View(new AssignRoleViewModel
        {
            Users = users,
            Roles = roles
        });
    }

    // Método para asignar un rol a un usuario
    [HttpPost]
    public async Task<IActionResult> AssignRole(string SelectedUserId, string SelectedRole)
    {
        var user = await _userManager.FindByIdAsync(SelectedUserId);

        if (user == null)
        {
            return NotFound();
        }

        if (await _roleManager.RoleExistsAsync(SelectedRole))
        {
            var result = await _userManager.AddToRoleAsync(user, SelectedRole);
            if (result.Succeeded)
            {
                ViewData["Message"] = $"Rol '{SelectedRole}' asignado al usuario '{user.UserName}' exitosamente.";
                return RedirectToAction("AssignRole");
            }

            // Si hubo errores, retornarlos a la vista
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return RedirectToAction("AssignRole");
    }
}
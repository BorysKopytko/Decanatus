using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Decanatus.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IUnitOfWork unitOfWork;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.repositoryWrapper = repositoryWrapper;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Configure()
        {
            List<UserListViewModel> model = new List<UserListViewModel>();
            model = userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                Email = u.Email
            }).ToList();
            return View(model);
        }

        //GET
        public IActionResult CreateChoose()
        {
            var model = new ChooseRoleViewModel();
            model.Roles = roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View(model);
        }

        //GET
        [HttpPost]
        public async Task<IActionResult> CreateChoose(ChooseRoleViewModel chooseRoleViewModel)
        {
            if (chooseRoleViewModel.Role == "Адміністратор")
            {
                return RedirectToAction(nameof(CreateAdministrator));
            }
            else if (chooseRoleViewModel.Role == "Викладач")
            {
                return RedirectToAction(nameof(CreateLecturer));
            }
            else if (chooseRoleViewModel.Role == "Студент")
            {
                return RedirectToAction(nameof(CreateStudent));
            }
            return View();
        }

        public IActionResult CreateAdministrator()
        {

            var administratorViewModel = new AdministratorViewModel();
            administratorViewModel.ApplicationRoles.Add(new SelectListItem { Value = roleManager.Roles.FirstOrDefault(x => x.Name == "Адміністратор").Id, Text = "Адміністратор" });
            return View(administratorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdministrator(AdministratorViewModel model)
        {
            var administrator = new Administrator();

            administrator.MobilePhoneNumber = model.MobilePhoneNumber;
            administrator.LastName = model.LastName;
            administrator.FirstName = model.FirstName;
            administrator.MiddleName = model.MiddleName;
            administrator.BirthDate = model.BirthDate;
            administrator.Sex = model.Sex;
            administrator.EmailAdress = model.Email;

            await repositoryWrapper.AdministratorRepository.AddAsync(administrator);
            await unitOfWork.Commit();

            ApplicationUser user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PersonId = repositoryWrapper.AdministratorRepository.GetAllAsync().Result.FirstOrDefault(x => x.EmailAdress == model.Email).Id
            };
            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                if (applicationRole != null)
                {
                    IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction(nameof(Configure));
                    }
                }
            }

            return View("CreateAdministrator", model);
        }

        public IActionResult CreateLecturer()
        {
            var lecturerViewModel = new LecturerViewModel();
            lecturerViewModel.ApplicationRoles.Add(new SelectListItem { Value = roleManager.Roles.FirstOrDefault(x => x.Name == "Викладач").Id, Text = "Викладач" });
            return View(lecturerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLecturer(LecturerViewModel model)
        {
            var lecturer = new Lecturer();

            lecturer.MobilePhoneNumber = model.MobilePhoneNumber;
            lecturer.LastName = model.LastName;
            lecturer.FirstName = model.FirstName;
            lecturer.MiddleName = model.MiddleName;
            lecturer.BirthDate = model.BirthDate;
            lecturer.Sex = model.Sex;
            lecturer.EmailAdress = model.Email;
            lecturer.Position = model.Position;

            await repositoryWrapper.LecturerRepository.AddAsync(lecturer);
            await unitOfWork.Commit();

            ApplicationUser user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PersonId = repositoryWrapper.LecturerRepository.GetAllAsync().Result.FirstOrDefault(x => x.EmailAdress == model.Email).Id
            };
            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                if (applicationRole != null)
                {
                    IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction(nameof(Configure));
                    }
                }
            }

            return View("CreateLecturer", model);
        }

        public IActionResult CreateStudent()
        {
            var studentViewModel = new StudentViewModel();
            studentViewModel.ApplicationRoles.Add(new SelectListItem { Value = roleManager.Roles.FirstOrDefault(x => x.Name == "Студент").Id, Text = "Студент" });
            studentViewModel.Groups = repositoryWrapper.GroupRepository.GetAllAsync().Result.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return View(studentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentViewModel model)
        {
            var student = new Student();

            student.MobilePhoneNumber = model.MobilePhoneNumber;
            student.LastName = model.LastName;
            student.FirstName = model.FirstName;
            student.MiddleName = model.MiddleName;
            student.BirthDate = model.BirthDate;
            student.Sex = model.Sex;
            student.EmailAdress = model.Email;
            student.OrderNumber = model.OrderNumber;
            student.GradebookNumber = model.GradebookNumber;
            student.OrderDate = model.OrderDate;
            student.GraduateDate = model.GraduateDate;
            student.GroupId = model.GroupId;
            student.StudyingForm = model.StudyingForm;

            await repositoryWrapper.StudentRepository.AddAsync(student);
            await unitOfWork.Commit();

            ApplicationUser user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PersonId = repositoryWrapper.StudentRepository.GetAllAsync().Result.FirstOrDefault(x => x.EmailAdress == model.Email).Id
            };
            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                if (applicationRole != null)
                {
                    IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction(nameof(Configure));
                    }
                }
            }

            return View("CreateStudent", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            EditUserViewModel model = new EditUserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    model.Email = user.Email;
                    model.ApplicationRoleId = roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).Id;
                }
            }
            return View(nameof(Edit), model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditUserViewModel model)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                string existingRole = userManager.GetRolesAsync(user).Result.Single();
                string existingRoleId = roleManager.Roles.Single(r => r.Name == existingRole).Id;
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    if (existingRoleId != model.ApplicationRoleId)
                    {
                        IdentityResult roleResult = await userManager.RemoveFromRoleAsync(user, existingRole);
                        if (roleResult.Succeeded)
                        {
                            ApplicationRole applicationRole = await roleManager.FindByIdAsync(model.ApplicationRoleId);
                            if (applicationRole != null)
                            {
                                IdentityResult newRoleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                                if (newRoleResult.Succeeded)
                                {
                                    return RedirectToAction(nameof(Configure));
                                }
                            }
                        }
                    }
                    else
                    {
                        return RedirectToAction(nameof(Configure));
                    }

                }
            }
            return View(nameof(Edit), model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    name = applicationUser.Email;
                }
            }
            return View(nameof(Delete), name);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(applicationUser);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Configure));
                    }
                }
            }
            return View();
        }
    }
}

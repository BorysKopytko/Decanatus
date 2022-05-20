//using Decanatus.BLL.ViewModels;
//using Decanatus.DAL.Data;
//using Decanatus.DAL.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Decanatus.Web.Controllers
//{
//    public class RoleController : Controller
//    {
//        private readonly RoleManager<ApplicationRole> roleManager;

//        public RoleController(RoleManager<ApplicationRole> roleManager)
//        {
//            this.roleManager = roleManager;
//        }

//        public IActionResult Configure()
//        {
//            List<RoleListViewModel> model = new List<RoleListViewModel>();
//            model = roleManager.Roles.Select(r => new RoleListViewModel
//            {
//                RoleName = r.Name,
//                Id = r.Id,
//            }).ToList();
//            return View(model);
//        }

//        public async Task<IActionResult> CreateOrEdit(string id)
//        {
//            RoleViewModel model = new RoleViewModel();
//            if (!String.IsNullOrEmpty(id))
//            {
//                ApplicationRole applicationRole = await roleManager.FindByIdAsync(id);
//                if (applicationRole != null)
//                {
//                    model.Id = applicationRole.Id;
//                    model.RoleName = applicationRole.Name;
//                }
//            }
//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateOrEdit(string id, RoleViewModel model)
//        {

//            bool isExist = !String.IsNullOrEmpty(id);
//            ApplicationRole applicationRole = isExist ? await roleManager.FindByIdAsync(id) :
//           new ApplicationRole
//           {

//           };
//            applicationRole.Name = model.RoleName;
//            IdentityResult roleRuslt = isExist ? await roleManager.UpdateAsync(applicationRole)
//                                                : await roleManager.CreateAsync(applicationRole);
//            if (roleRuslt.Succeeded)
//            {
//                return RedirectToAction(nameof(Configure));
//            }

//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Delete(string id)
//        {
//            string name = string.Empty;
//            if (!String.IsNullOrEmpty(id))
//            {
//                ApplicationRole applicationRole = await roleManager.FindByIdAsync(id);
//                if (applicationRole != null)
//                {
//                    name = applicationRole.Name;
//                }
//            }
//            return View(nameof(Delete), name);
//        }

//        [HttpPost]
//        [ActionName("Delete")]
//        public async Task<IActionResult> DeletePOST(string id)
//        {
//            if (!String.IsNullOrEmpty(id))
//            {
//                ApplicationRole applicationRole = await roleManager.FindByIdAsync(id);
//                if (applicationRole != null)
//                {
//                    IdentityResult roleRuslt = roleManager.DeleteAsync(applicationRole).Result;
//                    if (roleRuslt.Succeeded)
//                    {
//                        return RedirectToAction(nameof(Configure));
//                    }
//                }
//            }

//            return View();
//        }
//    }
//}

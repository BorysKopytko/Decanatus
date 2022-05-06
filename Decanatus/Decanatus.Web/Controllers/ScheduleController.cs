﻿using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Decanatus.Web.Controllers
{
    [Authorize(Roles = "Адміністратор")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task<IActionResult> Configure()
        {
            var model = await _scheduleService.GetLessonsAsync();
            return View(model);
        }

        public async Task<IActionResult> StudentSchedule(string dayType)
        {
            var model = await _scheduleService.GetStudentLessonsAsync(dayType);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int id, Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _scheduleService.AddNewLessonAsync(lesson);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        //GET
        public IActionResult Create()
        {
            var lessonViewModel = _scheduleService.CreateLessonViewModel();
            return View(lessonViewModel);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonViewModel lessonViewModel)
        {
            await _scheduleService.CreateLessonAsync(lessonViewModel);
            return RedirectToAction(nameof(Configure));
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var lessonViewModel = _scheduleService.GetLessonViewModel(id);

            if (lessonViewModel == null)
            {
                return NotFound();
            }

            return View(lessonViewModel);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit(LessonViewModel lessonViewModel)
        {
            await _scheduleService.UpdateLessonAsync(lessonViewModel);
            return RedirectToAction(nameof(Configure));
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var lessonViewModel = _scheduleService.GetLessonViewModel(id);

            if (lessonViewModel == null)
            {
                return NotFound();
            }

            return View(lessonViewModel);
        }


        //POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            await _scheduleService.DeleteLessonAsync(id);
            return RedirectToAction(nameof(Configure));
        }
    }
}

﻿using AutoMapper;
using Decanatus.BLL.DTOs;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.ObjectModel;

namespace Decanatus.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ScheduleService(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork, ApplicationDbContext context, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> LessonsInclude()
        {
            Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> expr = x => x.Include(i => i.Audience).Include(c => c.Subject).Include(a => a.Lecturers).Include(b => b.Groups).Include(b => b.LessonNumber);
            return expr;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsAsync()
        {
            var include = LessonsInclude();
            var lessons = await _repositoryWrapper.LessonRepository.Includer(include);
            return lessons;
        }

        public async Task<IEnumerable<Lesson>> GetStudentLessonsAsync(string dayType)
        {

            var include = LessonsInclude();
            var lessons = await _repositoryWrapper.LessonRepository.Includer(include);
            return lessons;
        }

        public void AddNewLessonAsync(Lesson newLesson)
        {
            _repositoryWrapper.LessonRepository.UpdateAsync(newLesson);
            _unitOfWork.Commit();
        }

        public Lesson FindLessonAsync(int? id)
        {
            var include = LessonsInclude();
            var lesson = _repositoryWrapper.LessonRepository.Includer(include).Result.FirstOrDefault(x => x.Id == id);
            return lesson;
        }

        public LessonViewModel GetLessonViewModel(int? id)
        {
            var lessonViewModel = new LessonViewModel();

            var include = LessonsInclude();
            var lesson = _repositoryWrapper.LessonRepository.Includer(include).Result.FirstOrDefault(x => x.Id == id);

            lessonViewModel.Id = lesson.Id;
            lessonViewModel.LessonNumber = lesson.LessonNumberId;
            lessonViewModel.LessonType = lesson.LessonType;
            lessonViewModel.Audience = lesson.AudienceId;
            lessonViewModel.DayOfWeek = lesson.DayOfWeek;
            lessonViewModel.LessonWeekType = lesson.LessonWeekType;
            lessonViewModel.Subject = lesson.SubjectId;
            lessonViewModel.Groups = lesson.Groups.Select(g => g.Id);
            lessonViewModel.Lecturers = lesson.Lecturers.Select(l => l.Id);

            var subjects = _repositoryWrapper.SubjectRepository.GetAllAsync().Result;
            var audiences = _repositoryWrapper.AudienceRepository.GetAllAsync().Result;
            var lecturers = _repositoryWrapper.LecturerRepository.GetAllAsync().Result;
            var groups = _repositoryWrapper.GroupRepository.GetAllAsync().Result;

            lessonViewModel.AllLessonNumbers = _repositoryWrapper.LessonNumberRepository.GetAllAsync().Result.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Number.ToString() }).ToList();
            lessonViewModel.AllSubjects = _repositoryWrapper.SubjectRepository.GetAllAsync().Result.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
            lessonViewModel.AllAudiences = _repositoryWrapper.AudienceRepository.GetAllAsync().Result.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            lessonViewModel.AllLecturers = _repositoryWrapper.LecturerRepository.GetAllAsync().Result.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.LastName + " " + l.FirstName + " " + l.MiddleName + " " + "(" + l.Position.ToString() + ")" }).ToList();
            lessonViewModel.AllGroups = _repositoryWrapper.GroupRepository.GetAllAsync().Result.Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name }).ToList();

            return lessonViewModel;
        }

        public async Task<bool> UpdateLessonAsync(LessonViewModel lessonViewModel)
        {
            var include = LessonsInclude();
            var lesson2 = _repositoryWrapper.LessonRepository.Includer(include).Result.FirstOrDefault(x => x.Id == lessonViewModel.Id);

            await _repositoryWrapper.LessonRepository.DeleteAsync(lesson2);
            await _unitOfWork.Commit();

            var lesson = lesson2;

            lesson.Id = lessonViewModel.Id; 
            lesson.LessonType = lessonViewModel.LessonType;
            lesson.LessonWeekType = lessonViewModel.LessonWeekType;
            lesson.DayOfWeek = lessonViewModel.DayOfWeek;
            lesson.LessonNumber = _repositoryWrapper.LessonNumberRepository.GetByIdAsync(Convert.ToInt32(lessonViewModel.LessonNumber)).Result;
            lesson.Audience = _repositoryWrapper.AudienceRepository.GetByIdAsync(Convert.ToInt32(lessonViewModel.Audience)).Result;
            lesson.Subject = _repositoryWrapper.SubjectRepository.GetByIdAsync(Convert.ToInt32(lessonViewModel.Subject)).Result;
            lesson.LessonNumberId = lessonViewModel.LessonNumber;
            lesson.AudienceId = _repositoryWrapper.AudienceRepository.GetByIdAsync(Convert.ToInt32(lessonViewModel.Audience)).Result.Id;
            lesson.SubjectId = _repositoryWrapper.SubjectRepository.GetByIdAsync(Convert.ToInt32(lessonViewModel.Subject)).Result.Id;
            lesson.Lecturers = new Collection<Lecturer>();
            lesson.Groups = new Collection<Group>();

            foreach (var lecturer in lessonViewModel.Lecturers)
            {
                lesson.Lecturers.Add(_repositoryWrapper.LecturerRepository.GetByIdAsync(Convert.ToInt32(lecturer)).Result);
            }

            foreach (var group in lessonViewModel.Groups)
            {
                lesson.Groups.Add(_repositoryWrapper.GroupRepository.GetByIdAsync(Convert.ToInt32(group)).Result);
            }



            await _repositoryWrapper.LessonRepository.AddAsync(lesson);
            await _unitOfWork.Commit();

            return true;
        }
    }
}
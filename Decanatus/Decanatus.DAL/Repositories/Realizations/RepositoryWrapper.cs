using Decanatus.DAL.Data;
using Decanatus.DAL.Repositories.Interfaces;

namespace Decanatus.DAL.Repositories.Realizations
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private ApplicationDbContext _dbContext;

        private IAudienceRepository _audienceRepository;

        private IFacultyRepository _facultyRepository;

        private IGradeRepository _gradeRepository;

        private IGroupRepository _groupRepository;

        private ILecturerRepository _lecturerRepository;

        private ILessonRepository _lessonRepository;

        private ISpecialityRepository _specialityRepository;

        private IStudentRepository _studentRepository;
        private ILessonNumberRepository _lessonNumberRepository;

        private ISubjectRepository _subjectRepository;

        public IAudienceRepository AudienceRepository
        {
            get
            {
                if (_audienceRepository == null)
                {
                    _audienceRepository = new AudienceRepository(_dbContext);
                }
                return _audienceRepository;
            }
        }

        public IFacultyRepository FacultyRepository
        {
            get
            {
                if (_facultyRepository == null)
                {
                    _facultyRepository = new FacultyRepository(_dbContext);
                }
                return _facultyRepository;
            }
        }        

        public IGradeRepository GradeRepository
        {
            get
            {
                if (_gradeRepository == null)
                {
                    _gradeRepository = new GradeRepository(_dbContext);
                }
                return _gradeRepository;
            }
        }

        public IGroupRepository GroupRepository
        {
            get
            {
                if (_groupRepository == null)
                {
                    _groupRepository = new GroupRepository(_dbContext);
                }
                return _groupRepository;
            }
        }

        public ILecturerRepository LecturerRepository
        {
            get
            {
                if (_lecturerRepository == null)
                {
                    _lecturerRepository = new LecturerRepository(_dbContext);
                }
                return _lecturerRepository;
            }
        }

        public ILessonRepository LessonRepository
        {
            get
            {
                if (_lessonRepository == null)
                {
                    _lessonRepository = new LessonRepository(_dbContext);
                }
                return _lessonRepository;
            }
        }

        public ISpecialityRepository SpecialityRepository
        {
            get
            {
                if (_specialityRepository == null)
                {
                    _specialityRepository = new SpecialityRepository(_dbContext);
                }
                return _specialityRepository;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_dbContext);
                }
                return _studentRepository;
            }
        }

        public ISubjectRepository SubjectRepository
        {
            get
            {
                if (_subjectRepository == null)
                {
                    _subjectRepository = new SubjectRepository(_dbContext);
                }
                return _subjectRepository;
            }
        }


        public ILessonNumberRepository LessonNumberRepository
        {
            get
            {
                if (_lessonNumberRepository == null)
                {
                    _lessonNumberRepository = new LessonNumberRepository(_dbContext);
                }
                return _lessonNumberRepository;
            }
        }

        public RepositoryWrapper(ApplicationDbContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
 
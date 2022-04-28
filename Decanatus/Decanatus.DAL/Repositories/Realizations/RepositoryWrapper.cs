using Decanatus.DAL.Data;
using Decanatus.DAL.Repositories.Interfaces;

namespace Decanatus.DAL.Repositories.Realizations
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private ApplicationDbContext _dbContext;
        private IGradeRepository _gradeRepository;
        private ILessonRepository _lessonRepository;
        private IStudentRepository _studentRepository;

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
 
using System;
using CourseCompanion.Shared.Model;

namespace CourseCompanion.Shared.Services
{
    public interface ICourseService
    {
        event Action<CourseDetails> OnCourseAdd;
        void SendCourse(CourseDetails courseAdded);
    }

    public class CourseService : ICourseService
    {
        public event Action<CourseDetails> OnCourseAdd;

        public void SendCourse(CourseDetails courseAdded)
        {
            OnCourseAdd?.Invoke(courseAdded);
        }
    }
}


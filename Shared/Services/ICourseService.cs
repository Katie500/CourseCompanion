using System;
using CourseCompanion.Shared.Model;

namespace CourseCompanion.Shared.Services
{
    public interface ICourseService
    {
        event Action<CourseDetails> OnCourseEvent;
        void SendCourse(CourseDetails courseAdded);
        void RemoveCourse(CourseDetails courseRemoved);
    }

    public class CourseService : ICourseService
    {
        public event Action<CourseDetails> OnCourseEvent;

        public void SendCourse(CourseDetails courseAdded)
        {
            OnCourseEvent?.Invoke(courseAdded);
        }

        public void RemoveCourse(CourseDetails courseRemoved)
        {
            OnCourseEvent?.Invoke(courseRemoved);
        }

    }
}


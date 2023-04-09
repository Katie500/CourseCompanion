/*
 Service message layout referenced from:
https://jasonwatmore.com/post/2020/07/30/aspnet-core-blazor-webassembly-communication-between-components
 */

using System;
using CourseCompanion.Shared.Model;

namespace CourseCompanion.Shared.Services
{
    public interface ICourseService
    {
        event Action<CourseDetails> OnCourseEvent;
        void SendCourse_toMain(CourseDetails courseAdded);
        void SendCourse_toSem(CourseDetails courseAdded);
        void RemoveCourse_fromMain(CourseDetails courseRemoved);
        void RemoveCourse_fromSem(CourseDetails courseRemoved);
    }

    public class CourseService : ICourseService
    {
        public event Action<CourseDetails> OnCourseEvent;

        public void SendCourse_toMain(CourseDetails courseAdded)
        {
            OnCourseEvent?.Invoke(courseAdded);
        }

        public void SendCourse_toSem(CourseDetails courseAdded)
        {
            OnCourseEvent?.Invoke(courseAdded);
        }

        public void RemoveCourse_fromMain(CourseDetails courseRemoved)
        {
            OnCourseEvent?.Invoke(courseRemoved);
        }

        public void RemoveCourse_fromSem(CourseDetails courseRemoved)
        {
            OnCourseEvent?.Invoke(courseRemoved);
        }

    }
}


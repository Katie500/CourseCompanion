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
        void CourseEvent(CourseDetails course);
    }

    public class CourseService : ICourseService
    {
        public event Action<CourseDetails> OnCourseEvent;

        public void CourseEvent(CourseDetails courseAdded)
        {
            OnCourseEvent?.Invoke(courseAdded);
        }

    }
}


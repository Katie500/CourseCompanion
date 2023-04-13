/*
 * StateContainer.cs
 * Handles all the course lists and related variables (outside of a course object itself)
 */

using System;
using CourseCompanion.Shared.Model;
using CourseCompanion.Shared;

namespace CourseCompanion.Shared.State
{

    public class StateContainer
    {
        public event Action OnStateChange;

        public List<CourseDetails> fullList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> filteredList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> fallList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> winterList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> springList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> summerList { get; set; } = new List<CourseDetails>();

        public int fall_TotalCredits = 0;
        public int winter_TotalCredits = 0;
        public int spring_TotalCredits = 0;
        public int summer_TotalCredits = 0;

        // preliminary sort function
        public void sortList(List<CourseDetails> list)
        {
            list.OrderBy(o => o.Id).ToList();
        }

        public void AddCourse_toFilteredList(CourseDetails course)
        {
            filteredList.Insert(0, course);
        }

        // course was added to semesters, remove from main list and add it to the semester list
        public void RemoveCourse_fromFilteredList(CourseDetails course)
        {
            Console.WriteLine("removed course " + course.Id + " from StateContainer");
            filteredList.Remove(course);
            NotifyStateChanged();

        }

        // because im lazy and don't want to rewrite if statements
        public string GetSemester(CourseDetails course)
        {
            if ((course.Semester).Contains("fall", StringComparison.OrdinalIgnoreCase))
                { return "fall"; }
            if ((course.Semester).Contains("winter", StringComparison.OrdinalIgnoreCase))
                { return "winter"; }
            if ((course.Semester).Contains("spring", StringComparison.OrdinalIgnoreCase))
                { return "spring"; }
            if ((course.Semester).Contains("summer", StringComparison.OrdinalIgnoreCase))
                { return "summer"; }
            else { return "fall"; }

        }

        // a course was sent from the main list to the semester list
        public void AddCourse_toSemesterList(CourseDetails addCourse)
        {
            string sem = GetSemester(addCourse);

            // add courses based on semester
            switch (sem)
            {
                case "fall":
                    fallList.Add(addCourse); fall_TotalCredits += addCourse.Credits;
                    break;

                case "winter":
                    winterList.Add(addCourse); winter_TotalCredits += addCourse.Credits;
                    break;

                case "spring":
                    springList.Add(addCourse); spring_TotalCredits += addCourse.Credits;
                    break;

                case "summer":
                    summerList.Add(addCourse); summer_TotalCredits += addCourse.Credits;
                    break;
            }

            Console.WriteLine(addCourse.Id + " added to " + addCourse.Semester);
            NotifyStateChanged();

        }

        // a course was removed from the semester list
        public void RemoveCourse_fromSemesterList(CourseDetails course)
        {
            string sem = GetSemester(course);

            // add courses based on semester
            switch (sem)
            {
                case "fall":
                    fallList.Remove(course); fall_TotalCredits -= course.Credits;
                    break;

                case "winter":
                    winterList.Remove(course); winter_TotalCredits -= course.Credits;
                    break;

                case "spring":
                    springList.Remove(course); spring_TotalCredits -= course.Credits;
                    break;

                case "summer":
                    summerList.Remove(course); summer_TotalCredits += course.Credits;
                    break;
            }

            Console.WriteLine(course.Id + " removed from " + course.Semester);
            NotifyStateChanged();

        }

        // user clicked the reset button
        public void ClearLists()
        {
            // TODO: UI popup with confirmation
            // clear all the semester lists and place them back into the main list (resetting it is also fine)
            fallList.Clear();
            winterList.Clear();
            springList.Clear();
            summerList.Clear();

            fall_TotalCredits = 0;
            winter_TotalCredits = 0;
            spring_TotalCredits = 0;
            summer_TotalCredits = 0;
            NotifyStateChanged();

        }
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
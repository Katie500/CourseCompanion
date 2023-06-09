﻿/*
 * StateContainer.cs
 * Handles all the course lists and related variables (outside of a course object itself)
 */

using System;
using CourseCompanion.Shared;
using CourseCompanion.Shared.Model;
using CourseCompanion.Shared.Services;
using CourseCompanion.Shared.Filter;
namespace CourseCompanion.Shared.State
{

    public class StateContainer
    {
        public event Action OnStateChange;

        public CourseService courseService = new CourseService();

        public List<CourseDetails> fullList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> searchedList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> filteredList { get; set; } = new List<CourseDetails>();

        public List<CourseDetails> fallList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> winterList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> springList { get; set; } = new List<CourseDetails>();
        public List<CourseDetails> summerList { get; set; } = new List<CourseDetails>();

        public int fall_TotalCredits = 0;
        public int winter_TotalCredits = 0;
        public int spring_TotalCredits = 0;
        public int summer_TotalCredits = 0;

        public int filterNum = 0;

        // preliminary sort function
        public void sortList(List<CourseDetails> list)
        {
            list.OrderBy(o => o.Id).ToList();
        }

        public void AddCourse_toSearchedList(CourseDetails course)
        {
            Console.WriteLine("add course " + course.Id + " to searchList");

            searchedList.Insert(0, course);
        }

        // course was added to semesters, remove from main list and add it to the semester list
        public void RemoveCourse_fromSearchedList(CourseDetails course)
        {
            Console.WriteLine("removed course " + course.Id + " from StateContainer");
            searchedList.Remove(course);
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

            // remove courses based on semester
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
                    summerList.Remove(course); summer_TotalCredits -= course.Credits;
                    break;
            }

            Console.WriteLine(course.Id + " removed from " + course.Semester);
            NotifyStateChanged();

        }

        // user clicked the reset button
        public List<CourseDetails> ResetState()
        {
            Console.WriteLine("State reset has been called");

            // TODO: UI popup with confirmation

            // clear all the semester lists
            fallList.Clear();
            winterList.Clear();
            springList.Clear();
            summerList.Clear();

            fall_TotalCredits = 0;
            winter_TotalCredits = 0;
            spring_TotalCredits = 0;
            summer_TotalCredits = 0;

            // reset the main list back to default
            searchedList = fullList;

            //foreach (var course in (searchedList).OrderBy(x => x.Id))
            //    Console.WriteLine(course.Id);
            
            // reset filter

            return searchedList;

        }

        public void UpdateFilteredList(List<CourseDetails> newList) {

            // DEBUG
            // Console.WriteLine("\n       State.UpdateFilteredList()");
            // Console.WriteLine("\n       --------  searchList  -------");
            // foreach (var course in searchedList) {
            //     Console.WriteLine("    " + course.Semester);
            // }
            // Console.WriteLine("\n       --------  filteredList  -------");
            // foreach (var course in newList) {
            //     Console.WriteLine("    " + course.Semester);
            // }
            // DEBUG
            
            filteredList.Clear();
            filteredList.AddRange(newList);
            NotifyStateChanged();
        }

        // private void NotifyStateChanged() => OnStateChange?.Invoke();
        private void NotifyStateChanged() {
            
            // DEBUG
            // Console.WriteLine("\n       -----  NotifyStateChanged()  -----");
            // Console.WriteLine("\n       --------  searchList  -------");
            // foreach (var course in searchedList) {
            //     Console.WriteLine("    " + course.Semester);
            // }
            // DEBUG

            OnStateChange?.Invoke();
        }

    }
}
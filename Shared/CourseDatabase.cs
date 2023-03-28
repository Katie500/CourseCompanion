using System;
namespace CourseCompanion.Shared
{
    public class CourseDatabase
    {
        public List<CourseDetails> Courses { get; set; } = new List<CourseDetails>()
    {
        new CourseDetails()
        {
            Id = "CPSC 231",
            Title = "Intro to CPSC for CPSC Majors I",
            Description = "Introduction to problem solving, the analysis and design of small-scale computational systems, and implementation using a procedural programming language. For computer science majors.",
            Instructor = "Dr. Smith",
            Levels = "Undergraduate",
            Credits = "3.0",
            Category = "Computer Science",
            Semester = "Fall 2023",
            Faculty = "Science",
        },
        new CourseDetails()
        {
            Id = "CPSC 233",
            Title = "Intro to CPSC for CPSC Majors II",
            Description = "Continuation of CPSC 231. Topics include data structures and algorithms, recursion, and object-oriented programming. For computer science majors.",
            Instructor = "Dr. Johnson",
            Levels = "Undergraduate",
            Credits = "3.0",
            Category = "Computer Science",
            Semester = "Winter 2024",
            Faculty = "Science",
        },
        new CourseDetails()
        {
            Id = "PHIL 314",
            Title = "Information Technology Ethics",
            Description = "An examination of ethical issues in the use of information technology. Topics include privacy, intellectual property, and the impact of technology on society.",
            Instructor = "Dr. Lee",
            Levels = "Undergraduate",
            Credits = "3.0",
            Category = "Philosophy",
            Semester = "Winter 2024",
            Faculty = "Arts",
        },
        new CourseDetails()
        {
            Id = "MATH 211",
            Title = "Linear Methods I",
            Description = "Systems of linear equations, matrices, determinants, vector spaces, linear transformations, and eigenvalues. Applications to geometry and systems of differential equations.",
            Instructor = "Dr. Brown",
            Levels = "Undergraduate",
            Credits = "3.0",
            Category = "Mathematics",
            Semester = "Fall 2023",
            Faculty = "Science",
        },
        new CourseDetails()
        {
            Id = "MATH 265",
            Title = "Introductory Calculus",
            Description = "A calculus course covering limits, derivatives, integrals, and applications. For students who have not taken a calculus course before.",
            Instructor = "Dr. Davis",
            Levels = "Undergraduate",
            Credits = "3.0",
            Category = "Mathematics",
            Semester = "Fall 2023",
            Faculty = "Science",
        },
    };
    }



    public class CourseDetails
    {

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Instructor { get; set; }

        public string Levels { get; set; }

        public string Credits { get; set; }

        public string Category { get; set; }

        public string Semester { get; set; }

        public string Faculty { get; set; }

    }
}


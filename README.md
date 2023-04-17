# CourseCompanion
CPSC 481 W23 Project - Group 5

A system to help students at the University of Calgary plan their courses.

## Contributors:
  - Yvonne Ng
  - Kai Ho Chak
  - Katherine Knauss
  - Nasima Dahir
  - Mubashir Rahman

## Instructions for using the system:
  - Download Visual Studio
  - git clone to the target directory location:
	```git clone https://github.com/ng-yvonne/CourseCompanion.git```
  - make sure Blazor app is installed (https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/install)
  - in the root directory, run "dotnet watch" or run the solution in Visual Studio
  - after the app is loaded, see the academic requirement
  - use search bar or filter the get the list of courses that match your requirement
  - for the search bar, type the title, related keywords, courses level (for example typing CPSC 200 will show courses that are CPSC and in 200 levels), the semester the course is offered.
  - for the filter, there are the following options
  - filter by semester: users can filter courses by "Fall", "Winter", "Spring", and "Summer"
  - filter by eligibility: users can filter courses by whether courses are used for eligible
  - filter by major field, users can filter courses by whether courses are in their major fields
  - filter by other requirements, users can filter courses which are still in their major fields but not offered by the user's program department
  - filter by faculty breadth, users can filter courses that are not in user's faculty
  - filter by open options, users can filter courses by open options that are either in their major, or not in their major
  - filter by levels, users can filter courses by the courses' level, including 300, 400, or 500 levels or above

## What cases/functions we implemented:
  - add a course to semester planner
  - delete a course from semester planner
  - dynamic error messages on ineligible courses
  - search: by course title, by course summary, by course level, by semester
  - filter: by semester, by eligibility, by major fields, by other requirements, by faculty breadth, by open options, by level
  - reset result course list
  - academic requirements
  - progress bar
  - help / tutorial
  - export selected courses to schedule builder
  
## What data should be entered at which times
  - Data is only entered when searching for courses

## Walkthrough
  - Add a course by pressing the plus button of a course (recommended CPSC 203)
  - Scroll through the list of courses to find a Winter course (yellow) (recommended CPSC 217 Winter) and add that course
  - Notice how the progress bar up above moves when courses are added and removed
  - Add some more courses (recommended CPSC 217 Fall (blue)), notice how an error icon appears on the class
  - Hover your mouse over the error icon to see the dynamic error message pertaining to that particular class. 
  - Remove the error course by pressed the garbage can next to it (Recommended CPSC 217)
  - Go to the search bar and type in a class (recommended SENG or seng. SENG 300 will be displayed in the results) You may also type SENG 300 to produce that
  - result directly) Add SENG 300 to the course list
  - Add all sorts of classes (however many you desire). Now try the reset button. Simply press Reset and confirm to reset the semesters. 
  - Add courses (recommended CPSC 203, CPSC 231 PHIL 279, DATA 201, MATH 211, and MATH 249 evenly split between Fall and Winter) and press the export button.  - Confirm to export and enjoy the redirect to “Schedule Builder”
  - Press the back arrow on your web browser or launch the program again to return to Course Companion.
  - Press Go To Spring/Summer
  - Go to the filters and click semesters, in the dropdown select Spring and add some courses. (Feel free to play around with other filters as you see fit.
  - They are all functional and are colour coordinated to match classes to each filter option)
  - Click the Help button in the lower left corner. Click through the prompts and note the tutorial next to each feature. 

# Thanks for using Course Companion!!

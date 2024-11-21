using System.ComponentModel.DataAnnotations;

namespace Computools_Task
{
    /// <summary>
    /// The entry point of the application, containing the logic for initializing and managing student and subject data.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// Initializes student data and displays details of the first student.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        private static void Main(string[] args)
        {
            try
            {
                var students = InitializeStudents();

                var studentToDisplay = students.FirstOrDefault();

                DisplayStudentDetails(studentToDisplay);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Initializes a list of <see cref="Student"/> objects by assigning subjects, calculating their average grades, and setting their grants.
        /// </summary>
        /// <returns>A list of fully initialized <see cref="Student"/> objects with subjects, average grades, and grants assigned.</returns>
        private static List<Student> InitializeStudents()
        {
            var subjects = Subject.Fill();
            var students = Student.Fill();

            foreach (var student in students)
            {
                student.SetSubjects(subjects);
                student.CalculateAverageGrade();
                student.SetGrant();
            }

            return students;
        }

        /// <summary>
        /// Displays the details of a <see cref="Student"/> object.
        /// If the student is null, no information is displayed.
        /// </summary>
        /// <param name="student">The <see cref="Student"/> whose details are to be displayed.</param>
        private static void DisplayStudentDetails(Student? student)
        {
            if (student == null)
            {
                Console.WriteLine("No students found.");

                return;
            }

            Console.WriteLine($"Student: {student.FirstName} {student.SecondName}");
            Console.WriteLine($"Age: {student.Age}");

            if (student.Subjects == null || student.Subjects.Count == 0)
            {
                Console.WriteLine("This student has no subjects.");

                return;
            }

            Console.WriteLine($"Average grade: {student.AverageGrade:F2}");
            Console.WriteLine($"Grant: {student.Grant}");
            Console.WriteLine("Subjects:");

            foreach (var subject in student.Subjects)
            {
                Console.WriteLine($"- {subject.Name} - {subject.Grade} ({subject.Date.ToShortDateString()})");
            }
        }
    }
}

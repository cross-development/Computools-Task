using System.ComponentModel.DataAnnotations;

namespace Computools_Task;

/// <summary>
/// Represents a subject associated with a student, including details such as name, grade, and date.
/// </summary>
public sealed class Subject
{
    /// <summary>
    /// The minimum allowable grade for a subject.
    /// </summary>
    private const int MinGrade = 0;

    /// <summary>
    /// The maximum allowable grade for a subject.
    /// </summary>
    private const int MaxGrade = 100;

    /// <summary>
    /// Stores the grade for the subject.
    /// This field is read-only and supports validation through the Grade property.
    /// </summary>
    private readonly int _grade;

    /// <summary>
    /// Gets the unique identifier for the subject.
    /// This property is required and can only be initialized during object creation.
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    /// Gets the name of the subject.
    /// This property is required and can only be initialized during object creation.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Gets or initializes the grade for the subject.
    /// Ensures the grade value is within the valid range defined by <see cref="MinGrade"/> and <see cref="MaxGrade"/>.
    /// </summary>
    /// <exception cref="ValidationException">
    /// Thrown when the grade value is less than <see cref="MinGrade"/> or greater than <see cref="MaxGrade"/>.
    /// </exception>
    public required int Grade
    {
        get => _grade;
        init
        {
            if (value is < MinGrade or > MaxGrade)
            {
                throw new ValidationException($"Grade must be between {MinGrade} and {MaxGrade}.");
            }

            _grade = value;
        }
    }

    /// <summary>
    /// Gets the date associated with grading.
    /// </summary>
    public required DateTime Date { get; init; }

    /// <summary>
    /// Gets the unique identifier for the <see cref="Student"/>.
    /// This property is required and can only be initialized during object creation.
    /// </summary>
    public required int StudentId { get; init; }

    /// <summary>
    /// Creates and returns a list of predefined <see cref="Subject"/> objects.
    /// </summary>
    /// <returns>A list of <see cref="Subject"/> objects with predefined values.</returns>
    public static List<Subject> Fill()
    {
        return new List<Subject>
        {
            new() { Id = 1, Name = "Math", Grade = 85, Date = DateTime.Now.AddDays(-10), StudentId = 1 },
            new() { Id = 2, Name = "Physics", Grade = 90, Date = DateTime.Now.AddDays(-7), StudentId = 1 },
            new() { Id = 3, Name = "English", Grade = 70, Date = DateTime.Now.AddDays(-5), StudentId = 2 },
            new() { Id = 4, Name = "History", Grade = 60, Date = DateTime.Now.AddDays(-2), StudentId = 1 },
            new() { Id = 5, Name = "Chemistry", Grade = 95, Date = DateTime.Now.AddDays(-3), StudentId = 2 },
        };
    }

    /// <summary>
    /// Filters and returns a list of <see cref="Subject"/> objects for a specific student based on their student Id.
    /// </summary>
    /// <param name="subjects">The list of <see cref="Subject"/> objects to filter.</param>
    /// <param name="studentId">The unique identifier of the <see cref="Student"/> whose subjects are to be retrieved.</param>
    /// <returns>A list of <see cref="Subject"/> objects that belong to the specified student.</returns>
    public static List<Subject> GetByStudentId(List<Subject> subjects, int studentId)
    {
        return subjects.Where(subject => subject.StudentId == studentId).ToList();
    }
}
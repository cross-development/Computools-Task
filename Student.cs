namespace Computools_Task;

/// <summary>
/// Represents a student, including their personal details and associated subjects.
/// </summary>
public sealed class Student
{
    /// <summary>
    /// Gets the unique identifier for the student.
    /// This property is required and can only be initialized during object creation.
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    /// Gets the first name of the student.
    /// This property is required and can only be initialized during object creation.
    /// </summary>
    public required string FirstName { get; init; }

    /// <summary>
    /// Gets the second name of the student.
    /// This property is required and can only be initialized during object creation.
    /// </summary>
    public required string SecondName { get; init; }

    /// <summary>
    /// Gets the age of the student.
    /// This property is required and can only be initialized during object creation.
    /// </summary>
    public required int Age { get; init; }

    /// <summary>
    /// Gets the list of <see cref="Subject"/> objects assigned to the student.
    /// This property is private set and may be null if not initialized.
    /// </summary>
    public List<Subject>? Subjects { get; private set; }

    /// <summary>
    /// Gets the average grade of the student.
    /// This property is read-only, can be null if not calculated, and is set internally.
    /// </summary>
    public double? AverageGrade { get; private set; }

    /// <summary>
    /// Gets the grant level awarded to the student.
    /// This property is read-only and set internally based on the student's average grade.
    /// </summary>
    public Grant? Grant { get; private set; }

    /// <summary>
    /// Creates and returns a predefined list of <see cref="Student"/> objects with initial values.
    /// </summary>
    /// <returns>A list of <see cref="Student"/> objects with predefined values.</returns>
    public static List<Student> Fill()
    {
        return new List<Student>
        {
            new() { Id = 1, FirstName = "John", SecondName = "Doe", Age = 20 },
            new() { Id = 2, FirstName = "Jane", SecondName = "Smith", Age = 21 },
        };
    }

    /// <summary>
    /// Sets the subjects for the student by filtering the provided list of <see cref="Subject"/> objects based on the student's Id.
    /// </summary>
    /// <param name="subjects">A list of <see cref="Subject"/> objects to be filtered by the student's ID.</param>
    public void SetSubjects(List<Subject> subjects)
    {
        Subjects = Subject.GetByStudentId(subjects, Id);
    }

    /// <summary>
    /// Calculates and sets the average grade for the student based on their subjects.
    /// </summary>
    public void CalculateAverageGrade()
    {
        AverageGrade = Subjects?.Average(subject => subject.Grade);
    }

    /// <summary>
    /// Sets the student's grant level based on their average grade.
    /// </summary>
    public void SetGrant()
    {
        Grant = AverageGrade switch
        {
            < 60 => Computools_Task.Grant.None,
            >= 60 and < 90 => Computools_Task.Grant.Regular,
            _ => Computools_Task.Grant.Increased
        };
    }
}
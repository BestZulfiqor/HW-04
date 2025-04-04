using System.Text.RegularExpressions;
using Domain.Enums;

namespace Domain.Entities;

public class StudentGroup
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public StudentGroupStatus StudentGroupStatus { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset FinishedDate { get; set; }
    
    // navigations
    public Student Student { get; set; }
    public Group Group { get; set; }
}
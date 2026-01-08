using System;
using System.Collections.Generic;

namespace FEEE.Infrastructure.Persistence.Entities;

public partial class Student
{
    public int StudentId { get; set; }

    public string UniversityNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public DateTime? BirthDate { get; set; }

    public int? CityId { get; set; }

    public int? SectionId { get; set; }

    public int? YearId { get; set; }

    public byte? Status { get; set; }

    public virtual City? City { get; set; }

    public virtual Section? Section { get; set; }

    public virtual ICollection<StudentArchive> StudentArchives { get; set; } = new List<StudentArchive>();

    public virtual ICollection<StudentPromotion> StudentPromotions { get; set; } = new List<StudentPromotion>();

    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    public virtual Year? Year { get; set; }
}

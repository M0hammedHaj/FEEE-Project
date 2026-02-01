using FEEE.Application.DTOs.OldStudents;
using FEEE.Domain.Entities;
using FEEE.Infrastructure.Persistence.Entities;

namespace FEEE.Application.Mappings.OldStudents
{
    public static class OldStudentMapping
    {
        public static OldStudentDto ToDto(this OldStudent student)
        {
            return new OldStudentDto
            {
                Id = student.ID,
                UniversityNumber = student.UnivID.ToString(),
                FullName = $"{student.FName} {student.LName}",
                BirthDate = student.BirthDay,
                IsExist = student.IsExist
            };
        }
    }
}

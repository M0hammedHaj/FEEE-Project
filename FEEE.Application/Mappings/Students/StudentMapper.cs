using FEEE.Application.DTOs.Students;
using FEEE.Domain.Enums;
using FEEE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.Students
{
    public static class StudentMapper
    {
        public static StudentModel ToModel(CreateStudentRequest request)
        {
            return new StudentModel
            {
                UniversityNumber = request.UniversityNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                FatherName = request.FatherName,
                MotherName = request.MotherName,
                BirthDate = request.BirthDate,
                CityId = request.CityId,
                SectionId = request.SectionId,
                YearId = request.YearId,
                Status = StudentStatus.Active
            };
        }
        public static void UpdateModel(
            StudentModel student,
            UpdateStudentRequest request)
        {
            student.UniversityNumber = request.UniversityNumber;
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.FatherName = request.FatherName;
            student.MotherName = request.MotherName;
            student.BirthDate = request.BirthDate;
            student.CityId = request.CityId;
            student.SectionId = request.SectionId;
            student.YearId = request.YearId;
        }
        public static StudentResponse ToResponse(StudentModel student)
        {
            return new StudentResponse
            {
                StudentId = student.StudentId,
                UniversityNumber = student.UniversityNumber,
                FirstName = student.FirstName,
                LastName = student.LastName,
                FatherName = student.FatherName,
                MotherName = student.MotherName,
                BirthDate = student.BirthDate,
                CityId = student.CityId,
                SectionId = student.SectionId,
                YearId = student.YearId,
                Status = student.Status
            };
        }
        public static StudentListItemResponse ToListItem(StudentModel student)
        {
            return new StudentListItemResponse
            {
                StudentId = student.StudentId,
                UniversityNumber = student.UniversityNumber,
                FullName = $"{student.FirstName} {student.LastName}"
            };
        }

    }
}

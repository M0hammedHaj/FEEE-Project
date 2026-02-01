using FEEE.Application.DTOs.StudentArchive;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.StudentArchive
{
    public static class StudentArchiveMapper
    {
        public static StudentArchiveModel ToModel(CreateStudentArchiveRequest request)
        {
            return new StudentArchiveModel
            {
                ArchiveNumber = request.ArchiveNumber,
                StudentId = request.StudentId,
                OperationType = request.OperationType,
                ArchiveDate = request.ArchiveDate,
                Notes = request.Notes,
                UserId = request.UserId
            };
        }

        public static StudentArchiveResponse ToResponse(StudentArchiveModel model)
        {
            return new StudentArchiveResponse
            {
                StudentArchiveId = model.StudentArchiveId,
                ArchiveNumber = model.ArchiveNumber,
                StudentId = model.StudentId,
                OperationType = model.OperationType,
                ArchiveDate = model.ArchiveDate,
                Notes = model.Notes,
                UserId = model.UserId
            };
        }
    }

}

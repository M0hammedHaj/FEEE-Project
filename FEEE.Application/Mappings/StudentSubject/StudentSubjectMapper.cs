using FEEE.Application.DTOs.StudentSubject;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.StudentSubject
{
    public class StudentSubjectMapper
    {
        public static StudentSubjectListItemResponse ToListItem(StudentSubjectModel model)
        {
            return new StudentSubjectListItemResponse
            {
                StudentSubjectId = model.StudentSubjectId,
                SubjectId = model.SubjectId,
                YearId = model.YearId,
                Semester = model.Semester,
                Status = model.Status.ToString()
            };
        }
    }
}

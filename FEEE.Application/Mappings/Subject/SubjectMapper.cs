using FEEE.Application.DTOs.Subject;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.Subject
{
    public static class SubjectMapper
    {
        public static SubjectModel ToModel(CreateSubjectRequest request) =>
            new()
            {
                Name = request.Name,
                Code = request.Code,
                YearId = request.YearId,
                HasPractical = request.HasPractical
            };

        public static void UpdateModel(SubjectModel model, UpdateSubjectRequest request)
        {
            model.Name = request.Name;
            model.Code = request.Code;
            model.YearId = request.YearId;
            model.HasPractical = request.HasPractical;
        }

        public static SubjectResponse ToResponse(SubjectModel model) =>
            new()
            {
                SubjectId = model.SubjectId,
                Name = model.Name,
                Code = model.Code,
                YearId = model.YearId,
                HasPractical = model.HasPractical
            };
    }

}

using FEEE.Application.DTOs.StudentPromotion;
using FEEE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Mappings.StudentPromotion
{
    public static class StudentPromotionMapper
    {
        public static StudentPromotionModel ToModel(CreateStudentPromotionRequest request)
        {
            return new StudentPromotionModel
            {
                StudentId = request.StudentId,
                FromYearId = request.FromYearId,
                ToYearId = request.ToYearId,
                PromotionDate = request.PromotionDate,
                Decision = request.Decision
            };
        }

        public static StudentPromotionResponse ToResponse(StudentPromotionModel model)
        {
            return new StudentPromotionResponse
            {
                StudentPromotionId = model.StudentPromotionId,
                StudentId = model.StudentId,
                FromYearId = model.FromYearId,
                ToYearId = model.ToYearId,
                PromotionDate = model.PromotionDate,
                Decision = model.Decision
            };
        }
    }

}

using FEEE.Application.DTOs.StudentPromotion;
using FEEE.Application.Mappings.StudentPromotion;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.StudentPromotion.GetStudentPromotionsByStudentId
{
    public class GetStudentPromotionsByStudentIdService
    {
        private readonly IStudentPromotionRepository _repository;

        public GetStudentPromotionsByStudentIdService(IStudentPromotionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentPromotionResponse>> ExecuteAsync(int studentId)
        {
            var items = await _repository.GetByStudentIdAsync(studentId);
            return items.Select(StudentPromotionMapper.ToResponse).ToList();
        }
    }

}

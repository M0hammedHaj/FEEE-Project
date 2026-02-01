using FEEE.Application.DTOs.StudentPromotion;
using FEEE.Application.Mappings.StudentPromotion;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.StudentPromotion.CreateStudentPromotion
{
    public class CreateStudentPromotionService
    {
        private readonly IStudentPromotionRepository _repository;

        public CreateStudentPromotionService(IStudentPromotionRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> ExecuteAsync(CreateStudentPromotionRequest request)
        {
            var model = StudentPromotionMapper.ToModel(request);
            var id = await _repository.AddAsync(model);
            return id;
        }
    }

}

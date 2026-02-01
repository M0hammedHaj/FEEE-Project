using FEEE.Application.DTOs.HigherYearRequests;
using FEEE.Application.Interfaces;
using FEEE.Application.Mappings.HigherYearRequestMapper;
using FEEE.Domain.Enums;
using FEEE.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.HigherYearRequests.CreateHigherYearRequestServices
{
    public class CreateHigherYearRequestService
    {
        private readonly IHigherYearRequestRepository _requestRepo;
        private readonly IStudentRepository _studentRepo; 
                                                         

        public CreateHigherYearRequestService(
            IHigherYearRequestRepository requestRepo,
            IStudentRepository studentRepo
            )
        {
            _requestRepo = requestRepo;
            _studentRepo = studentRepo;
        }

        public async Task<CreateHigherYearRequestResponseDto> HandleAsync(CreateHigherYearRequestDto dto)
        {
   
            if (dto.SelectedSubjectIds == null || dto.SelectedSubjectIds.Count != 2)
                throw new Exception("يجب اختيار مادتين تماماً.");

       
            var studentExists = await _studentRepo.ExistsAsync(dto.StudentId);
            if (!studentExists)
                throw new Exception("الطالب غير موجود.");

        
            var hasPending = await _requestRepo.HasPendingRequestAsync(dto.StudentId);
            if (hasPending)
                throw new Exception("الطالب لديه طلب معلّق مسبقاً.");

           
            var model = dto.ToModel();
            var requestId = await _requestRepo.CreateAsync(model);

            return HigherYearRequestMapper.ToCreateResponseDto(requestId, HigherYearRequestStatus.Pending);
        }
    }
}

using FEEE.Application.DTOs.User;
using FEEE.Application.Mappings.User;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Subject.DeleteSubject
{
    public class DeleteSubjectService
    {
        private readonly ISubjectRepository _repository;

        public DeleteSubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }


}

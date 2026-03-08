using FEEE.Application.DTOs.StudentArchive;
using FEEE.Application.Interfaces;
using FEEE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.UseCases.Print
{
    public class GenerateInvoicePdfUseCase : IGenerateInvoicePdfUseCase
    {
        private readonly IStudentArchiveRepository _repository;
        private readonly IPdfGenerator<StudentArchivePrintDto> _pdfService;

        public GenerateInvoicePdfUseCase(
            IStudentArchiveRepository repository,
            IPdfGenerator<StudentArchivePrintDto> pdfService)
        {
            _repository = repository;
            _pdfService = pdfService;
        }

        public async Task<byte[]> ExecuteAsync(int id)
        {
            var dto = await _repository.GetPrintDetailsAsync(id);

            if (dto == null)
                throw new Exception("Archive not found");

            return _pdfService.Generate(dto);
        }
    }
}

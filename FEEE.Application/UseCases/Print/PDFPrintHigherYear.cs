using FEEE.Application.DTOs.StudentArchive;
using FEEE.Application.Interfaces;
using FEEE.Domain.Enums;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FEEE.Application.UseCases.Print
{
    public class PDFPrintHigherYear : IPdfGenerator<StudentArchivePrintDto>
    {
        public byte[] Generate(StudentArchivePrintDto model)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    page.Header()
                        .Text("Student Archive Document")
                        .FontSize(18)
                        .SemiBold()
                        .AlignCenter();

                    page.Content().Column(column =>
                    {
                        column.Spacing(8);

                        column.Item().Text($"Archive Number: {model.ArchiveNumber}");
                        column.Item().Text($"UniversityNumber: {model.UniversityNumber}");
                        column.Item().Text($"Operation Type: {(model.OperationTypeName).ToString()}");
                        column.Item().Text($"MinisterialNumber: {(model.MinisterialNumber).ToString()}");
                        column.Item().Text($"Archive Date: {model.ArchiveDate.ToString("yyyy-MM-dd")}");

                        if (!string.IsNullOrWhiteSpace(model.Notes))
                            column.Item().Text($"Notes: {model.Notes}");
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text($"Generated at: {DateTime.Now:yyyy-MM-dd HH:mm}");
                });
            }).GeneratePdf();
        }

       
    }
}

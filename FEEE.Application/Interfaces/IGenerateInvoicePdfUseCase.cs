using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.Interfaces
{
    public interface IGenerateInvoicePdfUseCase
    {
        Task<byte[]> ExecuteAsync(int invoiceId);
    }
}

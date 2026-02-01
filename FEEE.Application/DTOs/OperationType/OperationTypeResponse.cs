using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.OperationType
{
    public class OperationTypeResponse
    {
        public int OperationTypeId { get; set; }
        public string Name { get; set; } = null!;
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.Section
{
    public class CreateSectionRequest
    {
        public string Name { get; set; } = null!;
        public bool Active { get; set; }
    }
}

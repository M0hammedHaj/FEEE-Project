using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Application.DTOs.City
{
    public class CityListItemResponse
    {
        public int CityId { get; set; }
        public string Name { get; set; } = default!;
    }

}

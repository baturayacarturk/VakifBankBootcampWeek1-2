using Application.Features.Farmers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Farmers.Models
{
    public class FarmerListModel
    {
        public IList<FarmerListDto> Items { get; set; }
    }
}

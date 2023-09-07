using Application.Features.Farmers.Dtos;
using Application.Features.Farmers.Models;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Farmers.Queries.GetFarmerList
{
    public class GetListFarmerQuery:IRequest<FarmerListModel>
    {
        public CountryName Country{ get; set; }
    }
}

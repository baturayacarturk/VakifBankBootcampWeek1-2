using Application.Features.Farmers.Dtos;
using Application.Features.Farmers.Models;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Farmers.Queries.GetFarmerList
{
    public class GetListFarmerHandler : IRequestHandler<GetListFarmerQuery, FarmerListModel>
    {
        private readonly IFarmerRepository _farmerRepository;

        public GetListFarmerHandler(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<FarmerListModel> Handle(GetListFarmerQuery request, CancellationToken cancellationToken)
        {
            var farmersBasedOnCountry = await _farmerRepository.GetList(expression:x=>x.Country==request.Country,
                                                                     include: x=>x.Include(x=>x.Products));

            var farmerDtos = farmersBasedOnCountry.Select(farmer => new FarmerListDto
            {
                FarmerRegistrationNumber = farmer.FarmerRegistrationNumber,
                FirstName = farmer.FirstName,
                LastName = farmer.LastName,
                PhoneNumber = farmer.PhoneNumber,
                Products = farmer.Products.ToList() 
            }).ToList();

            var farmerListModel = new FarmerListModel
            {
                Items = farmerDtos
            };

            return farmerListModel;
        }
    }
}









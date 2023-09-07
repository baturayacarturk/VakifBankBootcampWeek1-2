using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Farmers.UseCases.FarmerUseCase
{
    public class FarmerUseCases
    {
        private readonly IFarmerRepository _farmerRepository;
        public FarmerUseCases(IFarmerRepository repository)
        {
            _farmerRepository = repository;
        }
        public async Task FarmerRegistrationNumberCanNotBeDuplicated(string registrationNumber)
        {
            var result = _farmerRepository.Get(x => x.FarmerRegistrationNumber == registrationNumber);
            if (result is not null) throw new BusinessException("xxx");
        }
        public async Task FarmerIdentificationNumberCanNotBeDuplicated(string identificationNumber)
        {
            var result = _farmerRepository.Get(x => x.IdentificationNumber == identificationNumber);
            if (result is not null) throw new BusinessException("xxx");
        }
    }
}

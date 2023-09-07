using Application.Features.Farmers.Dtos;
using Application.Features.Farmers.UseCases.FarmerUseCase;
using Application.Services.Repositories;
using Core.Persistence.Messages;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Farmers.Commands.CreateFarmer
{
    public class CreateFarmerHandler : IRequestHandler<CreateFarmerCommand, CreatedFarmerDto>
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly FarmerUseCases _farmerUseCases;
        public CreateFarmerHandler(IFarmerRepository repository, FarmerUseCases farmerUseCases)
        {
            _farmerRepository = repository;
            _farmerUseCases = farmerUseCases;
        }

        public async Task<CreatedFarmerDto> Handle(CreateFarmerCommand request, CancellationToken cancellationToken)
        {
            await _farmerUseCases.FarmerRegistrationNumberCanNotBeDuplicated(request.FarmerRegistrationNumber);
            await _farmerUseCases.FarmerIdentificationNumberCanNotBeDuplicated(request.IdentificationNumber);
            Farmer farmerToBeInserted = new Farmer
            {
                FarmerRegistrationNumber = request.FarmerRegistrationNumber,
                IdentificationNumber = request.IdentificationNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Country = request.Country,
                LandInformation = request.LandInformation,
                MailAddress = request.MailAddress,
                PhoneNumber = request.PhoneNumber,
                
            };

            await _farmerRepository.AddAsync(farmerToBeInserted);
            CreatedFarmerDto createdFarmerDto = new CreatedFarmerDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Message = Messages.WelcomeMessage
            };

            return createdFarmerDto;
            
        }
    }
}

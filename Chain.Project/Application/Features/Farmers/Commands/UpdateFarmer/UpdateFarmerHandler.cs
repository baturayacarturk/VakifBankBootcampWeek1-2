using Application.Features.Farmers.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Messages;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Farmers.Commands.UpdateFarmer
{
    public class UpdateFarmerHandler : IRequestHandler<UpdateFarmerCommand, UpdatedFarmerDto>
    {
        private readonly IFarmerRepository _farmerRepository;

        public UpdateFarmerHandler(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<UpdatedFarmerDto> Handle(UpdateFarmerCommand request, CancellationToken cancellationToken)
        {
            var farmer = await _farmerRepository.Get(x => x.IdentificationNumber == request.IdentificationNumber);

            farmer.MailAddress = request.MailAddress != default ? farmer.MailAddress : request.MailAddress;
            farmer.Country = request.Country != default ? farmer.Country : request.Country;
            farmer.PhoneNumber = request.PhoneNumber != default ? farmer.PhoneNumber : request.PhoneNumber;
            farmer.LandInformation = request.LandInformation != default ? farmer.LandInformation : request.LandInformation;

            await _farmerRepository.UpdateAsync(farmer);

            UpdatedFarmerDto updatedFarmer = new UpdatedFarmerDto
            {
                Message = Messages.UpdatedUser,
            };
            return updatedFarmer;

        }
    }
}

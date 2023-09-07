using Application.Features.Farmers.Dtos;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Farmers.Commands.CreateFarmer
{
    public class CreateFarmerCommand:IRequest<CreatedFarmerDto>
    {
        public string FarmerRegistrationNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailAddress { get; set; }
        public CountryName Country { get; set; }
        public string PhoneNumber { get; set; }
        public string LandInformation { get; set; }

    }
}

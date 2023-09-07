using Application.Features.Farmers.Dtos;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Farmers.Commands.UpdateFarmer
{
    public class UpdateFarmerCommand:IRequest<UpdatedFarmerDto>
    {
        public string IdentificationNumber { get; set; }
        public string MailAddress { get; set; }
        public CountryName Country { get; set; }
        public string PhoneNumber { get; set; }
        public string LandInformation { get; set; }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Farmers.Commands.CreateFarmer
{
    public class CreateFarmerValidator:AbstractValidator<CreateFarmerCommand>
    {
        public CreateFarmerValidator()
        {
            RuleFor(c=>c.IdentificationNumber).NotEmpty().Length(11);  
            RuleFor(c=>c.FarmerRegistrationNumber).NotEmpty().Length(11);
            RuleFor(c => c.PhoneNumber).NotEmpty().Length(12);
            RuleFor(c=>c.MailAddress).NotEmpty().EmailAddress();

        }
    }
}

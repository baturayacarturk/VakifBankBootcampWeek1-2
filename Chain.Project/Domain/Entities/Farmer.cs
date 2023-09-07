using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Farmer: IEntity
    {
        public string FarmerRegistrationNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailAddress { get; set; }
        public CountryName Country{ get; set; }
        public string PhoneNumber { get; set; }
        public string LandInformation { get; set; }
        

        public ICollection<Product> Products { get; } = new List<Product>();

    }
}

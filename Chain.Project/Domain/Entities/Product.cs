using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product: IEntity
    {
        public int ProductId { get; set; }
        public ProductName Name { get; set; }
        public string ProductDetails { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}

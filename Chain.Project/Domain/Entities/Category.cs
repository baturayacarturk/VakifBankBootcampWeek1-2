using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public CategoryName Name { get; set; }
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}

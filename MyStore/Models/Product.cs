using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public PType Type { get; set; }
        public int PTypeId { get; set; }
        public float Price { get; set; }

        public ICollection<Compatibility> Compatibilities { get; set; }

    }
}
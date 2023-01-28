﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
  public  class Product : ClassBase
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }


        public int CategoryId { get; set; }

        public Category Category { get; set; }


    
        public decimal Price { get; set; }

        public string Image { get; set; }


    }
}

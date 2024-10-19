using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1SphinxCommercial.BL.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required,MaxLength(150)]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }

}

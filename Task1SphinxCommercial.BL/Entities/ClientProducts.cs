using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1SphinxCommercial.BL.Entities
{
    public class ClientProduct
    {
        public int ClientProductId { get; set; }

        [Required(ErrorMessage = "Client is required")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } 

        [Required, MaxLength(255)]
        public string License { get; set; }
        public Client? Client { get; set; }
        public Product? Product { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1SphinxCommercial.BL.Entities
{
    public class Client
    {
        public enum ClientClass { A, B, C }
        public enum ClientState { Active, Inactive, Pending }

        [Required]
        public ClientClass Class { get; set; }

        [Required]
        public ClientState State { get; set; }
        public int ClientId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(9)]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Code must be numeric and 9 digits long.")]
        public string Code { get; set; }
    }
}

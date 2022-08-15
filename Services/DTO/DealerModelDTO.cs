using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class DealerModelDTO
    {
        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string SearchString { get; set; }
    }
}

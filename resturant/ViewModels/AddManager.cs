using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.ViewModels
{
    public class AddManager
    {
        [MaxLength(100)]
        public string userName { get; set; }

        [MaxLength(100)]
        public string email { get; set; }


        public int phoneNumber { get; set; }
    }
}

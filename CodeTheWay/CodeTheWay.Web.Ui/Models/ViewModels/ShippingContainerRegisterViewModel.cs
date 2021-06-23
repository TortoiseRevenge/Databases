using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Models.ViewModels
{
    public class ShippingContainerRegistrationViewModel
    {
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public string Destination { get; set; }
    }
}
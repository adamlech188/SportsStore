using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.WebUI.ViewModels
{
    public class ShippingDetailsView
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Display(Name="Line 1")]
        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }
        [Display(Name = "Line 2")]
        public string Line2 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state name")]
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter a country name")]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Gift Wrap")]
        public bool GiftWrap { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExpertsClientPage.Models
{
    public class MultipleTableClass
    {
        [Key]
        public int MultipleTableClassID { get; set; }
        
        public Customer customerDetails { get; set; }

        public Booking bookingD { get; set; }

        public Package packageDetails { get; set; }

        public Products_Suppliers prod_supDetails { get; set; }

        public Product productDetails { get; set; }

        public BookingDetail bookingDetails { get; set; }

        public Fee feeDetails { get; set; }

        public decimal InsurancePrice
        {
            get
            {
                var basePrice = Convert.ToDecimal(packageDetails.PkgBasePrice);
                decimal percent = 0.05m;
                decimal InsPrice = basePrice * percent;
                return InsPrice;
            }
        }

        public decimal bookingFee
        {
            get
            {
                decimal bkfee = 25m;
                return (bkfee);
            }
        }



    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExpertsClientPage.Models
{
    public class MultipleTableClass
    {
        public Customer customerDetails { get; set; }

        public Booking bookingD { get; set; }

        public Package packageDetails { get; set; }

        public Products_Suppliers prod_supDetails { get; set; }

        public Product productDetails { get; set; }

        public BookingDetail bookingDetails { get; set; }

        public Fee feeDetails { get; set; }



        //calculate the insurance price based on the package cost
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



        // add booking fee to package order page.
        public decimal bookingFee
        {
            get
            {
                decimal bkfee = 25m;
                return (bkfee);
            }
        }

        //post form data to the db.
        public string sendToDB
        {
            get; set;
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExpertsClientPage.Models
{
    public class CustomerTravelProductsModel
    {
        public int CustomerId { get; set; }

        public string CustFirstName { get; set; }

        public string CustLastName { get; set; }

        public float ItineraryNo { get; set; }

        public double TotalCost { get; set; }

        public List<PackagesOrdered> PkgOrd { get; set; }

        public List<ProductsOrdered> ProdOrd { get; set; }

        public class PackagesOrdered
        {
            public double ItineraryNo { get; set; }

            public string PkgName { get; set; }

            public double PkgBasePrice { get; set; }

            public double FeeAmt { get; set; }
        }

        public class ProductsOrdered
        {
            public double ItineraryNo { get; set; }

            public string ProdName { get; set; }

            public double BasePrice { get; set; }

            public double FeeAmt { get; set; }
        }
    }
}
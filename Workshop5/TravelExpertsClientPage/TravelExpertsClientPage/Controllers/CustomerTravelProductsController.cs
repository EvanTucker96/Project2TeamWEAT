using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExpertsClientPage.Models;

namespace TravelExpertsClientPage.Controllers
{
    public class CustomerTravelProductsController : Controller
    {
        // GET: CustomerTravelProducts
        public ActionResult CustomerTravelProducts()
        {
            CustomerTravelProductsModel model = new CustomerTravelProductsModel();

            model.CustomerId = (int)Session["CustID"];
            model.TotalCost = 0;

            string itineraryQuery =  @"select distinct c.CustomerId, CustFirstName, CustLastName, bd.ItineraryNo
                                    From Bookings as b
                                    Full outer join Customers as c
                                    on c.CustomerId = b.CustomerId
                                    join BookingDetails as bd
                                    on b.BookingId = bd.BookingId
                                    where c.CustomerId = @CustomerId";

            string pkgQuery = @"select bd.ItineraryNo, pa.PkgName, pa.PkgBasePrice, f.FeeAmt
                                from packages as pa
                                join Bookings as b
                                on b.PackageId = pa.PackageId
                                join BookingDetails as bd
                                on bd.BookingId=b.BookingId
                                join Fees as f
                                on f.FeeId = bd.FeeId
                                where bd.ItineraryNo = @itinerary";

            string prodQuery = @"select  bd.ItineraryNo, pr.ProdName, bd.BasePrice, f.FeeAmt 
                                from Products as pr
                                join Products_Suppliers as ps
                                on ps.ProductId = pr.ProductId
                                join BookingDetails as bd
                                on bd.ProductSupplierId = ps.ProductSupplierId
                                join Bookings as b
                                on b.BookingId = bd.BookingId
                                join Fees as f
                                on f.FeeId = bd.FeeId
                                where bd.ItineraryNo = @itinerary";

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=TravelExperts;Integrated Security=True";

            List<float> itinerarys = new List<float>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // run query to fetch customer itinerarys
                SqlCommand command = new SqlCommand(itineraryQuery, connection);
                command.Parameters.AddWithValue("@CustomerId", model.CustomerId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    //loop through each itinerary
                    while (reader.Read())
                    {
                        itinerarys.Add(Convert.ToInt32(reader["ItineraryNo"]));
                        model.CustFirstName = Convert.ToString(reader["CustFirstName"]);
                        model.CustLastName = Convert.ToString(reader["CustLastName"]);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }

                //run query to fetch prod info
                model.ProdOrd = new List<CustomerTravelProductsModel.ProductsOrdered>();
                foreach ( var itNo in itinerarys )
                {
                    command = new SqlCommand(prodQuery, connection);
                    command.Parameters.AddWithValue("@itinerary",itNo);

                    //loop through each product
                    SqlDataReader prodReader = command.ExecuteReader();
                    try
                    {
                        //loop through each itinerary
                        while (prodReader.Read())
                        {
                            //add to model
                            CustomerTravelProductsModel.ProductsOrdered productOrdered = new CustomerTravelProductsModel.ProductsOrdered();
                            productOrdered.ItineraryNo = Convert.ToDouble(prodReader["ItineraryNo"]);
                            productOrdered.ProdName = Convert.ToString(prodReader["ProdName"]);
                            productOrdered.BasePrice = Convert.ToDouble(prodReader["BasePrice"]);
                            productOrdered.FeeAmt = Convert.ToDouble(prodReader["FeeAmt"]);
                            model.ProdOrd.Add(productOrdered);

                            //add to totalCost
                            model.TotalCost += productOrdered.BasePrice + productOrdered.FeeAmt;
                        }
                    }
                    finally
                    {
                        prodReader.Close();
                    }
                }

                //run query to fetch pkg info for each itinerary
                model.PkgOrd = new List<CustomerTravelProductsModel.PackagesOrdered>();
                foreach (var itNo in itinerarys)
                {
                    command = new SqlCommand(pkgQuery, connection);
                    command.Parameters.AddWithValue("@itinerary", itNo);

                    //loop through each package 
                   SqlDataReader pkgReader = command.ExecuteReader();
                    try
                    {
                        //loop through each itinerary
                        while (pkgReader.Read())
                        {
                            //add to model
                            CustomerTravelProductsModel.PackagesOrdered packagesOrdered = new CustomerTravelProductsModel.PackagesOrdered();
                            packagesOrdered.ItineraryNo = Convert.ToDouble(pkgReader["ItineraryNo"]);
                            packagesOrdered.PkgName = Convert.ToString(pkgReader["PkgName"]);
                            packagesOrdered.PkgBasePrice = Convert.ToDouble(pkgReader["PkgBasePrice"]);
                            packagesOrdered.FeeAmt = Convert.ToDouble(pkgReader["FeeAmt"]);
                            model.PkgOrd.Add(packagesOrdered);

                            //add to totalCost
                            model.TotalCost += packagesOrdered.PkgBasePrice + packagesOrdered.FeeAmt;
                        }
                    }
                    finally
                    {
                        pkgReader.Close();
                    }
                }
            }

            return View(model);
        }
    }
}
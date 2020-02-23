using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelExpertsClientPage.Models;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Web.UI;
using System.Windows;

namespace TravelExpertsClientPage.Controllers
{
    public class MultipleTableController : Controller
    {
        TravelExpertsEntities1 db = new TravelExpertsEntities1();

        // GET: MultipleTable
        public ActionResult Index(int? custID = null)
        {
            return View();
        }

        public ActionResult MultipleOrdersView(int? id)  
        {
            string feeID = "BK";

            // check id parameter is non-null and if so error out of page rendering
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // fetch the package associated to the provided id, on failure return not found error
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }

            // fetch the fees table and return the booking fee amount
            Fee fee = db.Fees.Find(feeID);
            if (fee == null)
            {
                return HttpNotFound();
            }
            // build a new multiple table class instance to return as model to view
            MultipleTableClass model = new MultipleTableClass();
            model.packageDetails = package;

            // todo : fetchproducts, suppliers and fees now and construct mtc model fully

            return View(model);
        }

        [HttpPost]
        public ActionResult PostData(FormCollection fc)
        {
            if (Session["Authenticated"] != null && (bool)Session["Authenticated"])
            {
                MultipleTableClass model = new MultipleTableClass();

                var packageID = Convert.ToInt32(fc[0]);
                var passengerNames = Array.FindAll<string>(fc.AllKeys, s => s.StartsWith("FullName_"));
                var travellerCount = passengerNames.Length;
                int createItNo = CreateItNo();

                // build BOOKING compatible record
                Booking booking = new Booking();
                booking.BookingDate = DateTime.Now;
                booking.TravelerCount = travellerCount;
                booking.CustomerId = (int)Session["CustID"];
                booking.PackageId = packageID;

                //post BOOKING record to db
                string saveBooking = @"INSERT into Bookings (BookingDate, TravelerCount, CustomerId, PackageId) output INSERTED.BookingId
                                      VALUES (@BookingDate, @TravelerCount, @CustomerId, @PackageId)";

                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=TravelExperts;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(saveBooking, connection);
                    command.Parameters.AddWithValue("@CustomerId", booking.CustomerId);
                    command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                    command.Parameters.AddWithValue("@TravelerCount", booking.TravelerCount);
                    command.Parameters.AddWithValue("@PackageId", booking.PackageId);
                    connection.Open();
                    booking.BookingId = (int)command.ExecuteScalar();
                }


                var package = db.Packages.FirstOrDefault(pkg => pkg.PackageId == packageID);

                foreach (var passenger in passengerNames)
                {
                    BookingDetail bookingDetail = new BookingDetail();
                    bookingDetail.ItineraryNo = createItNo + booking.CustomerId;
                    bookingDetail.TripStart = package.PkgStartDate;
                    bookingDetail.TripEnd = package.PkgEndDate;
                    bookingDetail.Description = package.PkgDesc;
                    bookingDetail.Destination = package.PkgName;
                    bookingDetail.BasePrice = package.PkgBasePrice;
                    bookingDetail.AgencyCommission = package.PkgAgencyCommission;
                    bookingDetail.BookingId = booking.BookingId;

                    // store record to db
                    string saveBookingDetails = @"INSERT into BookingDetails (ItineraryNo, TripStart, TripEnd, Description, 
                                                Destination, BasePrice, AgencyCommission, BookingId, ProductSupplierId)
                                                VALUES (@ItineraryNo, @TripStart, @TripEnd, @Description, @Destination, @BasePrice,
                                                @AgencyCommission, @BookingId, 26)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(saveBookingDetails, connection);
                        command.Parameters.AddWithValue("@ItineraryNo", bookingDetail.ItineraryNo);
                        command.Parameters.AddWithValue("@TripStart", bookingDetail.TripStart);
                        command.Parameters.AddWithValue("@TripEnd", bookingDetail.TripEnd);
                        command.Parameters.AddWithValue("@Description", bookingDetail.Description);
                        command.Parameters.AddWithValue("@Destination", bookingDetail.Destination);
                        command.Parameters.AddWithValue("@BasePrice", bookingDetail.BasePrice);
                        command.Parameters.AddWithValue("@AgencyCommission", bookingDetail.AgencyCommission);
                        command.Parameters.AddWithValue("@BookingId", bookingDetail.BookingId);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Package order successful", "Package Ordered" );
                return RedirectToAction("MultipleOrdersView/" + packageID, "MultipleTable");
            }
            else
            {
                MessageBox.Show("You are not currently logged in. You will now be redirected to the login screen", "Redirecting to Login");
                return RedirectToAction("Login", "Home");
            }
        }

        public int CreateItNo()
        {
            Random rand = new Random();
            int randomInt = rand.Next(1000);
            return randomInt;
        }

        public int CustomerID
        {
            get
            {
                int custId = (int)Session["CustID"];
                return custId;
            }
        }

    }
}
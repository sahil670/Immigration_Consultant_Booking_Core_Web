using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Immigration_Consultant_Booking_Core_Web.BusinessLayer;

namespace Immigration_Consultant_Booking_Core_Web.Models
{
    //Connects the business layer objects to the databse with the 
    //Use of entity framework classes 
    public class Immigration_Consultant_Booking_DataContext : DbContext
    {
        public Immigration_Consultant_Booking_DataContext (DbContextOptions<Immigration_Consultant_Booking_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Immigration_Consultant_Booking_Core_Web.BusinessLayer.Agency> Agency { get; set; }

        public DbSet<Immigration_Consultant_Booking_Core_Web.BusinessLayer.Client> Client { get; set; }

        public DbSet<Immigration_Consultant_Booking_Core_Web.BusinessLayer.Consultant> Consultant { get; set; }

        public DbSet<Immigration_Consultant_Booking_Core_Web.BusinessLayer.ConsultationBooking> ConsultationBooking { get; set; }
    }
}

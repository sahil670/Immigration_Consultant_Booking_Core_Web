using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Immigration_Consultant_Booking_Core_Web.BusinessLayer;
using Immigration_Consultant_Booking_Core_Web.Models;

namespace Immigration_Consultant_Booking_Core_Web.Pages.ConsultationBookings
{
    //Gets the details of the booking
    public class DetailsModel : PageModel
    {
        private readonly Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext _context;

        public DetailsModel(Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext context)
        {
            _context = context;
        }

        public ConsultationBooking ConsultationBooking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConsultationBooking = await _context.ConsultationBooking
                .Include(c => c.Client)
                .Include(c => c.Consultant).FirstOrDefaultAsync(m => m.Id == id);

            if (ConsultationBooking == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

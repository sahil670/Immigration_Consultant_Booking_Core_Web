using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Immigration_Consultant_Booking_Core_Web.BusinessLayer;
using Immigration_Consultant_Booking_Core_Web.Models;

namespace Immigration_Consultant_Booking_Core_Web.Pages.ConsultationBookings
{
    //Creates a booking
    public class CreateModel : PageModel
    {
        private readonly Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext _context;

        public CreateModel(Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
        ViewData["ConsultantId"] = new SelectList(_context.Consultant, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ConsultationBooking ConsultationBooking { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ConsultationBooking.Add(ConsultationBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

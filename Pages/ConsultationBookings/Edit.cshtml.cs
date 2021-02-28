using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Immigration_Consultant_Booking_Core_Web.BusinessLayer;
using Immigration_Consultant_Booking_Core_Web.Models;

namespace Immigration_Consultant_Booking_Core_Web.Pages.ConsultationBookings
{
    //Updates the booking
    public class EditModel : PageModel
    {
        private readonly Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext _context;

        public EditModel(Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
           ViewData["ConsultantId"] = new SelectList(_context.Consultant, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ConsultationBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultationBookingExists(ConsultationBooking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConsultationBookingExists(int id)
        {
            return _context.ConsultationBooking.Any(e => e.Id == id);
        }
    }
}

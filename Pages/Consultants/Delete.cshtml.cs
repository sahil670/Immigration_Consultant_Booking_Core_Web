using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Immigration_Consultant_Booking_Core_Web.BusinessLayer;
using Immigration_Consultant_Booking_Core_Web.Models;

namespace Immigration_Consultant_Booking_Core_Web.Pages.Consultants
{
    //Removes the consultant from db
    public class DeleteModel : PageModel
    {
        private readonly Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext _context;

        public DeleteModel(Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consultant Consultant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Consultant = await _context.Consultant
                .Include(c => c.Agency).FirstOrDefaultAsync(m => m.Id == id);

            if (Consultant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Consultant = await _context.Consultant.FindAsync(id);

            if (Consultant != null)
            {
                _context.Consultant.Remove(Consultant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

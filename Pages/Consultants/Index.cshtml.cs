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
    //Gets list of consultants
    public class IndexModel : PageModel
    {
        private readonly Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext _context;

        public IndexModel(Immigration_Consultant_Booking_Core_Web.Models.Immigration_Consultant_Booking_DataContext context)
        {
            _context = context;
        }

        public IList<Consultant> Consultant { get;set; }

        public async Task OnGetAsync()
        {
            Consultant = await _context.Consultant
                .Include(c => c.Agency).ToListAsync();
        }
    }
}

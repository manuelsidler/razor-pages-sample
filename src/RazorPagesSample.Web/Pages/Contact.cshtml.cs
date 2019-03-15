using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesSample.Web.Models;
using RazorPagesSample.Web.Services;

namespace RazorPagesSample.Web.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }
        
        public string Message { get; private set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var emailService = new EmailService();
                emailService.SendMail(Contact);

                return new RedirectToPageResult("Confirmation", "Contact");
            }

            return Page();
        }

        public IActionResult OnPostSubscribe(string address)
        {
            var emailService = new EmailService();
            emailService.SendMail(address);
            return new RedirectToPageResult("Confirmation", "Subscribe");
        }
    }
}
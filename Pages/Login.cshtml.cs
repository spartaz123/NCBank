using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NCBank.Models;

namespace NCBank.Pages {
    public class LoginModel : PageModel {
        [BindProperty]
        public LoggedInCustomer cust {get; set; }

        public void OnGet() {
        }

        public async Task<IActionResult> OnPostAsync() {
            var filter = Builders<BsonDocument>.Filter.Eq("email", cust.Email);

            var projection = Builders<BsonDocument>.Projection.Include("email").Include("passwordHash");
            // verify email is a valid account
            var user = await DBInterface.cust.Find(filter).Project(projection).SingleOrDefaultAsync();
            // verify password
            if (cust.verifyPassword(user.GetValue("passwordHash").ToString())) {
                return RedirectToPage("/Dashboard");
            }
            return Page();
        }
    }
}
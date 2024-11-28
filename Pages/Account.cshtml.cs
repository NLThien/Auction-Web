using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using System;

namespace AuctionWeb.Pages
{
    public class AccountModel : PageModel
    {
        public User? currentUser { get; set; }

        public void OnGet()
        {
            currentUser = new User();

            TempData.ContainsKey("infoUserList");

        }
    }

    public class User
    {
        public string? Name { get; set; }
        public string? NameAccount {get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public decimal? Balance { get; set; }
        public string? Gender { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using it_shop_app.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace it_shop_app.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityNutzer> _userManager;
        private readonly SignInManager<IdentityNutzer> _signInManager;

        public IndexModel(
            UserManager<IdentityNutzer> userManager,
            SignInManager<IdentityNutzer> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Full name")]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Postleitzahl")]
            public string Plz { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Wohnort")]
            public string Ort { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Strasse")]
            public string Strasse { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Hausnummer")]
            public string Hausnummer { get; set; }

            [Required]
            [Display(Name = "Geburtsdatum")]
            [DataType(DataType.Date)]
            public DateTime Geburtsdatum { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(IdentityNutzer user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Name = user.Name,
                Plz = user.Plz,
                Ort = user.Ort,
                Strasse = user.Strasse,
                Hausnummer = user.Hausnummer,
                Geburtsdatum = user.Geburtsdatum,
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.Name != user.Name)
            {
                user.Name = Input.Name;
            }

            if (Input.Plz != user.Plz)
            {
                user.Plz = Input.Plz;
            }

            if (Input.Ort != user.Ort)
            {
                user.Ort = Input.Ort;
            }

            if (Input.Strasse != user.Strasse)
            {
                user.Strasse = Input.Strasse;
            }

            if (Input.Hausnummer != user.Hausnummer)
            {
                user.Hausnummer = Input.Hausnummer;
            }

            if (Input.Geburtsdatum != user.Geburtsdatum)
            {
                user.Geburtsdatum = Input.Geburtsdatum;
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

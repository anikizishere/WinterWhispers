// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WinterWhispers.Areas.Identity.Data;

namespace WinterWhispers.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<WinterWhispersUser> _userManager;
        private readonly SignInManager<WinterWhispersUser> _signInManager;
        private readonly IWebHostEnvironment _environment; /*ny*/

        public IndexModel(
            UserManager<WinterWhispersUser> userManager,
            SignInManager<WinterWhispersUser> signInManager,
            IWebHostEnvironment environment)/*ny*/
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;/*ny*/
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        /// 
        public string ProfileImagePath { get; private set; } /*ny*/

        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Telefonnummer")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Ingen profilbild än")] /*ny, här stod det "profilbild"*/
            public IFormFile ProfileImage { get; set; } /*ny*/
        }

        private async Task LoadAsync(WinterWhispersUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;
            ProfileImagePath = user.ProfileImagePath;

            Input = new InputModel
            {
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

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Oväntat fel vid försök att ändra telefonnummer.";
                    return RedirectToPage();
                }
            }

            if (Input.ProfileImage != null) /*ny, hela if-satsen*/
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "profileImage");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var fileName = $"{Path.GetFileNameWithoutExtension(Input.ProfileImage.FileName)}_{new Random().Next(0, 100000)}{Path.GetExtension(Input.ProfileImage.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.ProfileImage.CopyToAsync(fileStream);
                }

                user.ProfileImagePath = $"/profileImage/{fileName}";
                var updateResult = await _userManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                {
                    StatusMessage = "Oväntat fel vid försök att uppdatera profilbild.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Din profil har uppdaterats";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteImageAsync() /*ny, hela if-satsen*/
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var imagePath = Path.Combine(_environment.WebRootPath, "profileImage", Path.GetFileName(user.ProfileImagePath));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            user.ProfileImagePath = null;
            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                StatusMessage = "Oväntat fel vid försök att ta bort profilbild.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profilbilden har tagits bort";
            return RedirectToPage();
        }



    }
}

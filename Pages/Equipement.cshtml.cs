using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Metadata;
using System.Security.Claims;
using static System.Reflection.Metadata.BlobBuilder;

namespace WinterWhispers.Pages
{
    //SIDAN ANVÄND EJ

    public class EquipementModel : PageModel
    {


        private readonly Data.WinterWhispersContext _context;
        private readonly UserManager<Areas.Identity.Data.WinterWhispersUser> _userManager;

        public EquipementModel(Data.WinterWhispersContext context, UserManager<Areas.Identity.Data.WinterWhispersUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public UserManager<Areas.Identity.Data.WinterWhispersUser> _userManager { get; set; }


        [BindProperty]
        public Models.Forum Forum { get; set; } /* ett enda inlägg*/

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public List<Models.Forum> Forums { get; set; }


        //lägga till topic?
        //lägga till kommentera?
        //lägga till skriv medelande till användare?


        public async Task OnGetAsync(int deleteId)
        {
            if (deleteId != 0)
            {
                Models.Forum postToBeDeleted = await _context.Forum.FindAsync(deleteId);

                if (postToBeDeleted != null)
                {
                    if (System.IO.File.Exists("./wwwroot/userImages/" + postToBeDeleted.Image))
                    {
                        System.IO.File.Delete("./wwwroot/userImages/" + postToBeDeleted.Image);
                    }
                    _context.Forum.Remove(postToBeDeleted);
                    await _context.SaveChangesAsync();

                }
            }
            Forums = await _context.Forum.ToListAsync();
        }

        public async Task OnPostAsync ()
        {
            var image = UploadedImage;
            string fileName = "";  /*ok att publicera ett inlägg utan bild, den får vara tom/null. */

            if (image != null)
            {
                Random rnd = new();
                fileName = "./wwwroot/postsImages/" + image.FileName + rnd.Next(0, 100000).ToString() ; /*lägger på en slumpmässig siffra mellan 0-hundra' om användare råkar ladda upp bilder med samma filnamn. */

                using(var fileStream = new FileStream(fileName, FileMode.Create))  /*skapar ny fil. */
                {
                    await image.CopyToAsync(fileStream);  /*sparar filen på hårddisken. */
                }
            }

            Forum.Date = DateTime.Now;
            Forum.Image = fileName;
            Forum.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Forum.Topic =
            _context.Forum.Add(Forum);

            await _context.SaveChangesAsync();

            //return RedirectToPage("./Equipement");

            //lägga till topic?
            //lägga till kommentera?
            //lägga till skriv medelande till användare?

        }



    }
}

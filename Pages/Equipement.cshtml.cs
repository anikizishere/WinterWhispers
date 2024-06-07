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
    //SIDAN ANV�ND EJ

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
        public Models.Forum Forum { get; set; } /* ett enda inl�gg*/

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public List<Models.Forum> Forums { get; set; }


        //l�gga till topic?
        //l�gga till kommentera?
        //l�gga till skriv medelande till anv�ndare?


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
            string fileName = "";  /*ok att publicera ett inl�gg utan bild, den f�r vara tom/null. */

            if (image != null)
            {
                Random rnd = new();
                fileName = "./wwwroot/postsImages/" + image.FileName + rnd.Next(0, 100000).ToString() ; /*l�gger p� en slumpm�ssig siffra mellan 0-hundra' om anv�ndare r�kar ladda upp bilder med samma filnamn. */

                using(var fileStream = new FileStream(fileName, FileMode.Create))  /*skapar ny fil. */
                {
                    await image.CopyToAsync(fileStream);  /*sparar filen p� h�rddisken. */
                }
            }

            Forum.Date = DateTime.Now;
            Forum.Image = fileName;
            Forum.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Forum.Topic =
            _context.Forum.Add(Forum);

            await _context.SaveChangesAsync();

            //return RedirectToPage("./Equipement");

            //l�gga till topic?
            //l�gga till kommentera?
            //l�gga till skriv medelande till anv�ndare?

        }



    }
}

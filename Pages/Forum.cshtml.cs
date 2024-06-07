using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WinterWhispers.Models;

namespace WinterWhispers.Pages
{
    public class ForumModel : PageModel
    {

        private readonly Data.WinterWhispersContext _context;
        private readonly UserManager<Areas.Identity.Data.WinterWhispersUser> _userManager;

        public ForumModel(Data.WinterWhispersContext context, UserManager<Areas.Identity.Data.WinterWhispersUser> userManager)
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

        public List<Models.Topic> Topics { get; set; }

        public Dictionary<string, List<Models.Forum>> ForumsGroupedByTopic { get; set; }

        public List<Models.Forum> ReportedForums { get; set; }

        public bool IsUser { get; set; }
        public bool IsAdmin { get; set; }
       

        public async Task OnGetAsync(int deleteId)
        {
            if (deleteId != 0)
            {
                Models.Forum postToBeDeleted = await _context.Forum.FindAsync(deleteId);

                if (postToBeDeleted != null)
                {
                    if (System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "userImages", postToBeDeleted.Image)))
                    {
                        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "userImages", postToBeDeleted.Image));
                    }
                    _context.Forum.Remove(postToBeDeleted);
                    await _context.SaveChangesAsync();

                }
            }

            Topics = await _context.Topic.ToListAsync();
            var forums = await _context.Forum
                .Include(f => f.Topic)
                .Include(f => f.User)
                .ToListAsync();

            ForumsGroupedByTopic = forums
                .GroupBy(f => f.Topic.Name)
                .ToDictionary(g => g.Key, g => g.ToList());

            ReportedForums = forums.Where(f => f.Reported).ToList();

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                IsUser = await _userManager.IsInRoleAsync(user, "User");
                IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            }
        }

        public async Task<IActionResult> OnPostReportAsync(int reportId) /*anmälda inlägg*/
        {
            var forum = await _context.Forum.FindAsync(reportId);
            if (forum != null)
            {
                forum.Reported = true;
                _context.Forum.Update(forum);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int deleteId) /*ta bort inlägg*/
        {
            var forum = await _context.Forum.FindAsync(deleteId);
            if (forum != null)
            {
                _context.Forum.Remove(forum);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Topics = await _context.Topic.ToListAsync();
                //return Page();
            }

            var image = UploadedImage;
            string fileName = "";  /*ok att publicera ett inlägg utan bild, den får vara tom/null. */

            if (image != null)
            {
                Random rnd = new();
                var uniqueFileName = $"{Path.GetFileNameWithoutExtension(image.FileName)}_{rnd.Next(0, 100000)}{Path.GetExtension(image.FileName)}";
                fileName = Path.Combine("userImages", uniqueFileName);  

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName); 

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);  //Spara fil till disk.
                }
            }

            Forum.Date = DateTime.Now;
            Forum.Image = fileName;
            Forum.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (Forum == null)
            {
                Forum = new Models.Forum();
            }

            if (Forum.Topic == null)
            {
                Forum.Topic = new Models.Topic();
            }

            if (string.IsNullOrWhiteSpace(Forum.Topic.Name))
            {
                ModelState.AddModelError("Forum.Topic.Name", "Please select a topic.");
                Topics = await _context.Topic.ToListAsync();
                //return Page();
            }


            var selectedTopic = await _context.Topic.FirstOrDefaultAsync(t => t.Name == Forum.Topic.Name);
            if (selectedTopic == null)
            {
                ModelState.AddModelError("Forum.TopicId", "Invalid topic selected.");
                Topics = await _context.Topic.ToListAsync();
                //return Page();
            }
           
            
            _context.Forum.Add(Forum);
            await _context.SaveChangesAsync();

            //Forum.Topic = selectedTopic;
            //Forum.TopicId = selectedTopic.Id;

            //return RedirectToPage("./Forum");
            


        }

    }

}

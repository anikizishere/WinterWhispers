using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WinterWhispers.Areas.Identity.Data;
using WinterWhispers.Data;
using Microsoft.EntityFrameworkCore;
using WinterWhispers.Models;

namespace WinterWhispers.Pages
{
    //denna sida används inte just nu

    public class CommentsModel : PageModel
    {
        private readonly WinterWhispersContext _context;
        private readonly UserManager<WinterWhispersUser> _userManager;

        public CommentsModel(WinterWhispersContext context, UserManager<WinterWhispersUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public Forum Post { get; set; }
        [BindProperty]

        public Comment NewComment { get; set; }

        public IList<Comment> Comments { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Post = await _context.Forum
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Post == null) return NotFound();

            Comments = await _context.Comments
                .Where(c => c.PostId == id)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int postId)
        {
            var user = await _userManager.GetUserAsync(User);

            _context.Comments.Add(new Comment
            {
                UserId = user.Id,
                PostId = postId,
                Text = NewComment.Text,
                Date = DateTime.Now
            });

            await _context.SaveChangesAsync();

            return RedirectToPage(new { id = postId });
        }
    }
}


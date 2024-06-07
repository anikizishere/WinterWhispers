using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WinterWhispers.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using WinterWhispers.Models;

namespace WinterWhispers.Pages
{
    //sidan används inte just nu

    public class MessageModel : PageModel
    {

        //    private readonly Data.WinterWhispersContext _context;
        //    private readonly UserManager<WinterWhispersUser> _userManager;

        //    public MessageModel(Data.WinterWhispersContext context, UserManager<WinterWhispersUser> userManager)
        //    {
        //        _context = context;
        //        _userManager = userManager;
        //    }

        //    public IList<WinterWhispersUser> Users { get; set; }
        //    [BindProperty]

        //    public Inbox NewMessage { get; set; }

        //    public IList<Inbox> ReceivedMessages { get; set; }

        //    public Dictionary<string, string> SenderNames { get; set; } = new Dictionary<string, string>();

        //    public async Task<IActionResult> OnGetAsync()
        //    {
        //        if (!User.Identity.IsAuthenticated)
        //        {
        //            return Page();
        //        }

        //        var user = await _userManager.GetUserAsync(User);
        //        if (user == null)
        //        {
        //            return Forbid();
        //        }

        //        Users = await _userManager.Users.ToListAsync();
        //        ReceivedMessages = await _context.Inbox
        //            .Where(m => m.ReceiverId == user.Id)
        //            .ToListAsync();

        //        foreach (var message in ReceivedMessages)
        //        {
        //            var sender = await _userManager.FindByIdAsync(message.SenderId);
        //            if (sender != null)
        //            {
        //                SenderNames[message.SenderId] = sender.UserName;
        //            }
        //        }

        //        return Page();
        //    }

        //    public async Task<IActionResult> OnPostAsync()
        //    {
        //        if (!User.Identity.IsAuthenticated)
        //        {
        //            return Forbid();
        //        }

        //        var sender = await _userManager.GetUserAsync(User);
        //        if (sender == null)
        //        {
        //            return Forbid();
        //        }

        //        NewMessage.SenderId = sender.Id;
        //        NewMessage.DateSent = DateTime.Now;

        //        _context.Inbox.Add(NewMessage);
        //        await _context.SaveChangesAsync();

        //        return RedirectToPage("/Message");
        //    }
    }
}

using Microsoft.AspNetCore.Mvc;
using UserCommentsAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserCommentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext _context;  // Perbaiki nama _context sesuai dengan AppDbContext

        public CommentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserComment>>> GetComments()  // Perbaiki tipe kembalian menggunakan UserComment
        {
            return await _context.UserComments.ToListAsync();  // Perbaiki penggunaan DbSet UserComments
        }

        // POST: api/comments
        [HttpPost]
        public async Task<ActionResult<UserComment>> PostComment(UserComment userComment)  // Gunakan UserComment di sini
        {
            _context.UserComments.Add(userComment);  // Perbaiki penambahan komentar ke UserComments
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComments), new { id = userComment.Id }, userComment);  // Perbaiki penamaan di sini
        }
    }
}

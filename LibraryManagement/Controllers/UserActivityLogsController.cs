using LibraryManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class UserActivityLogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserActivityLogsController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _context.UserActivityLogs
                .AsNoTracking()
                .Include(l => l.User)
                .OrderByDescending(l => l.Timestamp)
                .Select(l => new
                {
                    l.Id,
                    l.UserId,
                    UserName = l.User.UserName,
                    l.Action,
                    l.EntityName,
                    l.EntityId,
                    l.Timestamp,
                    l.IpAddress
                })
                .ToListAsync();

            return Ok(logs);
        }
    }
}

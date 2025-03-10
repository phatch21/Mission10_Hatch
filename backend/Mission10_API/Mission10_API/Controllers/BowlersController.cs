using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission10_API.Models; // Adjust the namespace based on your project

[Route("api/[controller]")]
[ApiController]
public class BowlersController : ControllerBase
{
    private readonly BowlingDbContext _context;

    public BowlersController(BowlingDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BowlerDTO>>> GetBowlers()
    {
        var filteredBowlers = await _context.Bowlers
            .Include(b => b.Team)
            .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
            .Select(b => new BowlerDTO
            {
                BowlerId = b.BowlerId,
                FullName = $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}".Trim(),
                TeamName = b.Team.TeamName,
                Address = b.BowlerAddress,
                City = b.BowlerCity,
                State = b.BowlerState,
                Zip = b.BowlerZip,
                Phone = b.BowlerPhoneNumber
            })
            .ToListAsync();

        return Ok(filteredBowlers);
    }
}

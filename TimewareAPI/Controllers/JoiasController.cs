using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimewareAPI.Domain;
using TimewareAPI.Infrastructure;

namespace TimewareAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JoiasController : ControllerBase
{
    private readonly AppDbContext _context;

    public JoiasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Joias.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(Joia joia)
    {
        _context.Joias.Add(joia);
        await _context.SaveChangesAsync();
        return Ok(joia);
    }
}
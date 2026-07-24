using Microsoft.AspNetCore.Mvc;
using TimewareAPI.Application;

namespace TimewareAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendasController : ControllerBase
{
    private readonly VendaService _vendaService;

    public VendasController(VendaService vendaService)
    {
        _vendaService = vendaService;
    }

    [HttpPost]
    public async Task<IActionResult> RealizarVenda(int joiaId, int quantidade)
    {
        try
        {
            var venda = await _vendaService.RealizarVendaAsync(joiaId, quantidade);
            return Ok(venda);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}
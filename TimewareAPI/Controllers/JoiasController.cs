using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimewareAPI.Domain;
using TimewareAPI.Infrastructure;
using System.Data.Common;

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
    [HttpGet("relatorio-estoque-sql-puro")]
    public IActionResult RelatorioEstoqueSqlPuro()
    {
        // Requisito do Desafio: Consulta escrita na mão (SQL puro)
        using var connection = _context.Database.GetDbConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        // SQL raiz selecionando apenas o necessário
        command.CommandText = "SELECT Nome, QuantidadeEmEstoque FROM Joias WHERE QuantidadeEmEstoque > 0";

        using var reader = command.ExecuteReader();
        var relatorio = new List<object>();

        while (reader.Read())
        {
            relatorio.Add(new
            {
                Nome = reader.GetString(0),
                Estoque = reader.GetInt32(1)
            });
        }

        return Ok(relatorio);
    }
}
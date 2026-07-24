using Microsoft.EntityFrameworkCore;
using TimewareAPI.Domain;
using TimewareAPI.Infrastructure;

namespace TimewareAPI.Application;

public class VendaService
{
    private readonly AppDbContext _context;

    public VendaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Venda> RealizarVendaAsync(int joiaId, int quantidade)
    {
        var joia = await _context.Joias.FindAsync(joiaId);
        if (joia == null) throw new Exception("Joia não encontrada.");
        if (joia.QuantidadeEmEstoque < quantidade) throw new Exception("Estoque insuficiente.");

        // DML via ORM (Atualizando e Inserindo)
        joia.QuantidadeEmEstoque -= quantidade;

        var venda = new Venda
        {
            JoiaId = joiaId,
            QuantidadeVendida = quantidade,
            DataVenda = DateTime.Now
        };

        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();

        return venda;
    }
}
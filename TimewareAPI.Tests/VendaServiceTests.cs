using Microsoft.EntityFrameworkCore;
using TimewareAPI.Application;
using TimewareAPI.Domain;
using TimewareAPI.Infrastructure;
using Xunit;

namespace TimewareAPI.Tests;

public class VendaServiceTests
{
    private DbContextOptions<AppDbContext> GetInMemoryOptions()
    {
        return new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    [Fact]
    public async Task RealizarVenda_DeveLancarExcecao_QuandoEstoqueIncompleto()
    {
        // Arrange (Prepara o cenário)
        var options = GetInMemoryOptions();
        using var context = new AppDbContext(options);
        
        var joia = new Joia { Id = 1, Nome = "Anel de Ouro", Preco = 1000, QuantidadeEmEstoque = 1 };
        context.Joias.Add(joia);
        await context.SaveChangesAsync();

        var service = new VendaService(context);

        // Act & Assert (Executa a ação e verifica se o erro esperado aconteceu)
        var excecao = await Assert.ThrowsAsync<Exception>(() => 
            service.RealizarVendaAsync(joiaId: 1, quantidade: 2));

        Assert.Equal("Estoque insuficiente.", excecao.Message);
    }
}
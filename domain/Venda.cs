namespace TimewareAPI.Domain;

public class Venda
{
    public int Id { get; set; }
    public int JoiaId { get; set; }
    public Joia? Joia { get; set; } // Propriedade de navegação
    public int QuantidadeVendida { get; set; }
    public DateTime DataVenda { get; set; }
}